using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class EndIfConverter : Mech3DotNet.Json.Converters.StructConverter<EndIf>
    {
        protected override EndIf ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
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
            return new EndIf();
        }

        public override void Write(Utf8JsonWriter writer, EndIf value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
