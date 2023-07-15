using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Mech3DotNet.Reader
{
    /// <summary>The kind of <see cref="ReaderValue"/>.</summary>
    public enum ReaderValueKind
    {
        Int,
        Float,
        String,
        List,
    }

    /// <summary>
    /// An error occurred reading a <see cref="ReaderValue"/> from binary.
    /// </summary>
    public class ReaderValueReadException : Exception
    {
        public ReaderValueReadException(string message) : base(message) { }
    }

    /// <summary>A value in reader ZBD data.</summary>
    public abstract class ReaderValue
    {
        protected const int INT = 1;
        protected const int FLOAT = 2;
        protected const int STRING = 3;
        protected const int LIST = 4;

        /// <summary>The kind of <see cref="ReaderValue"/>.</summary>
        public abstract ReaderValueKind Kind { get; }

        /// <summary>Read a <see cref="ReaderValue"/> from binary.</summary>
        /// <exception cref="ReaderValueReadException">
        /// Thrown if:
        /// * The reader value kind is unknown
        /// * When the reader value kind is a string, and the string length is
        ///   negative.
        /// * When the reader value kind is a list, and the list length is
        ///   negative.
        /// </exception>
        public static ReaderValue Read(BinaryReader reader)
        {
            var kind = reader.ReadInt32();
            switch (kind)
            {
                case INT:
                    return ReaderInt.ReadValue(reader);
                case FLOAT:
                    return ReaderFloat.ReadValue(reader);
                case STRING:
                    return ReaderString.ReadValue(reader);
                case LIST:
                    return ReaderList.ReadValue(reader);
                default:
                    throw new ReaderValueReadException($"Unknown value kind {kind}");
            }
        }

        public abstract void Write(BinaryWriter writer);

        internal abstract void Repr(StringBuilder builder, int level);

        /// <summary>
        /// Create a new <see cref="Query"/> on this value, and apply the
        /// <see cref="IQueryOperation"/>.
        /// </summary>
        public static Query operator /(ReaderValue value, IQueryOperation op) => new Query(value) / op;
        /// <summary>
        /// Create a new <see cref="Query"/> on this value, and apply a
        /// <see cref="FindByIndex"/> <see cref="IQueryOperation"/> based on
        /// the specified index.
        /// </summary>
        public static Query operator /(ReaderValue value, int index) => value / new FindByIndex(index);
        /// <summary>
        /// Create a new <see cref="Query"/> on this value, and apply a
        /// <see cref="FindByKey"/> <see cref="IQueryOperation"/> based on the
        /// specified key.
        /// </summary>
        public static Query operator /(ReaderValue value, string key) => value / new FindByKey(key);
    }

    public sealed class ReaderInt : ReaderValue, IEquatable<ReaderInt>
    {
        public int Value { get; set; }
        public override ReaderValueKind Kind => ReaderValueKind.Int;

        public ReaderInt() { }

        public ReaderInt(int value)
        {
            Value = value;
        }

        internal static ReaderInt ReadValue(BinaryReader reader)
        {
            return new ReaderInt(reader.ReadInt32());
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(INT);
            writer.Write(Value);
        }

        internal override void Repr(StringBuilder builder, int level)
        {
            builder.Append(' ', level * 2);
            builder.Append(ToString());
        }

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

        public static implicit operator ReaderInt(int value) => new ReaderInt(value);
        public static implicit operator int(ReaderInt value) => value.Value;

        public override bool Equals(object obj) => Equals(obj as ReaderInt);
        public bool Equals(ReaderInt? other) => other != null && Value == other.Value;
        public override int GetHashCode() => HashCode.Combine(Value);
    }

    public sealed class ReaderFloat : ReaderValue, IEquatable<ReaderFloat>
    {
        public float Value { get; set; }
        public override ReaderValueKind Kind => ReaderValueKind.Float;

        public ReaderFloat() { }

        public ReaderFloat(float value)
        {
            Value = value;
        }

        internal static ReaderFloat ReadValue(BinaryReader reader)
        {
            return new ReaderFloat(reader.ReadSingle());
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(FLOAT);
            writer.Write(Value);
        }

        internal override void Repr(StringBuilder builder, int level)
        {
            builder.Append(' ', level * 2);
            builder.Append(ToString());
        }

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

        public static implicit operator ReaderFloat(float value) => new ReaderFloat(value);
        public static implicit operator float(ReaderFloat value) => value.Value;

        public override bool Equals(object obj) => Equals(obj as ReaderFloat);
        public bool Equals(ReaderFloat? other) => other != null && Value == other.Value;
        public override int GetHashCode() => HashCode.Combine(Value);
    }

    public sealed class ReaderString : ReaderValue, IEquatable<ReaderString>
    {
        public string Value { get; set; }
        public override ReaderValueKind Kind => ReaderValueKind.String;

        public ReaderString()
        {
            Value = string.Empty;
        }

        public ReaderString(string value)
        {
            Value = value;
        }

        internal static ReaderString ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();
            if (count < 0)
                throw new ReaderValueReadException($"String length was negative: {count}");

            var bytes = reader.ReadBytes(count);
            var value = System.Text.Encoding.ASCII.GetString(bytes);
            return new ReaderString(value);
        }

        public override void Write(BinaryWriter writer)
        {
            var bytes = System.Text.Encoding.ASCII.GetBytes(Value);
            var count = bytes.Length;
            writer.Write(STRING);
            writer.Write(count);
            writer.Write(bytes);
        }

        public override string ToString() => Value;

        internal override void Repr(StringBuilder builder, int level)
        {
            builder.Append(' ', level * 2);
            builder.Append(ToString());
        }

        public static implicit operator ReaderString(string value) => new ReaderString(value);
        public static implicit operator string(ReaderString value) => value.Value;

        public override bool Equals(object obj) => Equals(obj as ReaderString);
        public bool Equals(ReaderString? other) => other != null && Value == other.Value;
        public override int GetHashCode() => HashCode.Combine(Value);
    }

    public sealed class ReaderList : ReaderValue, IEnumerable<ReaderValue>, ICollection<ReaderValue>, IList<ReaderValue>
    {
        private List<ReaderValue> _values;
        public override ReaderValueKind Kind => ReaderValueKind.List;

        public ReaderList(List<ReaderValue> values)
        {
            _values = values;
        }

        public ReaderList(IEnumerable<ReaderValue> values)
        {
            _values = new List<ReaderValue>(values);
        }

        public ReaderList(params ReaderValue[] values)
        {
            this._values = new List<ReaderValue>(values);
        }

        internal static ReaderList ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32() - 1;
            if (count < 0)
                throw new ReaderValueReadException($"List length was negative: {count}");

            var value = new List<ReaderValue>(count);
            for (var i = 0; i < count; i++)
                value.Add(ReaderValue.Read(reader));

            return new ReaderList(value);
        }

        public override void Write(BinaryWriter writer)
        {
            var count = _values.Count + 1;
            writer.Write(LIST);
            writer.Write(count);
            foreach (var value in _values)
                value.Write(writer);
        }

        internal override void Repr(StringBuilder builder, int level)
        {
            builder.Append(' ', level * 2);
            builder.Append('[');
            builder.Append('\n');
            foreach (var value in _values)
            {
                value.Repr(builder, level + 1);
                builder.Append(',');
                builder.Append('\n');
            }
            builder.Append(' ', level * 2);
            builder.Append(']');
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            Repr(builder, 0);
            return builder.ToString();
        }

        public IEnumerator<ReaderValue> GetEnumerator() => _values.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _values.GetEnumerator();

        public int Count => _values.Count;
        public bool IsReadOnly => false;
        public void Add(ReaderValue item) => _values.Add(item);
        public void Clear() => _values.Clear();
        public bool Contains(ReaderValue item) => _values.Contains(item);
        public void CopyTo(ReaderValue[] array, int arrayIndex) => _values.CopyTo(array, arrayIndex);
        public bool Remove(ReaderValue item) => _values.Remove(item);

        public ReaderValue this[int index]
        {
            get { return _values[index]; }
            set { _values[index] = value; }
        }
        public int IndexOf(ReaderValue item) => _values.IndexOf(item);
        public void Insert(int index, ReaderValue item) => _values.Insert(index, item);
        public void RemoveAt(int index) => _values.RemoveAt(index);
    }
}
