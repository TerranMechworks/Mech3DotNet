using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using static Mech3DotNet.Json.Helpers;

namespace Mech3DotNet.Json
{
    public class StructTupleConverter : JsonConverter
    {
        private Type type;
        private ConstructorInfo ctorInfo;
        private ParameterInfo[] paramInfos;

        public StructTupleConverter(Type type, Type[] constructorTypes)
        {
            this.type = type;
            this.ctorInfo = type.GetConstructor(constructorTypes) ?? throw new TupleMissingConstructorException("Constructor not found");
            this.paramInfos = this.ctorInfo.GetParameters();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType != JsonToken.StartArray)
                throw new JsonSerializationException(
                    AddPath(reader, $"Unexpected token when deserializing array: {reader.TokenType}"));

            if (!reader.Read())
                throw new JsonSerializationException(
                    AddPath(reader, "Unexpected end when deserializing array"));

            var parameters = new List<object>(paramInfos.Length);
            var prevPath = reader.Path;
            foreach (var paramInfo in paramInfos)
            {
                if (reader.TokenType == JsonToken.EndArray)
                    throw new JsonReaderException(
                        AddPath(reader, prevPath, $"Too few elements for {type.Name}"));

                var fieldValue = serializer.Deserialize(reader, paramInfo.ParameterType);
                parameters.Add(fieldValue);

                prevPath = reader.Path;
                if (!reader.Read())
                    throw new JsonSerializationException(
                        AddPath(reader, "Unexpected end when deserializing array"));
            }

            if (reader.TokenType != JsonToken.EndArray)
                throw new JsonReaderException(
                    AddPath(reader, $"Too many elements for {type.Name}"));

            return ctorInfo.Invoke(parameters.ToArray());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead { get => true; }
        public override bool CanWrite { get => false; }

        public override bool CanConvert(Type objectType)
        {
            return objectType == type;
        }
    }
}
