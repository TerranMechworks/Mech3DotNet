using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Nodes.Converters
{
    public class Object3dConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Nodes.Object3d>
    {
        protected override Mech3DotNet.Json.Gamez.Nodes.Object3d ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var transformationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Nodes.Transformation?>();
            var matrixSignsField = new Mech3DotNet.Json.Converters.Option<uint>();
            var flagsField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Nodes.NodeFlags>();
            var zoneIdField = new Mech3DotNet.Json.Converters.Option<uint>();
            var areaPartitionField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Nodes.AreaPartition?>();
            var meshIndexField = new Mech3DotNet.Json.Converters.Option<int>();
            var parentField = new Mech3DotNet.Json.Converters.Option<uint?>();
            var childrenField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<uint>>();
            var dataPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var parentArrayPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var childrenArrayPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk116Field = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Nodes.BoundingBox>();
            var unk140Field = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Nodes.BoundingBox>();
            var unk164Field = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Gamez.Nodes.BoundingBox>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "name":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Object3d'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "transformation":
                        {
                            Mech3DotNet.Json.Gamez.Nodes.Transformation? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Nodes.Transformation?>(ref __reader, __options);
                            transformationField.Set(__value);
                            break;
                        }
                    case "matrix_signs":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            matrixSignsField.Set(__value);
                            break;
                        }
                    case "flags":
                        {
                            Mech3DotNet.Json.Gamez.Nodes.NodeFlags? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Nodes.NodeFlags?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'flags' was null for 'Object3d'");
                                throw new JsonException();
                            }
                            flagsField.Set(__value);
                            break;
                        }
                    case "zone_id":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            zoneIdField.Set(__value);
                            break;
                        }
                    case "area_partition":
                        {
                            Mech3DotNet.Json.Gamez.Nodes.AreaPartition? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Nodes.AreaPartition?>(ref __reader, __options);
                            areaPartitionField.Set(__value);
                            break;
                        }
                    case "mesh_index":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            meshIndexField.Set(__value);
                            break;
                        }
                    case "parent":
                        {
                            uint? __value = ReadFieldValue<uint?>(ref __reader, __options);
                            parentField.Set(__value);
                            break;
                        }
                    case "children":
                        {
                            System.Collections.Generic.List<uint>? __value = ReadFieldValue<System.Collections.Generic.List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'children' was null for 'Object3d'");
                                throw new JsonException();
                            }
                            childrenField.Set(__value);
                            break;
                        }
                    case "data_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            dataPtrField.Set(__value);
                            break;
                        }
                    case "parent_array_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentArrayPtrField.Set(__value);
                            break;
                        }
                    case "children_array_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            childrenArrayPtrField.Set(__value);
                            break;
                        }
                    case "unk116":
                        {
                            Mech3DotNet.Json.Gamez.Nodes.BoundingBox? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Nodes.BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk116' was null for 'Object3d'");
                                throw new JsonException();
                            }
                            unk116Field.Set(__value);
                            break;
                        }
                    case "unk140":
                        {
                            Mech3DotNet.Json.Gamez.Nodes.BoundingBox? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Nodes.BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk140' was null for 'Object3d'");
                                throw new JsonException();
                            }
                            unk140Field.Set(__value);
                            break;
                        }
                    case "unk164":
                        {
                            Mech3DotNet.Json.Gamez.Nodes.BoundingBox? __value = ReadFieldValue<Mech3DotNet.Json.Gamez.Nodes.BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk164' was null for 'Object3d'");
                                throw new JsonException();
                            }
                            unk164Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Object3d'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var transformation = transformationField.Unwrap("transformation");
            var matrixSigns = matrixSignsField.Unwrap("matrix_signs");
            var flags = flagsField.Unwrap("flags");
            var zoneId = zoneIdField.Unwrap("zone_id");
            var areaPartition = areaPartitionField.Unwrap("area_partition");
            var meshIndex = meshIndexField.Unwrap("mesh_index");
            var parent = parentField.Unwrap("parent");
            var children = childrenField.Unwrap("children");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            var parentArrayPtr = parentArrayPtrField.Unwrap("parent_array_ptr");
            var childrenArrayPtr = childrenArrayPtrField.Unwrap("children_array_ptr");
            var unk116 = unk116Field.Unwrap("unk116");
            var unk140 = unk140Field.Unwrap("unk140");
            var unk164 = unk164Field.Unwrap("unk164");
            return new Mech3DotNet.Json.Gamez.Nodes.Object3d(name, transformation, matrixSigns, flags, zoneId, areaPartition, meshIndex, parent, children, dataPtr, parentArrayPtr, childrenArrayPtr, unk116, unk140, unk164);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Nodes.Object3d value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("transformation");
            JsonSerializer.Serialize(writer, value.transformation, options);
            writer.WritePropertyName("matrix_signs");
            JsonSerializer.Serialize(writer, value.matrixSigns, options);
            writer.WritePropertyName("flags");
            JsonSerializer.Serialize(writer, value.flags, options);
            writer.WritePropertyName("zone_id");
            JsonSerializer.Serialize(writer, value.zoneId, options);
            writer.WritePropertyName("area_partition");
            JsonSerializer.Serialize(writer, value.areaPartition, options);
            writer.WritePropertyName("mesh_index");
            JsonSerializer.Serialize(writer, value.meshIndex, options);
            writer.WritePropertyName("parent");
            JsonSerializer.Serialize(writer, value.parent, options);
            writer.WritePropertyName("children");
            JsonSerializer.Serialize(writer, value.children, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WritePropertyName("parent_array_ptr");
            JsonSerializer.Serialize(writer, value.parentArrayPtr, options);
            writer.WritePropertyName("children_array_ptr");
            JsonSerializer.Serialize(writer, value.childrenArrayPtr, options);
            writer.WritePropertyName("unk116");
            JsonSerializer.Serialize(writer, value.unk116, options);
            writer.WritePropertyName("unk140");
            JsonSerializer.Serialize(writer, value.unk140, options);
            writer.WritePropertyName("unk164");
            JsonSerializer.Serialize(writer, value.unk164, options);
            writer.WriteEndObject();
        }
    }
}
