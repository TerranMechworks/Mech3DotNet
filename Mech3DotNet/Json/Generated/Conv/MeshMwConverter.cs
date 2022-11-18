using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Mesh.Mw.Converters
{
    public class MeshMwConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw>
    {
        protected override Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var verticesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>>();
            var normalsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>>();
            var morphsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>>();
            var lightsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.MeshLight>>();
            var polygonsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.PolygonMw>>();
            var polygonsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var verticesPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var normalsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var lightsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var morphsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var filePtrField = new Mech3DotNet.Json.Converters.Option<bool>();
            var unk04Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk08Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var parentCountField = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk40Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk44Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk72Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk76Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk80Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk84Field = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "vertices":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'vertices' was null for 'MeshMw'");
                                throw new JsonException();
                            }
                            verticesField.Set(__value);
                            break;
                        }
                    case "normals":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'normals' was null for 'MeshMw'");
                                throw new JsonException();
                            }
                            normalsField.Set(__value);
                            break;
                        }
                    case "morphs":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Types.Vec3>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'morphs' was null for 'MeshMw'");
                                throw new JsonException();
                            }
                            morphsField.Set(__value);
                            break;
                        }
                    case "lights":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.MeshLight>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.MeshLight>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'lights' was null for 'MeshMw'");
                                throw new JsonException();
                            }
                            lightsField.Set(__value);
                            break;
                        }
                    case "polygons":
                        {
                            System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.PolygonMw>? __value = ReadFieldValue<System.Collections.Generic.List<Mech3DotNet.Json.Gamez.Mesh.Mw.PolygonMw>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'polygons' was null for 'MeshMw'");
                                throw new JsonException();
                            }
                            polygonsField.Set(__value);
                            break;
                        }
                    case "polygons_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            polygonsPtrField.Set(__value);
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
                    case "lights_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            lightsPtrField.Set(__value);
                            break;
                        }
                    case "morphs_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            morphsPtrField.Set(__value);
                            break;
                        }
                    case "file_ptr":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            filePtrField.Set(__value);
                            break;
                        }
                    case "unk04":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk04Field.Set(__value);
                            break;
                        }
                    case "unk08":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk08Field.Set(__value);
                            break;
                        }
                    case "parent_count":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentCountField.Set(__value);
                            break;
                        }
                    case "unk40":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk40Field.Set(__value);
                            break;
                        }
                    case "unk44":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk44Field.Set(__value);
                            break;
                        }
                    case "unk72":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk72Field.Set(__value);
                            break;
                        }
                    case "unk76":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk76Field.Set(__value);
                            break;
                        }
                    case "unk80":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk80Field.Set(__value);
                            break;
                        }
                    case "unk84":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk84Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MeshMw'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var vertices = verticesField.Unwrap("vertices");
            var normals = normalsField.Unwrap("normals");
            var morphs = morphsField.Unwrap("morphs");
            var lights = lightsField.Unwrap("lights");
            var polygons = polygonsField.Unwrap("polygons");
            var polygonsPtr = polygonsPtrField.Unwrap("polygons_ptr");
            var verticesPtr = verticesPtrField.Unwrap("vertices_ptr");
            var normalsPtr = normalsPtrField.Unwrap("normals_ptr");
            var lightsPtr = lightsPtrField.Unwrap("lights_ptr");
            var morphsPtr = morphsPtrField.Unwrap("morphs_ptr");
            var filePtr = filePtrField.Unwrap("file_ptr");
            var unk04 = unk04Field.Unwrap("unk04");
            var unk08 = unk08Field.Unwrap("unk08");
            var parentCount = parentCountField.Unwrap("parent_count");
            var unk40 = unk40Field.Unwrap("unk40");
            var unk44 = unk44Field.Unwrap("unk44");
            var unk72 = unk72Field.Unwrap("unk72");
            var unk76 = unk76Field.Unwrap("unk76");
            var unk80 = unk80Field.Unwrap("unk80");
            var unk84 = unk84Field.Unwrap("unk84");
            return new Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw(vertices, normals, morphs, lights, polygons, polygonsPtr, verticesPtr, normalsPtr, lightsPtr, morphsPtr, filePtr, unk04, unk08, parentCount, unk40, unk44, unk72, unk76, unk80, unk84);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Mesh.Mw.MeshMw value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("vertices");
            JsonSerializer.Serialize(writer, value.vertices, options);
            writer.WritePropertyName("normals");
            JsonSerializer.Serialize(writer, value.normals, options);
            writer.WritePropertyName("morphs");
            JsonSerializer.Serialize(writer, value.morphs, options);
            writer.WritePropertyName("lights");
            JsonSerializer.Serialize(writer, value.lights, options);
            writer.WritePropertyName("polygons");
            JsonSerializer.Serialize(writer, value.polygons, options);
            writer.WritePropertyName("polygons_ptr");
            JsonSerializer.Serialize(writer, value.polygonsPtr, options);
            writer.WritePropertyName("vertices_ptr");
            JsonSerializer.Serialize(writer, value.verticesPtr, options);
            writer.WritePropertyName("normals_ptr");
            JsonSerializer.Serialize(writer, value.normalsPtr, options);
            writer.WritePropertyName("lights_ptr");
            JsonSerializer.Serialize(writer, value.lightsPtr, options);
            writer.WritePropertyName("morphs_ptr");
            JsonSerializer.Serialize(writer, value.morphsPtr, options);
            writer.WritePropertyName("file_ptr");
            JsonSerializer.Serialize(writer, value.filePtr, options);
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("unk08");
            JsonSerializer.Serialize(writer, value.unk08, options);
            writer.WritePropertyName("parent_count");
            JsonSerializer.Serialize(writer, value.parentCount, options);
            writer.WritePropertyName("unk40");
            JsonSerializer.Serialize(writer, value.unk40, options);
            writer.WritePropertyName("unk44");
            JsonSerializer.Serialize(writer, value.unk44, options);
            writer.WritePropertyName("unk72");
            JsonSerializer.Serialize(writer, value.unk72, options);
            writer.WritePropertyName("unk76");
            JsonSerializer.Serialize(writer, value.unk76, options);
            writer.WritePropertyName("unk80");
            JsonSerializer.Serialize(writer, value.unk80, options);
            writer.WritePropertyName("unk84");
            JsonSerializer.Serialize(writer, value.unk84, options);
            writer.WriteEndObject();
        }
    }
}
