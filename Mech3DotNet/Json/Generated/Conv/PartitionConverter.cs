using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PartitionConverter : StructConverter<Partition>
    {
        protected override Partition ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var xField = new Option<int>();
            var yField = new Option<int>();
            var zMinField = new Option<float>();
            var zMaxField = new Option<float>();
            var zMidField = new Option<float>();
            var nodesField = new Option<List<uint>>();
            var ptrField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "x":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            xField.Set(__value);
                            break;
                        }
                    case "y":
                        {
                            int __value = ReadFieldValue<int>(ref __reader, __options);
                            yField.Set(__value);
                            break;
                        }
                    case "z_min":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            zMinField.Set(__value);
                            break;
                        }
                    case "z_max":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            zMaxField.Set(__value);
                            break;
                        }
                    case "z_mid":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            zMidField.Set(__value);
                            break;
                        }
                    case "nodes":
                        {
                            List<uint>? __value = ReadFieldValue<List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'nodes' was null for 'Partition'");
                                throw new JsonException();
                            }
                            nodesField.Set(__value);
                            break;
                        }
                    case "ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            ptrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Partition'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var x = xField.Unwrap("x");
            var y = yField.Unwrap("y");
            var zMin = zMinField.Unwrap("z_min");
            var zMax = zMaxField.Unwrap("z_max");
            var zMid = zMidField.Unwrap("z_mid");
            var nodes = nodesField.Unwrap("nodes");
            var ptr = ptrField.Unwrap("ptr");
            return new Partition(x, y, zMin, zMax, zMid, nodes, ptr);
        }

        public override void Write(Utf8JsonWriter writer, Partition value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("x");
            JsonSerializer.Serialize(writer, value.x, options);
            writer.WritePropertyName("y");
            JsonSerializer.Serialize(writer, value.y, options);
            writer.WritePropertyName("z_min");
            JsonSerializer.Serialize(writer, value.zMin, options);
            writer.WritePropertyName("z_max");
            JsonSerializer.Serialize(writer, value.zMax, options);
            writer.WritePropertyName("z_mid");
            JsonSerializer.Serialize(writer, value.zMid, options);
            writer.WritePropertyName("nodes");
            JsonSerializer.Serialize(writer, value.nodes, options);
            writer.WritePropertyName("ptr");
            JsonSerializer.Serialize(writer, value.ptr, options);
            writer.WriteEndObject();
        }
    }
}
