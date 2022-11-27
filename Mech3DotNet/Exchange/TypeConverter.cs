using System;

namespace Mech3DotNet.Exchange
{
    public struct TypeConverter
    {
        public Type Type;
        public Func<Deserializer, object> Deserialize;
        public Action<object, Serializer> Serialize;
    }

    public readonly struct TypeConverter<T>
    {
        public readonly Func<Deserializer, T> Deserialize;
        public readonly Action<T, Serializer> Serialize;

        public TypeConverter(Func<Deserializer, T> Deserialize, Action<T, Serializer> Serialize)
        {
            this.Deserialize = Deserialize;
            this.Serialize = Serialize;
        }
    }
}
