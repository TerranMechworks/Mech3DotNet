using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    /// <summary>
    /// Allows applying multiple <see cref="IQueryOperation"/> to a
    /// <see cref="ReaderValue"/>, while tracking the path of the queries
    /// through the data.
    /// </summary>
    public struct Query
    {
        internal ReaderValue _value;
        internal List<string> _path;

        public Query(ReaderValue value)
        {
            _value = value;
            _path = new List<string>
            {
                // ensure path starts with "/"
                ""
            };
        }

        public override string ToString()
        {
            var displayPath = string.Join("/", _path);
            return $"{displayPath}: {_value}";
        }

        public readonly ReaderValue Value { get => _value; }

        /// <summary>
        /// Apply the <see cref="IQueryOperation"/> to the current value.
        /// </summary>
        public static Query operator /(Query query, IQueryOperation op)
        {
            query._value = op.Apply(query._value, query._path);
            return query;
        }

        /// <summary>
        /// Apply a <see cref="FindByIndex"/> <see cref="IQueryOperation"/>
        /// based on the specified index to the current value.
        /// </summary>
        public static Query operator /(Query query, int index) => query / new FindByIndex(index);

        /// <summary>
        /// Apply a <see cref="FindByKey"/> <see cref="IQueryOperation"/>
        /// based on the specified key to the current value.
        /// </summary>
        public static Query operator /(Query query, string key) => query / new FindByKey(key);

        /// <summary>
        /// Convenience method to create a <see cref="FindOnly"/>
        /// <see cref="IQueryOperation"/>.
        /// </summary>
        public static FindOnly Only() => new FindOnly();

        /// <summary>
        /// Convenience method to create a <see cref="FindByKey"/> based on the
        /// specified key, followed immediately by a <see cref="FindOnly"/>
        /// <see cref="IQueryOperation"/>.
        /// </summary>
        public static Combinator Only(string key) => new Combinator(new FindByKey(key), new FindOnly());

        /// <summary>
        /// Create a new <see cref="Query"/> with the specified
        /// <see cref="ReaderValue"/> as the root.
        ///
        /// Because root values in reader ZBD data are usually a list with a
        /// single item (it isn't known why), currently this immediately
        /// applies a <see cref="FindOnly"/> <see cref="IQueryOperation"/>.
        /// However, this may change in future.
        /// </summary>
        public static Query Root(ReaderValue value) => new Query(value) / new FindOnly();

        /// <summary>
        /// Convenience method to create a <see cref="ToInt"/>
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToInt Int() => new ToInt();

        /// <summary>
        /// Convenience method to create a <see cref="ToFloat"/>
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToFloat Float() => new ToFloat();

        /// <summary>
        /// Convenience method to create a <see cref="ToNumber"/>
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToNumber Number() => new ToNumber();

        /// <summary>
        /// Convenience method to create a <see cref="ToStr"/>
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToStr String() => new ToStr();

        /// <summary>
        /// Convenience method to create a <see cref="ToBool"/>
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToBool Bool() => new ToBool();

        /// <summary>
        /// Convenience method to create a <see cref="ToArray{T}"/>
        /// <see cref="IConvertOperation{T}" /> based on the specified inner
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToArray<T> Array<T>(IConvertOperation<T> op) => new ToArray<T>(op);

        /// <summary>
        /// Convenience method to create a <see cref="ToList{T}"/>
        /// <see cref="IConvertOperation{T}" /> based on the specified inner
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToList<T> List<T>(IConvertOperation<T> op) => new ToList<T>(op);

        /// <summary>
        /// Convenience method to create a <see cref="ToKeyValue{T}"/>
        /// <see cref="IConvertOperation{T}" /> based on the specified inner
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToKeyValue<T> KeyValue<T>(IConvertOperation<T> op) => new ToKeyValue<T>(op);

        /// <summary>
        /// Convenience method to create a <see cref="ToDict{T}"/>
        /// <see cref="IConvertOperation{T}" /> based on the specified inner
        /// <see cref="IConvertOperation{T}" />.
        /// </summary>
        public static ToDict<T> Dict<T>(IConvertOperation<T> op) => new ToDict<T>(op);
    }
}
