using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Mech3DotNet
{
    public class Reader
    {
        public class InvalidRootException : Exception { }
        public class NotFoundException : Exception
        {
            public NotFoundException(string message) : base(message) { }
        }

        public JToken root;

        public Reader(JToken root)
        {
            this.root = root;
        }

        public JToken Query(string queryPath)
        {
            var path = new QueryPath(queryPath);
            JToken current = root;

            foreach (var segment in path)
            {
                if (current.Type != JTokenType.Array)
                    throw new NotFoundException($"'{path.Processed}' not found (not an array)");
                if (segment.IsKey)
                {
                    var key = segment.Key;
                    var found = new List<JToken>();
                    foreach (var child in current.Children())
                    {
                        if (child.Type == JTokenType.String && (string)child == key)
                        {
                            current = child.Next;
                            if (current == null)
                                throw new NotFoundException($"'{path.Processed}' not found (no value)");
                            found.Add(current);
                        }
                    }
                    if (found.Count == 0)
                        throw new NotFoundException($"'{path.Processed}' not found (no key)");
                    else if (found.Count == 1)
                        current = found[0];
                    else
                        current = new JArray(found);
                }
                else
                {
                    var index = segment.Index;
                    var children = new List<JToken>(current.Children());
                    if (index < 0)
                        index = children.Count + index;
                    try
                    {
                        current = children[index];
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        throw new NotFoundException($"'{path.Processed}' not found (index: 0 <= {index} < {children.Count})");
                    }
                }
            }
            return current;
        }

        public static Reader Parse(string json)
        {
            var root = Settings.DeserializeObject<JArray>(json);
            return Read(root);
        }

        public static Reader Read(JArray root)
        {
            // we strip the first array, since all readers have this
            if (root.Count != 1)
                throw new InvalidRootException();
            return new Reader((JToken)root.First);
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public string GetJson()
        {
            var new_root = new JArray();
            new_root.Add(root);
            return Settings.SerializeObject(new_root);
        }
    }
}
