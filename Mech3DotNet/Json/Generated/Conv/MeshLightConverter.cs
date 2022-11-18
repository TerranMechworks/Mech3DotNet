using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MeshLightConverter : Mech3DotNet.Json.Converters.StructConverter<MeshLight>
    {
        protected override MeshLight ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var unk00Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk04Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk08Field = new Mech3DotNet.Json.Converters.Option<float>();
            var extraField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<Vec3>>();
            var unk24Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var colorField = new Mech3DotNet.Json.Converters.Option<Color>();
            var flagsField = new Mech3DotNet.Json.Converters.Option<ushort>();
            var ptrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk48Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk52Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk56Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk60Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk64Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk68Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk72Field = new Mech3DotNet.Json.Converters.Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "unk00":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk00Field.Set(__value);
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
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk08Field.Set(__value);
                            break;
                        }
                    case "extra":
                        {
                            System.Collections.Generic.List<Vec3>? __value = ReadFieldValue<System.Collections.Generic.List<Vec3>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'extra' was null for 'MeshLight'");
                                throw new JsonException();
                            }
                            extraField.Set(__value);
                            break;
                        }
                    case "unk24":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk24Field.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Color __value = ReadFieldValue<Color>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "flags":
                        {
                            ushort __value = ReadFieldValue<ushort>(ref __reader, __options);
                            flagsField.Set(__value);
                            break;
                        }
                    case "ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            ptrField.Set(__value);
                            break;
                        }
                    case "unk48":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk48Field.Set(__value);
                            break;
                        }
                    case "unk52":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk52Field.Set(__value);
                            break;
                        }
                    case "unk56":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk56Field.Set(__value);
                            break;
                        }
                    case "unk60":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk60Field.Set(__value);
                            break;
                        }
                    case "unk64":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk64Field.Set(__value);
                            break;
                        }
                    case "unk68":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk68Field.Set(__value);
                            break;
                        }
                    case "unk72":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk72Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'MeshLight'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var unk00 = unk00Field.Unwrap("unk00");
            var unk04 = unk04Field.Unwrap("unk04");
            var unk08 = unk08Field.Unwrap("unk08");
            var extra = extraField.Unwrap("extra");
            var unk24 = unk24Field.Unwrap("unk24");
            var color = colorField.Unwrap("color");
            var flags = flagsField.Unwrap("flags");
            var ptr = ptrField.Unwrap("ptr");
            var unk48 = unk48Field.Unwrap("unk48");
            var unk52 = unk52Field.Unwrap("unk52");
            var unk56 = unk56Field.Unwrap("unk56");
            var unk60 = unk60Field.Unwrap("unk60");
            var unk64 = unk64Field.Unwrap("unk64");
            var unk68 = unk68Field.Unwrap("unk68");
            var unk72 = unk72Field.Unwrap("unk72");
            return new MeshLight(unk00, unk04, unk08, extra, unk24, color, flags, ptr, unk48, unk52, unk56, unk60, unk64, unk68, unk72);
        }

        public override void Write(Utf8JsonWriter writer, MeshLight value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("unk00");
            JsonSerializer.Serialize(writer, value.unk00, options);
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("unk08");
            JsonSerializer.Serialize(writer, value.unk08, options);
            writer.WritePropertyName("extra");
            JsonSerializer.Serialize(writer, value.extra, options);
            writer.WritePropertyName("unk24");
            JsonSerializer.Serialize(writer, value.unk24, options);
            writer.WritePropertyName("color");
            JsonSerializer.Serialize(writer, value.color, options);
            writer.WritePropertyName("flags");
            JsonSerializer.Serialize(writer, value.flags, options);
            writer.WritePropertyName("ptr");
            JsonSerializer.Serialize(writer, value.ptr, options);
            writer.WritePropertyName("unk48");
            JsonSerializer.Serialize(writer, value.unk48, options);
            writer.WritePropertyName("unk52");
            JsonSerializer.Serialize(writer, value.unk52, options);
            writer.WritePropertyName("unk56");
            JsonSerializer.Serialize(writer, value.unk56, options);
            writer.WritePropertyName("unk60");
            JsonSerializer.Serialize(writer, value.unk60, options);
            writer.WritePropertyName("unk64");
            JsonSerializer.Serialize(writer, value.unk64, options);
            writer.WritePropertyName("unk68");
            JsonSerializer.Serialize(writer, value.unk68, options);
            writer.WritePropertyName("unk72");
            JsonSerializer.Serialize(writer, value.unk72, options);
            writer.WriteEndObject();
        }
    }
}
