using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PolygonNgConverter : StructConverter<PolygonNg>
    {
        protected override PolygonNg ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var flagsField = new Option<PolygonFlags>();
            var vertexIndicesField = new Option<List<uint>>();
            var vertexColorsField = new Option<List<Color>>();
            var normalIndicesField = new Option<List<uint>?>();
            var texturesField = new Option<List<PolygonTextureNg>>();
            var unk04Field = new Option<int>();
            var verticesPtrField = new Option<uint>();
            var normalsPtrField = new Option<uint>();
            var uvsPtrField = new Option<uint>();
            var colorsPtrField = new Option<uint>();
            var unk28Field = new Option<uint>();
            var unk32Field = new Option<uint>();
            var unk36Field = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "flags":
                        {
                            PolygonFlags? __value = ReadFieldValue<PolygonFlags?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'flags' was null for 'PolygonNg'");
                                throw new JsonException();
                            }
                            flagsField.Set(__value);
                            break;
                        }
                    case "vertex_indices":
                        {
                            List<uint>? __value = ReadFieldValue<List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'vertex_indices' was null for 'PolygonNg'");
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
                                System.Diagnostics.Debug.WriteLine("Value of 'vertex_colors' was null for 'PolygonNg'");
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
                    case "textures":
                        {
                            List<PolygonTextureNg>? __value = ReadFieldValue<List<PolygonTextureNg>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'textures' was null for 'PolygonNg'");
                                throw new JsonException();
                            }
                            texturesField.Set(__value);
                            break;
                        }
                    case "unk04":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            unk04Field.Set(__value);
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
                    case "unk28":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk28Field.Set(__value);
                            break;
                        }
                    case "unk32":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk32Field.Set(__value);
                            break;
                        }
                    case "unk36":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk36Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PolygonNg'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var flags = flagsField.Unwrap("flags");
            var vertexIndices = vertexIndicesField.Unwrap("vertex_indices");
            var vertexColors = vertexColorsField.Unwrap("vertex_colors");
            var normalIndices = normalIndicesField.Unwrap("normal_indices");
            var textures = texturesField.Unwrap("textures");
            var unk04 = unk04Field.Unwrap("unk04");
            var verticesPtr = verticesPtrField.Unwrap("vertices_ptr");
            var normalsPtr = normalsPtrField.Unwrap("normals_ptr");
            var uvsPtr = uvsPtrField.Unwrap("uvs_ptr");
            var colorsPtr = colorsPtrField.Unwrap("colors_ptr");
            var unk28 = unk28Field.Unwrap("unk28");
            var unk32 = unk32Field.Unwrap("unk32");
            var unk36 = unk36Field.Unwrap("unk36");
            return new PolygonNg(flags, vertexIndices, vertexColors, normalIndices, textures, unk04, verticesPtr, normalsPtr, uvsPtr, colorsPtr, unk28, unk32, unk36);
        }

        public override void Write(Utf8JsonWriter writer, PolygonNg value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("flags");
            JsonSerializer.Serialize(writer, value.flags, options);
            writer.WritePropertyName("vertex_indices");
            JsonSerializer.Serialize(writer, value.vertexIndices, options);
            writer.WritePropertyName("vertex_colors");
            JsonSerializer.Serialize(writer, value.vertexColors, options);
            writer.WritePropertyName("normal_indices");
            JsonSerializer.Serialize(writer, value.normalIndices, options);
            writer.WritePropertyName("textures");
            JsonSerializer.Serialize(writer, value.textures, options);
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("vertices_ptr");
            JsonSerializer.Serialize(writer, value.verticesPtr, options);
            writer.WritePropertyName("normals_ptr");
            JsonSerializer.Serialize(writer, value.normalsPtr, options);
            writer.WritePropertyName("uvs_ptr");
            JsonSerializer.Serialize(writer, value.uvsPtr, options);
            writer.WritePropertyName("colors_ptr");
            JsonSerializer.Serialize(writer, value.colorsPtr, options);
            writer.WritePropertyName("unk28");
            JsonSerializer.Serialize(writer, value.unk28, options);
            writer.WritePropertyName("unk32");
            JsonSerializer.Serialize(writer, value.unk32, options);
            writer.WritePropertyName("unk36");
            JsonSerializer.Serialize(writer, value.unk36, options);
            writer.WriteEndObject();
        }
    }
}
