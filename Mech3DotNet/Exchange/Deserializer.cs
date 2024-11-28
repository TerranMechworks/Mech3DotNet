using System;
using System.Collections.Generic;

namespace Mech3DotNet.Exchange
{
    /// <summary>Mech3ax exchange format deserializer.</summary>
    public class Deserializer
    {
        private Reader r;
        private List<TypeConverter> genericConverters;

        public Deserializer(Reader r, List<TypeConverter> genericConverters)
        {
            this.r = r;
            this.genericConverters = genericConverters;
        }

        public sbyte DeserializeI8() => r.ReadI8();
        public short DeserializeI16() => r.ReadI16();
        public int DeserializeI32() => r.ReadI32();
        public byte DeserializeU8() => r.ReadU8();
        public ushort DeserializeU16() => r.ReadU16();
        public uint DeserializeU32() => r.ReadU32();
        public ulong DeserializeU64() => r.ReadU64();
        public float DeserializeF32() => r.ReadF32();
        public bool DeserializeBool() => r.ReadBool();
        public byte[] DeserializeBytes() => r.ReadBytes();
        public DateTime DeserializeDateTime()
        {
            var s = r.ReadStr();
            return DateTime.ParseExact(
                s,
                "yyyy-MM-dd'T'HH:mm:ssK",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None);
        }

        public string DeserializeString() => r.ReadStr();

        private T? DeserializeValOptionInner<T>(Func<T> read) where T : struct
        {
            if (r.ReadOption())
                return read();
            else
                return null;
        }

        public Func<T?> DeserializeValOption<T>(Func<T> read) where T : struct => () => DeserializeValOptionInner(read);

        private T? DeserializeRefOptionInner<T>(Func<T> read) where T : class
        {
            if (r.ReadOption())
                return read();
            else
                return null;
        }

        public Func<T?> DeserializeRefOption<T>(Func<T> read) where T : class => () => DeserializeRefOptionInner(read);

        private List<T> DeserializeVecInner<T>(Func<T> read)
        {
            var len = r.ReadSeqSized();
            var vec = new List<T>((int)len);
            for (ulong i = 0; i < len; i++)
            {
                vec.Add(read());
            }
            return vec;
        }

        public Func<List<T>> DeserializeVec<T>(Func<T> read) => () => DeserializeVecInner(read);

        public Func<T> Deserialize<T>(TypeConverter<T> converter) => () => converter.Deserialize(this);

        private object DeserializeGeneric(Type type)
        {
            foreach (var converter in genericConverters)
                if (converter.Type == type)
                    return converter.Deserialize(this);
            throw new UnknownGenericTypeException(type);
        }

        public Func<T> DeserializeGeneric<T>() where T : notnull
        {
            var type = typeof(T);
            return () => (T)DeserializeGeneric(type);
        }

        public IEnumerable<string> DeserializeStruct()
        {
            var len = r.ReadStruct();
            for (ulong i = 0; i < len; i++)
            {
                var fieldName = r.ReadStr();
                yield return fieldName;
            }
        }

        public (EnumType, uint) DeserializeEnum() => r.ReadEnum();

        public uint DeserializeUnitVariant(string name)
        {
            var (enumType, variantIndex) = r.ReadEnum();
            if (enumType != EnumType.Unit)
                throw new InvalidVariantException(name, EnumType.Unit, enumType);
            return variantIndex;
        }
    }
}
