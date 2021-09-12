using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using static Mech3DotNet.Reader.Helpers;

namespace Mech3DotNet.Reader
{
    public struct Query
    {
        public JToken token { get; private set; }
        internal readonly ReaderDeserializer deserializer;
        internal List<string> path;

        internal Query(JToken token, ReaderDeserializer deserializer)
        {
            this.token = token;
            this.deserializer = deserializer;
            this.path = new List<string>();
            this.path.Add("");
        }

        public override string ToString()
        {
            var path = string.Join("/", this.path.ToArray());
            return $"{path}: {this.token}";
        }

        public static Query Q(JToken token, ReaderDeserializer deserializer)
        {
            return new Query(token, deserializer);
        }

        public static Query Q(JToken token)
        {
            return new Query(token, new ReaderDeserializer());
        }

        public static FindOnly Only()
        {
            return new FindOnly();
        }

        public static Query operator /(Query query, IQueryOperation op)
        {
            query.token = op.Apply(query.token, query.path);
            return query;
        }

        public static Query operator /(Query query, int index)
        {
            return query / new FindByIndex(index);
        }

        public static Query operator /(Query query, string key)
        {
            return query / new FindByKey(key);
        }
    }

    public interface IQueryOperation
    {
        JToken Apply(JToken token, List<string> path);
    }

    public struct FindByKey : IQueryOperation
    {
        private string key;

        public FindByKey(string key)
        {
            this.key = key;
        }

        public JToken Apply(JToken token, List<string> path)
        {
            if (token.Type != JTokenType.Array)
                throw new NotFoundException(AddPath($"Key '{this.key}' not found (not an array)", path));

            var found = new List<JToken>();
            foreach (var child in token.Children())
            {
                if (child.Type == JTokenType.String && (string)child == this.key)
                {
                    var item = child.Next;
                    if (item == null)
                        throw new NotFoundException(AddPath($"Key '{this.key}' not found (no value)", path));
                    found.Add(item);
                }
            }

            if (found.Count == 0)
                throw new NotFoundException(AddPath($"Key '{this.key}' not found (no keys)", path));

            path.Add(this.key);
            return new JArray(found);
        }
    }

    public struct FindByIndex : IQueryOperation
    {
        private int index;

        public FindByIndex(int index)
        {
            this.index = index;
        }

        public JToken Apply(JToken token, List<string> path)
        {
            if (token.Type != JTokenType.Array)
                throw new NotFoundException(AddPath($"Index '{this.index}' not found (not an array)", path));
            var array = (JArray)token;
            var index = this.index;
            var count = array.Count;
            // allow negative indexing, i.e. from back of list
            if (index < 0)
                index = count + index;
            JToken item = null;
            try
            {
                item = array[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new NotFoundException(AddPath($"Index '{this.index}' not found (index: 0 <= {index} < {count})", path));
            }
            path.Add(this.index.ToString());
            return item;
        }
    }

    public struct FindOnly : IQueryOperation
    {
        public JToken Apply(JToken token, List<string> path)
        {
            if (token.Type != JTokenType.Array)
                throw new NotFoundException(AddPath("Only item not found (not an array)", path));

            var array = (JArray)token;
            if (array.Count < 1)
                throw new NotFoundException(AddPath("Only item not found (no items)", path));

            if (array.Count > 1)
                throw new NotFoundException(AddPath($"Only item not found ({array.Count} items)", path));

            path.Add(".only");
            return array[0];
        }
    }
}
