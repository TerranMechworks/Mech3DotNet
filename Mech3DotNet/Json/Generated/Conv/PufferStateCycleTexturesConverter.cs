using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class PufferStateCycleTexturesConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures>
    {
        protected override Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var texture1Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var texture2Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var texture3Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var texture4Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var texture5Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var texture6Field = new Mech3DotNet.Json.Converters.Option<string?>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "texture1":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            texture1Field.Set(__value);
                            break;
                        }
                    case "texture2":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            texture2Field.Set(__value);
                            break;
                        }
                    case "texture3":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            texture3Field.Set(__value);
                            break;
                        }
                    case "texture4":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            texture4Field.Set(__value);
                            break;
                        }
                    case "texture5":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            texture5Field.Set(__value);
                            break;
                        }
                    case "texture6":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            texture6Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PufferStateCycleTextures'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var texture1 = texture1Field.Unwrap("texture1");
            var texture2 = texture2Field.Unwrap("texture2");
            var texture3 = texture3Field.Unwrap("texture3");
            var texture4 = texture4Field.Unwrap("texture4");
            var texture5 = texture5Field.Unwrap("texture5");
            var texture6 = texture6Field.Unwrap("texture6");
            return new Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures(texture1, texture2, texture3, texture4, texture5, texture6);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("texture1");
            JsonSerializer.Serialize(writer, value.texture1, options);
            writer.WritePropertyName("texture2");
            JsonSerializer.Serialize(writer, value.texture2, options);
            writer.WritePropertyName("texture3");
            JsonSerializer.Serialize(writer, value.texture3, options);
            writer.WritePropertyName("texture4");
            JsonSerializer.Serialize(writer, value.texture4, options);
            writer.WritePropertyName("texture5");
            JsonSerializer.Serialize(writer, value.texture5, options);
            writer.WritePropertyName("texture6");
            JsonSerializer.Serialize(writer, value.texture6, options);
            writer.WriteEndObject();
        }
    }
}
