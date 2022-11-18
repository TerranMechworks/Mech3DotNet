using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Converters
{
    public class PrereqAnimationConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.PrereqAnimation>
    {
        protected override Mech3DotNet.Json.Anim.PrereqAnimation ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'PrereqAnimation'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PrereqAnimation'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            return new Mech3DotNet.Json.Anim.PrereqAnimation(name);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.PrereqAnimation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WriteEndObject();
        }
    }
}
