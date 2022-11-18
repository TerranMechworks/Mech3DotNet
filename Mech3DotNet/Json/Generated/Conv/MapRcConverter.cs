using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MapRcConverter : Mech3DotNet.Json.Converters.StructConverter<MapRc>
    {
        protected override MapRc ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var unk04Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var maxXField = new Mech3DotNet.Json.Converters.Option<float>();
            var maxYField = new Mech3DotNet.Json.Converters.Option<float>();
            var featuresField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<MapFeature>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "unk04":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk04Field.Set(__value);
                            break;
                        }
                    case "max_x":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            maxXField.Set(__value);
                            break;
                        }
                    case "max_y":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            maxYField.Set(__value);
                            break;
                        }
                    case "features":
                        {
                            System.Collections.Generic.List<MapFeature>? __value = ReadFieldValue<System.Collections.Generic.List<MapFeature>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'features' was null for 'MapRc'");
                                throw new JsonException();
                            }
                            featuresField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MapRc'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var unk04 = unk04Field.Unwrap("unk04");
            var maxX = maxXField.Unwrap("max_x");
            var maxY = maxYField.Unwrap("max_y");
            var features = featuresField.Unwrap("features");
            return new MapRc(unk04, maxX, maxY, features);
        }

        public override void Write(Utf8JsonWriter writer, MapRc value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("max_x");
            JsonSerializer.Serialize(writer, value.maxX, options);
            writer.WritePropertyName("max_y");
            JsonSerializer.Serialize(writer, value.maxY, options);
            writer.WritePropertyName("features");
            JsonSerializer.Serialize(writer, value.features, options);
            writer.WriteEndObject();
        }
    }
}
