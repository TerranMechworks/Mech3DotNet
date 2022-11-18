using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class EndIfConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.EndIf>
    {
        protected override Mech3DotNet.Json.Anim.Events.EndIf ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'EndIf'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            return new Mech3DotNet.Json.Anim.Events.EndIf();
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.EndIf value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
