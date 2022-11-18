using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class CycleDataConverter : Mech3DotNet.Json.Converters.StructConverter<CycleData>
    {
        protected override CycleData ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var texturesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<string>>();
            var unk00Field = new Mech3DotNet.Json.Converters.Option<bool>();
            var unk04Field = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk12Field = new Mech3DotNet.Json.Converters.Option<float>();
            var infoPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var dataPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "textures":
                        {
                            System.Collections.Generic.List<string>? __value = ReadFieldValue<System.Collections.Generic.List<string>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'textures' was null for 'CycleData'");
                                throw new JsonException();
                            }
                            texturesField.Set(__value);
                            break;
                        }
                    case "unk00":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk00Field.Set(__value);
                            break;
                        }
                    case "unk04":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            unk04Field.Set(__value);
                            break;
                        }
                    case "unk12":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk12Field.Set(__value);
                            break;
                        }
                    case "info_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            infoPtrField.Set(__value);
                            break;
                        }
                    case "data_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            dataPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CycleData'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var textures = texturesField.Unwrap("textures");
            var unk00 = unk00Field.Unwrap("unk00");
            var unk04 = unk04Field.Unwrap("unk04");
            var unk12 = unk12Field.Unwrap("unk12");
            var infoPtr = infoPtrField.Unwrap("info_ptr");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            return new CycleData(textures, unk00, unk04, unk12, infoPtr, dataPtr);
        }

        public override void Write(Utf8JsonWriter writer, CycleData value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("textures");
            JsonSerializer.Serialize(writer, value.textures, options);
            writer.WritePropertyName("unk00");
            JsonSerializer.Serialize(writer, value.unk00, options);
            writer.WritePropertyName("unk04");
            JsonSerializer.Serialize(writer, value.unk04, options);
            writer.WritePropertyName("unk12");
            JsonSerializer.Serialize(writer, value.unk12, options);
            writer.WritePropertyName("info_ptr");
            JsonSerializer.Serialize(writer, value.infoPtr, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WriteEndObject();
        }
    }
}
