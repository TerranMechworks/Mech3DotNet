using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PolygonConverter : StructConverter<Polygon>
    {
        protected override Polygon ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var vertexIndicesField = new Option<List<uint>>();
            var vertexColorsField = new Option<List<Color>>();
            var normalIndicesField = new Option<List<uint>?>();
            var uvCoordsField = new Option<List<UvCoord>?>();
            var textureIndexField = new Option<uint>();
            var textureInfoField = new Option<uint>();
            var unk04Field = new Option<uint>();
            var unkBitField = new Option<bool>();
            var vtxBitField = new Option<bool>();
            var verticesPtrField = new Option<uint>();
            var normalsPtrField = new Option<uint>();
            var uvsPtrField = new Option<uint>();
            var colorsPtrField = new Option<uint>();
            var unkPtrField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "vertex_indices":
                        {
                            List<uint>? __value = ReadFieldValue<List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'vertex_indices' was null for 'Polygon'");
                                throw new JsonException();
                            }
                            vertexIndicesField.Set(__value);
                            break;
                        }
                    case "vertex_colors":
                        {
                            List<Color>? __value = ReadFieldValue<List<Color>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'vertex_colors' was null for 'Polygon'");
                                throw new JsonException();
                            }
                            vertexColorsField.Set(__value);
                            break;
                        }
                    case "normal_indices":
                        {
                            List<uint>? __value = ReadFieldValue<List<uint>?>(ref __reader, __options);
                            normalIndicesField.Set(__value);
                            break;
                        }
                    case "uv_coords":
                        {
                            List<UvCoord>? __value = ReadFieldValue<List<UvCoord>?>(ref __reader, __options);
                            uvCoordsField.Set(__value);
                            break;
                        }
                    case "texture_index":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            textureIndexField.Set(__value);
                            break;
                        }
                    case "texture_info":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            textureInfoField.Set(__value);
                            break;
                        }
                    case "unk04":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk04Field.Set(__value);
                            break;
                        }
                    case "unk_bit":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unkBitField.Set(__value);
                            break;
                        }
                    case "vtx_bit":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            vtxBitField.Set(__value);
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
                    case "colors_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            colorsPtrField.Set(__value);
                            break;
                        }
                    case "unk_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unkPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Polygon'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var vertexIndices = vertexIndicesField.Unwrap("vertex_indices");
            var vertexColors = vertexColorsField.Unwrap("vertex_colors");
            var normalIndices = normalIndicesField.Unwrap("normal_indices");
            var uvCoords = uvCoordsField.Unwrap("uv_coords");
            var textureIndex = textureIndexField.Unwrap("texture_index");
            var textureInfo = textureInfoField.Unwrap("texture_info");
            var unk04 = unk04Field.Unwrap("unk04");
            var unkBit = unkBitField.Unwrap("unk_bit");
            var vtxBit = vtxBitField.Unwrap("vtx_bit");
            var verticesPtr = verticesPtrField.Unwrap("vertices_ptr");
            var normalsPtr = normalsPtrField.Unwrap("normals_ptr");
            var uvsPtr = uvsPtrField.Unwrap("uvs_ptr");
            var colorsPtr = colorsPtrField.Unwrap("colors_ptr");
            var unkPtr = unkPtrField.Unwrap("unk_ptr");
            return new Polygon(vertexIndices, vertexColors, normalIndices, uvCoords, textureIndex, textureInfo, unk04, unkBit, vtxBit, verticesPtr, normalsPtr, uvsPtr, colorsPtr, unkPtr);
        }

        public override void Write(Utf8JsonWriter writer, Polygon value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("vertex_indices");
            JsonSerializer.Serialize(writer, value.vertexIndices, options);
            writer.WritePropertyName("vertex_colors");
            JsonSerializer.Serialize(writer, value.vertexColors, options);
            writer.WritePropertyName("normal_indices");
            JsonSerializer.Serialize(writer, value.normalIndices, options);
            writer.WritePropertyName("uv_coords");
            JsonSerializer.Serialize(writer, value.uvCoords, options);
            writer.WritePropertyName("texture_index");
            JsonSerializer.Serialize(writer, value.textureIndex, options);
            writer.WritePropertyName("texture_info");
            JsonSerializer.Serialize(writer, value.textureInfo, options);
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("unk_bit");
            JsonSerializer.Serialize(writer, value.unkBit, options);
            writer.WritePropertyName("vtx_bit");
            JsonSerializer.Serialize(writer, value.vtxBit, options);
            writer.WritePropertyName("vertices_ptr");
            JsonSerializer.Serialize(writer, value.verticesPtr, options);
            writer.WritePropertyName("normals_ptr");
            JsonSerializer.Serialize(writer, value.normalsPtr, options);
            writer.WritePropertyName("uvs_ptr");
            JsonSerializer.Serialize(writer, value.uvsPtr, options);
            writer.WritePropertyName("colors_ptr");
            JsonSerializer.Serialize(writer, value.colorsPtr, options);
            writer.WritePropertyName("unk_ptr");
            JsonSerializer.Serialize(writer, value.unkPtr, options);
            writer.WriteEndObject();
        }
    }
}
