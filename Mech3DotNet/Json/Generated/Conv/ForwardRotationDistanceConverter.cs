using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ForwardRotationDistanceConverter : StructConverter<ForwardRotationDistance>
    {
        protected override ForwardRotationDistance ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var v1Field = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "v1":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            v1Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ForwardRotationDistance'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var v1 = v1Field.Unwrap("v1");
            return new ForwardRotationDistance(v1);
        }

        public override void Write(Utf8JsonWriter writer, ForwardRotationDistance value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("v1");
            JsonSerializer.Serialize(writer, value.v1, options);
            writer.WriteEndObject();
        }
    }
}
