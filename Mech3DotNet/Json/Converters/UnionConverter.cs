using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mech3DotNet.Json.Converters
{
    public interface IDiscriminatedUnion<E>
    {
        bool Is<T>() where T : class;
        T As<T>() where T : class;
        object GetValue();
        E Variant { get; }
    }

    public abstract class UnionConverter<T> : JsonConverter<T>
    {
        public abstract T ReadUnitVariant(string? name);
        public abstract T ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options);

        public override bool HandleNull => false;

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    {
                        var name = reader.GetString();
                        return ReadUnitVariant(name);
                    }
                case JsonTokenType.StartObject:
                    {
                        if (!reader.Read())
                            throw new JsonException();

                        // I don't know if this is allowed to happen?
                        if (reader.TokenType != JsonTokenType.PropertyName)
                            throw new JsonException();

                        var name = reader.GetString();

                        if (!reader.Read())
                            throw new JsonException();

                        var value = ReadStructVariant(ref reader, name, options);

                        if (!reader.Read())
                            throw new JsonException();

                        if (reader.TokenType != JsonTokenType.EndObject)
                            throw new JsonException();

                        return value;
                    }
                default:
                    throw new JsonException();
            }
        }
    }
}
