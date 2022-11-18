using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Mesh.Rc.Converters
{
    public class PolygonRcConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Mesh.Rc.PolygonRc>
    {
        protected override Mech3DotNet.Json.Gamez.Mesh.Rc.PolygonRc ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var vertexIndicesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<uint>>();
            var normalIndicesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<uint>?>();
            var uvCoordsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>?>();
            var textureIndexField = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk0FlagField = new Mech3DotNet.Json.Converters.Option<bool>();
            var unk04Field = new Mech3DotNet.Json.Converters.Option<int>();
            var unk24Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var verticesPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var normalsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var uvsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "vertex_indices":
                        {
                            System.Collections.Generic.List<uint>? __value = ReadFieldValue<System.Collections.Generic.List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'vertex_indices' was null for 'PolygonRc'");
                                throw new JsonException();
                            }
                            vertexIndicesField.Set(__value);
                            break;
                        }
                    case "normal_indices":
                        {
                            System.Collections.Generic.List<uint>? __value = ReadFieldValue<System.Collections.Generic.List<uint>?>(ref __reader, __options);
                            normalIndicesField.Set(__value);
                            break;
                        }
                    case "uv_coords":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.UvCoord>?>(ref __reader, __options);
                            uvCoordsField.Set(__value);
                            break;
                        }
                    case "texture_index":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            textureIndexField.Set(__value);
                            break;
                        }
                    case "unk0_flag":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk0FlagField.Set(__value);
                            break;
                        }
                    case "unk04":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            unk04Field.Set(__value);
                            break;
                        }
                    case "unk24":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk24Field.Set(__value);
                            break;
                        }
                    case "vertices_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            verticesPtrField.Set(__value);
                            break;
                        }
                    case "normals_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            normalsPtrField.Set(__value);
                            break;
                        }
                    case "uvs_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            uvsPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PolygonRc'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var vertexIndices = vertexIndicesField.Unwrap("vertex_indices");
            var normalIndices = normalIndicesField.Unwrap("normal_indices");
            var uvCoords = uvCoordsField.Unwrap("uv_coords");
            var textureIndex = textureIndexField.Unwrap("texture_index");
            var unk0Flag = unk0FlagField.Unwrap("unk0_flag");
            var unk04 = unk04Field.Unwrap("unk04");
            var unk24 = unk24Field.Unwrap("unk24");
            var verticesPtr = verticesPtrField.Unwrap("vertices_ptr");
            var normalsPtr = normalsPtrField.Unwrap("normals_ptr");
            var uvsPtr = uvsPtrField.Unwrap("uvs_ptr");
            return new Mech3DotNet.Json.Gamez.Mesh.Rc.PolygonRc(vertexIndices, normalIndices, uvCoords, textureIndex, unk0Flag, unk04, unk24, verticesPtr, normalsPtr, uvsPtr);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Mesh.Rc.PolygonRc value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("vertex_indices");
            JsonSerializer.Serialize(writer, value.vertexIndices, options);
            writer.WritePropertyName("normal_indices");
            JsonSerializer.Serialize(writer, value.normalIndices, options);
            writer.WritePropertyName("uv_coords");
            JsonSerializer.Serialize(writer, value.uvCoords, options);
            writer.WritePropertyName("texture_index");
            JsonSerializer.Serialize(writer, value.textureIndex, options);
            writer.WritePropertyName("unk0_flag");
            JsonSerializer.Serialize(writer, value.unk0Flag, options);
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("unk24");
            JsonSerializer.Serialize(writer, value.unk24, options);
            writer.WritePropertyName("vertices_ptr");
            JsonSerializer.Serialize(writer, value.verticesPtr, options);
            writer.WritePropertyName("normals_ptr");
            JsonSerializer.Serialize(writer, value.normalsPtr, options);
            writer.WritePropertyName("uvs_ptr");
            JsonSerializer.Serialize(writer, value.uvsPtr, options);
            writer.WriteEndObject();
        }
    }
}
