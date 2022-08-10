using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public struct Query
    {
        public JsonNode? element { get; private set; }
        internal List<string> path;

        internal Query(JsonNode? element)
        {
            this.element = element;
            this.path = new List<string>();
            this.path.Add("");
        }

        public override string ToString()
        {
            var path = string.Join("/", this.path);
            return $"{path}: {this.element}";
        }

        public static Query Q(JsonNode? element)
        {
            return new Query(element);
        }

        public static Query operator /(Query query, IQueryOperation op)
        {
            query.element = op.Apply(query.element, query.path);
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

        public static ToArray<T> Array<T>(IConvertOperation<T> op)
        {
            return new ToArray<T>(op);
        }

        public static ToList<T> List<T>(IConvertOperation<T> op)
        {
            return new ToList<T>(op);
        }
    }
}
