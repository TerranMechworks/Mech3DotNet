using System.Text.Json;

namespace Mech3DotNet.Json.Zmap.Converters
{
    public class MapFeatureConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Zmap.MapFeature>
    {
        protected override Mech3DotNet.Json.Zmap.MapFeature ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var colorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Zmap.MapColor>();
            var verticesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapVertex>>();
            var objectiveField = new Mech3DotNet.Json.Converters.Option<int>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "color":
                        {
                            Mech3DotNet.Json.Zmap.MapColor __value = ReadFieldValue<Mech3DotNet.Json.Zmap.MapColor>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "vertices":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapVertex>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapVertex>?>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Zmap.MapFeature(color, vertices, objective);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Zmap.MapFeature value, JsonSerializerOptions options)
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
