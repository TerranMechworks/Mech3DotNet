using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct Query
    {
        internal ReaderValue value;
        internal List<string> path;

        internal Query(ReaderValue value)
        {
            this.value = value;
            this.path = new List<string>();
            // ensure path starts with "/"
            this.path.Add("");
        }

        public override string ToString()
        {
            var displayPath = string.Join("/", path);
            return $"{displayPath}: {value.ToString()}";
        }

        public static Query operator /(Query query, IQueryOperation op)
        {
            query.value = op.Apply(query.value, query.path);
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

        public static Combinator Only(string key)
        {
            return new Combinator(new FindByKey(key), new FindOnly());
        }

        public static Query Root(ReaderValue value)
        {
            return value / new FindOnly();
        }

        public static ToInt Int()
        {
            return new ToInt();
        }

        public static ToFloat Float()
        {
            return new ToFloat();
        }

        public static ToNumber Number()
        {
            return new ToNumber();
        }

        public static ToStr String()
        {
            return new ToStr();
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

        public static ToKeyValue<T> KeyValue<T>(IConvertOperation<T> op)
        {
            return new ToKeyValue<T>(op);
        }

        public static ToDict<T> Dict<T>(IConvertOperation<T> op)
        {
            return new ToDict<T>(op);
        }
    }
}
