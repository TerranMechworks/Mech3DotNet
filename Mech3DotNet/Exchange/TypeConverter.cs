using System;

namespace Mech3DotNet.Exchange
{
    /// <summary>
    /// A non-generic/dynamic type converter.
    ///
    /// Used for registering generic type conversions with a serializer or deserializer.
    /// </summary>
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

    /// <summary>
    /// A generic/static type converter.
    ///
    /// Used for defining exchange serialization and deserialization of a
    /// non-generic C# type.
    /// </summary>
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
