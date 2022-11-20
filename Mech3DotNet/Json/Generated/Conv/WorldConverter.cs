using System.Text.Json;

namespace Mech3DotNet.Json.Nodes.Mw.Converters
{
    public class WorldConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Nodes.Mw.World>
    {
        protected override Mech3DotNet.Json.Nodes.Mw.World ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var areaField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Nodes.Area>();
            var partitionsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Partition>>>();
            var areaPartitionXCountField = new Mech3DotNet.Json.Converters.Option<uint>();
            var areaPartitionYCountField = new Mech3DotNet.Json.Converters.Option<uint>();
            var fudgeCountField = new Mech3DotNet.Json.Converters.Option<bool>();
            var areaPartitionPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var virtPartitionPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var worldChildrenPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var worldChildValueField = new Mech3DotNet.Json.Converters.Option<uint>();
            var worldLightsPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var childrenField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<uint>>();
            var dataPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var childrenArrayPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'World'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "area":
                        {
                            Mech3DotNet.Json.Nodes.Area __value = ReadFieldValue<Mech3DotNet.Json.Nodes.Area>(ref __reader, __options);
                            areaField.Set(__value);
                            break;
                        }
                    case "partitions":
                        {
                            System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Partition>>? __value = ReadFieldValue<System.Collections.Generic.List<System.Collections.Generic.List<Mech3DotNet.Json.Nodes.Partition>>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'partitions' was null for 'World'");
                                throw new JsonException();
                            }
                            partitionsField.Set(__value);
                            break;
                        }
                    case "area_partition_x_count":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            areaPartitionXCountField.Set(__value);
                            break;
                        }
                    case "area_partition_y_count":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            areaPartitionYCountField.Set(__value);
                            break;
                        }
                    case "fudge_count":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            fudgeCountField.Set(__value);
                            break;
                        }
                    case "area_partition_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            areaPartitionPtrField.Set(__value);
                            break;
                        }
                    case "virt_partition_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            virtPartitionPtrField.Set(__value);
                            break;
                        }
                    case "world_children_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            worldChildrenPtrField.Set(__value);
                            break;
                        }
                    case "world_child_value":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            worldChildValueField.Set(__value);
                            break;
                        }
                    case "world_lights_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            worldLightsPtrField.Set(__value);
                            break;
                        }
                    case "children":
                        {
                            System.Collections.Generic.List<uint>? __value = ReadFieldValue<System.Collections.Generic.List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'children' was null for 'World'");
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
                    case "children_array_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            childrenArrayPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'World'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var area = areaField.Unwrap("area");
            var partitions = partitionsField.Unwrap("partitions");
            var areaPartitionXCount = areaPartitionXCountField.Unwrap("area_partition_x_count");
            var areaPartitionYCount = areaPartitionYCountField.Unwrap("area_partition_y_count");
            var fudgeCount = fudgeCountField.Unwrap("fudge_count");
            var areaPartitionPtr = areaPartitionPtrField.Unwrap("area_partition_ptr");
            var virtPartitionPtr = virtPartitionPtrField.Unwrap("virt_partition_ptr");
            var worldChildrenPtr = worldChildrenPtrField.Unwrap("world_children_ptr");
            var worldChildValue = worldChildValueField.Unwrap("world_child_value");
            var worldLightsPtr = worldLightsPtrField.Unwrap("world_lights_ptr");
            var children = childrenField.Unwrap("children");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            var childrenArrayPtr = childrenArrayPtrField.Unwrap("children_array_ptr");
            return new Mech3DotNet.Json.Nodes.Mw.World(name, area, partitions, areaPartitionXCount, areaPartitionYCount, fudgeCount, areaPartitionPtr, virtPartitionPtr, worldChildrenPtr, worldChildValue, worldLightsPtr, children, dataPtr, childrenArrayPtr);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Nodes.Mw.World value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("area");
            JsonSerializer.Serialize(writer, value.area, options);
            writer.WritePropertyName("partitions");
            JsonSerializer.Serialize(writer, value.partitions, options);
            writer.WritePropertyName("area_partition_x_count");
            JsonSerializer.Serialize(writer, value.areaPartitionXCount, options);
            writer.WritePropertyName("area_partition_y_count");
            JsonSerializer.Serialize(writer, value.areaPartitionYCount, options);
            writer.WritePropertyName("fudge_count");
            JsonSerializer.Serialize(writer, value.fudgeCount, options);
            writer.WritePropertyName("area_partition_ptr");
            JsonSerializer.Serialize(writer, value.areaPartitionPtr, options);
            writer.WritePropertyName("virt_partition_ptr");
            JsonSerializer.Serialize(writer, value.virtPartitionPtr, options);
            writer.WritePropertyName("world_children_ptr");
            JsonSerializer.Serialize(writer, value.worldChildrenPtr, options);
            writer.WritePropertyName("world_child_value");
            JsonSerializer.Serialize(writer, value.worldChildValue, options);
            writer.WritePropertyName("world_lights_ptr");
            JsonSerializer.Serialize(writer, value.worldLightsPtr, options);
            writer.WritePropertyName("children");
            JsonSerializer.Serialize(writer, value.children, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WritePropertyName("children_array_ptr");
            JsonSerializer.Serialize(writer, value.childrenArrayPtr, options);
            writer.WriteEndObject();
        }
    }
}
