using System;
using System.Collections.Generic;
using System.IO;

namespace Mech3DotNet.Reader
{
    public enum ReaderValueKind
    {
        Int,
        Float,
        String,
        List,
    }

    public class ReaderValueException : Exception
    {
        public ReaderValueException(string message) : base(message) { }
    }

    public abstract class ReaderValue
    {
        protected const int INT = 1;
        protected const int FLOAT = 2;
        protected const int STRING = 3;
        protected const int LIST = 4;

        public abstract ReaderValueKind Kind { get; }

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
                    throw new ReaderValueException($"Unknown value kind {kind}");
            }
        }

        public abstract void Write(BinaryWriter writer);
    }

    public sealed class ReaderInt : ReaderValue
    {
        public int Value { get; set; }
        public override ReaderValueKind Kind => ReaderValueKind.Int;

        public ReaderInt() {}

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

        public static implicit operator ReaderInt(int value)
        {
            return new ReaderInt(value);
        }

        public static implicit operator int(ReaderInt value)
        {
            return value.Value;
        }
    }

    public sealed class ReaderFloat : ReaderValue
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

        public static implicit operator ReaderFloat(float value)
        {
            return new ReaderFloat(value);
        }

        public static implicit operator float(ReaderFloat value)
        {
            return value.Value;
        }
    }

    public sealed class ReaderString : ReaderValue
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
                throw new ReaderValueException($"String length was negative: {count}");

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

        public static implicit operator ReaderString(string value)
        {
            return new ReaderString(value);
        }

        public static implicit operator string(ReaderString value)
        {
            return value.Value;
        }
    }

    public sealed class ReaderList : ReaderValue, IEnumerable<ReaderValue>, ICollection<ReaderValue>, IList<ReaderValue>
    {
        private List<ReaderValue> values;
        public override ReaderValueKind Kind => ReaderValueKind.List;

        public ReaderList(List<ReaderValue> values)
        {
            this.values = values;
        }

        public ReaderList(IEnumerable<ReaderValue> values)
        {
            this.values = new List<ReaderValue>(values);
        }

        public ReaderList(params ReaderValue[] values)
        {
            this.values = new List<ReaderValue>(values);
        }

        internal static ReaderList ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32() - 1;
            if (count < 0)
                throw new ReaderValueException($"List length was negative: {count}");

            var value = new List<ReaderValue>(count);
            for (var i = 0; i < count; i++)
                value.Add(ReaderValue.Read(reader));

            return new ReaderList(value);
        }

        public override void Write(BinaryWriter writer)
        {
            var count = values.Count + 1;
            writer.Write(LIST);
            writer.Write(count);
            foreach (var value in values)
                value.Write(writer);
        }

        public IEnumerator<ReaderValue> GetEnumerator() => values.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => values.GetEnumerator();

        public int Count => values.Count;
        public bool IsReadOnly => false;
        public void Add(ReaderValue item) => values.Add(item);
        public void Clear() => values.Clear();
        public bool Contains(ReaderValue item) => values.Contains(item);
        public void CopyTo(ReaderValue[] array, int arrayIndex) => values.CopyTo(array, arrayIndex);
        public bool Remove(ReaderValue item) => values.Remove(item);

        public ReaderValue this[int index] {
            get { return values[index]; }
            set { values[index] = value; }
        }
        public int IndexOf(ReaderValue item) => values.IndexOf(item);
        public void Insert(int index, ReaderValue item) => values.Insert(index, item);
        public void RemoveAt(int index) => values.RemoveAt(index);
    }
}
