using System;
using System.Collections.Generic;

namespace Mech3DotNet.Exchange
{
    public class Serializer
    {
        private Writer w;
        private List<TypeConverter> genericConverters;

        public Serializer(Writer w, List<TypeConverter> genericConverters)
        {
            this.w = w;
            this.genericConverters = genericConverters;
        }

        public void SerializeI8(sbyte v) => w.WriteI8(v);
        public void SerializeI16(short v) => w.WriteI16(v);
        public void SerializeI32(int v) => w.WriteI32(v);
        public void SerializeU8(byte v) => w.WriteU8(v);
        public void SerializeU16(ushort v) => w.WriteU16(v);
        public void SerializeU32(uint v) => w.WriteU32(v);
        public void SerializeF32(float v) => w.WriteF32(v);
        public void SerializeBool(bool v) => w.WriteBool(v);
        public void SerializeDateTime(DateTime v) => w.WriteStr(v.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssK"));
        public void SerializeBytes(byte[] v) => w.WriteBytes(v);

        public void SerializeString(string v)
        {
            if (v == null)
                throw new ArgumentNullException();
            w.WriteStr(v);
        }

        public void SerializeFieldName(string v)
        {
            if (v == null)
                throw new ArgumentNullException();
            w.WriteStr(v);
        }

        public Action<T?> SerializeValOption<T>(Action<T> write) where T : struct
        {
            return (T? v) => SerializeValOption(v, write);
        }

        private void SerializeValOption<T>(T? v, Action<T> write) where T : struct
        {
            if (v.HasValue)
            {
                w.WriteSome();
                write(v.Value);
            }
            else
                w.WriteNone();
        }

        public Action<T?> SerializeRefOption<T>(Action<T> write) where T : class
        {
            return (T? v) => SerializeRefOption(v, write);
        }

        private void SerializeRefOption<T>(T? v, Action<T> write) where T : class
        {
            if (v != null)
            {
                w.WriteSome();
                write(v);
            }
            else
                w.WriteNone();
        }

        public Action<List<T>> SerializeVec<T>(Action<T> write)
        {
            return (List<T> v) => SerializeVec(v, write);
        }

        private void SerializeVec<T>(List<T> v, Action<T> write)
        {
            if (v == null)
                throw new ArgumentNullException();
            w.WriteSeqSized((ulong)v.Count);
            foreach (var item in v)
            {
                write(item);
            }
        }

        public Action<T> Serialize<T>(TypeConverter<T> converter)
        {
            return (T v) => converter.Serialize(v, this);
        }

        public Action<T> SerializeGeneric<T>() where T : notnull
        {
            var type = typeof(T);
            return (T v) => SerializeGeneric(type, v);
        }

        private void SerializeGeneric(Type type, object v)
        {
            foreach (var converter in genericConverters)
            {
                if (converter.Type == type)
                {
                    converter.Serialize(v, this);
                    return;
                }
            }
            throw new UnknownGenericTypeException(type);
        }

        public void SerializeStruct(string name, ulong len) => w.WriteStruct(name, len);
        public void SerializeUnitVariant(string name, uint variantIndex) => w.WriteEnumUnit(name, variantIndex);
        public void SerializeNewTypeVariant(string name, uint variantIndex) => w.WriteEnumNewType(name, variantIndex);
    }
}
