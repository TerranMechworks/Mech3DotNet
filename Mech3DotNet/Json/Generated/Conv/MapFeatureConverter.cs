using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MapFeatureConverter : StructConverter<MapFeature>
    {
        protected override MapFeature ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var colorField = new Option<MapColor>();
            var verticesField = new Option<List<MapVertex>>();
            var objectiveField = new Option<int>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "color":
                        {
                            MapColor __value = ReadFieldValue<MapColor>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "vertices":
                        {
                            List<MapVertex>? __value = ReadFieldValue<List<MapVertex>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'vertices' was null for 'MapFeature'");
                                throw new JsonException();
                            }
                            verticesField.Set(__value);
                            break;
                        }
                    case "objective":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            objectiveField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MapFeature'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var color = colorField.Unwrap("color");
            var vertices = verticesField.Unwrap("vertices");
            var objective = objectiveField.Unwrap("objective");
            return new MapFeature(color, vertices, objective);
        }

        public override void Write(Utf8JsonWriter writer, MapFeature value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("vertices");
            JsonSerializer.Serialize(writer, value.vertices, options);
            writer.WritePropertyName("objective");
            JsonSerializer.Serialize(writer, value.objective, options);
            writer.WriteEndObject();
        }
    }
}
