using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    /// <summary>
    /// A converter for structs (equivalent to C# classes or structs)
    /// </summary>
    public abstract class StructConverter<T> : JsonConverter<T>
    {
        protected abstract T ReadStruct(ref Utf8JsonReader reader, JsonSerializerOptions options);

        public override bool HandleNull => false;

        protected static bool ReadFieldName(ref Utf8JsonReader reader, out string? fieldName)
        {
            // consume StartObject or prev value/load next token
            if (!reader.Read())
                throw new JsonException();

            if (reader.TokenType == JsonTokenType.EndObject)
            {
                fieldName = null;
                return false;
            }
            else
            {
                fieldName = reader.GetString();
                return true;
            }
        }

        protected static V ReadFieldValue<V>(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            // consume PropertyName/load next token
            if (!reader.Read())
                throw new JsonException();

            // it's okay to return null here. this function doesn't need to
            // know if the type is nullable or not; for non-nullable reference
            // types the inheriting converter will check.
            return JsonSerializer.Deserialize<V>(ref reader, options)!;
        }

        protected static V ReadFieldGeneric<V>(ref Utf8JsonReader reader, JsonSerializerOptions options, JsonConverter<V>? converter, Type valueType)
        {
            // consume PropertyName/load next token
            if (!reader.Read())
                throw new JsonException();

            // it's okay to return null here. this function doesn't need to
            // know if the type is nullable or not; for non-nullable reference
            // types the inheriting converter will check.
            if (converter != null)
                return converter.Read(ref reader, valueType, options)!;
            return JsonSerializer.Deserialize<V>(ref reader, options)!;
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // sanity check
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            return ReadStruct(ref reader, options);
        }
    }
}
