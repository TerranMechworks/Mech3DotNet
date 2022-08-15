using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct Query
    {
        public JsonNode? node { get; private set; }
        internal List<string> path;

        internal Query(JsonNode? node)
        {
            this.node = node;
            this.path = new List<string>();
            // ensure path starts with "/"
            this.path.Add("");
        }

        public override string ToString()
        {
            string displayJson;
            if (node is null)
                displayJson = "null";
            else
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };
                displayJson = node.ToJsonString(options);
            }
            var displayPath = string.Join("/", path);
            return $"{displayPath}: {displayJson}";
        }

        public static Query Q(JsonNode? node)
        {
            return new Query(node);
        }

        public static Query operator /(Query query, IQueryOperation op)
        {
            query.node = op.Apply(query.node, query.path);
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

        public static FindOnly Only()
        {
            return new FindOnly();
        }

        public static ToInt Int()
        {
            return new ToInt();
        }

        public static ToFloat Float()
        {
            return new ToFloat();
        }

        public static ToString String()
        {
            return new ToString();
        }

        public static ToBool Bool()
        {
            return new ToBool();
        }

        public static ToArray<T> Array<T>(IConvertOperation<T> op)
        {
            return new ToArray<T>(op);
        }

        public static ToList<T> List<T>(IConvertOperation<T> op)
        {
            return new ToList<T>(op);
        }

        public static ToKeyValue<T> KeyValue<T>(IConvertOperation<T> op, bool check_even = true)
        {
            return new ToKeyValue<T>(op);
        }

        public static ToDict<T> Dict<T>(IConvertOperation<T> op, bool check_even = true)
        {
            return new ToDict<T>(op);
        }
    }
}
