using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using static Mech3DotNet.Json.Helpers;

namespace Mech3DotNet.Json
{
    public class TupleException : Exception
    {
        public TupleException(string message) : base(message) { }
    }

    public class TupleMissingConstructorException : TupleException
    {
        public TupleMissingConstructorException(string message) : base(message) { }
    }

    public class TupleTooManyAttributesException : TupleException
    {
        public TupleTooManyAttributesException(string message) : base(message) { }
    }

    public class TupleConverter<T> : JsonConverter
    {
        protected class Introspector
        {
            public readonly Type type;
            public readonly int fieldCount;
            public readonly List<FieldInfo> fieldInfos;
            public readonly ConstructorInfo constructor;

            public Introspector()
            {
                type = typeof(T);

                fieldInfos = new List<FieldInfo>();
                // fields seem to be in the order they're declared (which is good)
                foreach (var fieldInfo in type.GetFields())
                    fieldInfos.Add(fieldInfo);
                fieldCount = fieldInfos.Count;

                ConstructorInfo? constructor = null;
                foreach (var ctorInfo in type.GetConstructors())
                {
                    var paramInfos = ctorInfo.GetParameters();
                    if (fieldCount == paramInfos.Length)
                    {
                        bool matches = true;
                        for (var i = 0; i < fieldCount; i++)
                        {
                            if (fieldInfos[i].FieldType != paramInfos[i].ParameterType)
                            {
                                matches = false;
                                break;
                            }
                        }
                        if (matches)
                        {
                            constructor = ctorInfo;
                            break;
                        }
                    }
                }

                if (constructor == null)
                    throw new TupleMissingConstructorException(
                        $"Type '{type}' contains no constructor matching all fields");
                this.constructor = constructor;
            }
        }

        protected static Introspector introspector = new Introspector();

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

            var parameters = new List<object>(introspector.fieldCount);
            var prevPath = reader.Path;
            for (var i = 0; i < introspector.fieldCount; i++)
            {
                if (reader.TokenType == JsonToken.EndArray)
                    throw new JsonReaderException(
                        AddPath(reader, prevPath, $"Too few elements for {introspector.type.Name}"));

                var fieldInfo = introspector.fieldInfos[i];
                var fieldValue = serializer.Deserialize(reader, fieldInfo.FieldType);
                parameters.Add(fieldValue);

                prevPath = reader.Path;
                if (!reader.Read())
                    throw new JsonSerializationException(
                        AddPath(reader, "Unexpected end when deserializing array"));
            }

            if (reader.TokenType != JsonToken.EndArray)
                throw new JsonReaderException(
                    AddPath(reader, $"Too many elements for {introspector.type.Name}"));

            return introspector.constructor.Invoke(parameters.ToArray());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            foreach (var fieldInfo in introspector.fieldInfos)
            {
                var fieldValue = fieldInfo.GetValue(value);
                serializer.Serialize(writer, fieldValue);
            }
            writer.WriteEndArray();
        }

        public override bool CanRead { get => true; }
        public override bool CanWrite { get => true; }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
    }
}
