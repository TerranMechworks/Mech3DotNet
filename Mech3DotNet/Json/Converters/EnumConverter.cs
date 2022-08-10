using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    /// <summary>
    /// A converter for enums (equivalent to C# enums)
    /// </summary>
    public abstract class EnumConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public abstract T ReadVariant(string? name);
        public abstract string WriteVariant(T value);

        public override bool HandleNull => false;

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException();
            var name = reader.GetString();
            return ReadVariant(name);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var name = WriteVariant(value);
            writer.WriteStringValue(name);
        }

        [System.Diagnostics.CodeAnalysis.DoesNotReturn]
        protected static T DebugAndThrow(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            throw new JsonException();
        }
    }
}
