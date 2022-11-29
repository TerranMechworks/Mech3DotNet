using System;

namespace Mech3DotNet.Exchange
{
    public readonly struct TypeConverter
    {
        public readonly Type Type;
        public readonly Func<Deserializer, object> Deserialize;
        public readonly Action<object, Serializer> Serialize;

        public TypeConverter(Type type, Func<Deserializer, object> deserialize, Action<object, Serializer> serialize)
        {
            Type = type;
            Deserialize = deserialize;
            Serialize = serialize;
        }

        public static TypeConverter From<T>(TypeConverter<T> converter) where T : notnull
        {
            var type = typeof(T);
            Func<Deserializer, object> deserialize = (Deserializer d) => converter.Deserialize(d);
            Action<object, Serializer> serialize = (object v, Serializer s) =>
            {
                if (v is T o)
                    converter.Serialize(o, s);
                else
                    throw new ArgumentException($"Expected value of type {typeof(T)}, but was {v.GetType()}");
            };
            return new TypeConverter(type, deserialize, serialize);
        }
    }

    public readonly struct TypeConverter<T>
    {
        public readonly Func<Deserializer, T> Deserialize;
        public readonly Action<T, Serializer> Serialize;

        public TypeConverter(Func<Deserializer, T> deserialize, Action<T, Serializer> serialize)
        {
            Deserialize = deserialize;
            Serialize = serialize;
        }
    }
}
