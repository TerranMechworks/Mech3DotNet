using System;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class FailConverter<T> : JsonConverter
    {
        public class Fail : Exception
        {
            public Fail() : base() { }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new Fail();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new Fail();
        }

        public override bool CanRead { get => true; }
        public override bool CanWrite { get => true; }
    }
}

