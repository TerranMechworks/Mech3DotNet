using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Nodes.Converters
{
    public class TransformationConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Nodes.Transformation>
    {
        protected override Mech3DotNet.Json.Gamez.Nodes.Transformation ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var rotationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
            var translationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3>();
            var matrixField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Matrix?>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "rotation":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            rotationField.Set(__value);
                            break;
                        }
                    case "translation":
                        {
                            Mech3DotNet.Json.Types.Vec3 __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3>(ref __reader, __options);
                            translationField.Set(__value);
                            break;
                        }
                    case "matrix":
                        {
                            Mech3DotNet.Json.Types.Matrix? __value = ReadFieldValue<Mech3DotNet.Json.Types.Matrix?>(ref __reader, __options);
                            matrixField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Transformation'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var rotation = rotationField.Unwrap("rotation");
            var translation = translationField.Unwrap("translation");
            var matrix = matrixField.Unwrap("matrix");
            return new Mech3DotNet.Json.Gamez.Nodes.Transformation(rotation, translation, matrix);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Nodes.Transformation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("rotation");
            JsonSerializer.Serialize(writer, value.rotation, options);
            writer.WritePropertyName("translation");
            JsonSerializer.Serialize(writer, value.translation, options);
            writer.WritePropertyName("matrix");
            JsonSerializer.Serialize(writer, value.matrix, options);
            writer.WriteEndObject();
        }
    }
}
