using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace Mech3DotNet.Json
{
    public class NegativeZeroFloatConverter : JsonConverter
    {
        public static uint FloatToUInt32Bits(float value) =>
            BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);

        public const float NEGATIVE_ZERO_FLOAT = -0f;
        public const string NEGATIVE_ZERO_STRING = "-0.0";
        public const string NEGATIVE_ZERO_REPLACE = "\"-0.0\"";
        public static readonly uint NEGATIVE_ZERO_BITS = FloatToUInt32Bits(NEGATIVE_ZERO_FLOAT);

        private static readonly JsonSerializer defaultSerializer = new JsonSerializer();

        public static string EncodeNegativeZero(string json)
        {
            return Regex.Replace(json, @"-0\.0(?=[^0-9]|$)", NEGATIVE_ZERO_REPLACE);
        }

        public static string DecodeNegativeZero(string json)
        {
            return json.Replace(NEGATIVE_ZERO_REPLACE, NEGATIVE_ZERO_STRING);
        }

        public override bool CanConvert(Type objectType)
        {
            var type = Nullable.GetUnderlyingType(objectType) ?? objectType;
            return type == typeof(float);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String && (string)reader.Value == NEGATIVE_ZERO_STRING)
                return NEGATIVE_ZERO_FLOAT;
            return defaultSerializer.Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var number = (float)value;
            if (number == 0f)
            {
                var bits = FloatToUInt32Bits(number);
                if (bits == NEGATIVE_ZERO_BITS)
                    writer.WriteValue(NEGATIVE_ZERO_STRING);
                else
                    writer.WriteValue(number);
            }
            else
                writer.WriteValue(number);
        }

        public override bool CanRead { get => true; }
        public override bool CanWrite { get => true; }
    }
}

