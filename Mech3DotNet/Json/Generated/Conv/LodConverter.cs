using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class LodConverter : StructConverter<Lod>
    {
        protected override Lod ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var levelField = new Option<bool>();
            var rangeField = new Option<Range>();
            var unk60Field = new Option<float>();
            var unk76Field = new Option<uint?>();
            var flagsField = new Option<NodeFlags>();
            var zoneIdField = new Option<uint>();
            var areaPartitionField = new Option<AreaPartition?>();
            var parentField = new Option<uint>();
            var childrenField = new Option<List<uint>>();
            var dataPtrField = new Option<uint>();
            var parentArrayPtrField = new Option<uint>();
            var childrenArrayPtrField = new Option<uint>();
            var unk116Field = new Option<BoundingBox>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Lod'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "level":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            levelField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "unk60":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk60Field.Set(__value);
                            break;
                        }
                    case "unk76":
                        {
                            uint? __value = ReadFieldValue<uint?>(ref __reader, __options);
                            unk76Field.Set(__value);
                            break;
                        }
                    case "flags":
                        {
                            NodeFlags? __value = ReadFieldValue<NodeFlags?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'flags' was null for 'Lod'");
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
                            AreaPartition? __value = ReadFieldValue<AreaPartition?>(ref __reader, __options);
                            areaPartitionField.Set(__value);
                            break;
                        }
                    case "parent":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentField.Set(__value);
                            break;
                        }
                    case "children":
                        {
                            List<uint>? __value = ReadFieldValue<List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'children' was null for 'Lod'");
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
                            BoundingBox? __value = ReadFieldValue<BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk116' was null for 'Lod'");
                                throw new JsonException();
                            }
                            unk116Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Lod'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var level = levelField.Unwrap("level");
            var range = rangeField.Unwrap("range");
            var unk60 = unk60Field.Unwrap("unk60");
            var unk76 = unk76Field.Unwrap("unk76");
            var flags = flagsField.Unwrap("flags");
            var zoneId = zoneIdField.Unwrap("zone_id");
            var areaPartition = areaPartitionField.Unwrap("area_partition");
            var parent = parentField.Unwrap("parent");
            var children = childrenField.Unwrap("children");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            var parentArrayPtr = parentArrayPtrField.Unwrap("parent_array_ptr");
            var childrenArrayPtr = childrenArrayPtrField.Unwrap("children_array_ptr");
            var unk116 = unk116Field.Unwrap("unk116");
            return new Lod(name, level, range, unk60, unk76, flags, zoneId, areaPartition, parent, children, dataPtr, parentArrayPtr, childrenArrayPtr, unk116);
        }

        public override void Write(Utf8JsonWriter writer, Lod value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("level");
            JsonSerializer.Serialize(writer, value.level, options);
            writer.WritePropertyName("range");
            JsonSerializer.Serialize(writer, value.range, options);
            writer.WritePropertyName("unk60");
            JsonSerializer.Serialize(writer, value.unk60, options);
            writer.WritePropertyName("unk76");
            JsonSerializer.Serialize(writer, value.unk76, options);
            writer.WritePropertyName("flags");
            JsonSerializer.Serialize(writer, value.flags, options);
            writer.WritePropertyName("zone_id");
            JsonSerializer.Serialize(writer, value.zoneId, options);
            writer.WritePropertyName("area_partition");
            JsonSerializer.Serialize(writer, value.areaPartition, options);
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
            writer.WriteEndObject();
        }
    }
}
