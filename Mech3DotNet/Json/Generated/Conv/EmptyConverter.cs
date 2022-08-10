using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class EmptyConverter : StructConverter<Empty>
    {
        protected override Empty ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var flagsField = new Option<NodeFlags>();
            var unk044Field = new Option<uint>();
            var zoneIdField = new Option<uint>();
            var unk116Field = new Option<BoundingBox>();
            var unk140Field = new Option<BoundingBox>();
            var unk164Field = new Option<BoundingBox>();
            var parentField = new Option<uint>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'Empty'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "flags":
                        {
                            NodeFlags? __value = ReadFieldValue<NodeFlags?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'flags' was null for 'Empty'");
                                throw new JsonException();
                            }
                            flagsField.Set(__value);
                            break;
                        }
                    case "unk044":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk044Field.Set(__value);
                            break;
                        }
                    case "zone_id":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            zoneIdField.Set(__value);
                            break;
                        }
                    case "unk116":
                        {
                            BoundingBox? __value = ReadFieldValue<BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk116' was null for 'Empty'");
                                throw new JsonException();
                            }
                            unk116Field.Set(__value);
                            break;
                        }
                    case "unk140":
                        {
                            BoundingBox? __value = ReadFieldValue<BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk140' was null for 'Empty'");
                                throw new JsonException();
                            }
                            unk140Field.Set(__value);
                            break;
                        }
                    case "unk164":
                        {
                            BoundingBox? __value = ReadFieldValue<BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk164' was null for 'Empty'");
                                throw new JsonException();
                            }
                            unk164Field.Set(__value);
                            break;
                        }
                    case "parent":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Empty'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var flags = flagsField.Unwrap("flags");
            var unk044 = unk044Field.Unwrap("unk044");
            var zoneId = zoneIdField.Unwrap("zone_id");
            var unk116 = unk116Field.Unwrap("unk116");
            var unk140 = unk140Field.Unwrap("unk140");
            var unk164 = unk164Field.Unwrap("unk164");
            var parent = parentField.Unwrap("parent");
            return new Empty(name, flags, unk044, zoneId, unk116, unk140, unk164, parent);
        }

        public override void Write(Utf8JsonWriter writer, Empty value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("flags");
            JsonSerializer.Serialize(writer, value.flags, options);
            writer.WritePropertyName("unk044");
            JsonSerializer.Serialize(writer, value.unk044, options);
            writer.WritePropertyName("zone_id");
            JsonSerializer.Serialize(writer, value.zoneId, options);
            writer.WritePropertyName("unk116");
            JsonSerializer.Serialize(writer, value.unk116, options);
            writer.WritePropertyName("unk140");
            JsonSerializer.Serialize(writer, value.unk140, options);
            writer.WritePropertyName("unk164");
            JsonSerializer.Serialize(writer, value.unk164, options);
            writer.WritePropertyName("parent");
            JsonSerializer.Serialize(writer, value.parent, options);
            writer.WriteEndObject();
        }
    }
}
