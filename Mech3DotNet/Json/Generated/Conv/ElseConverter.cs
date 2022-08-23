using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ElseConverter : StructConverter<Else>
    {
        protected override Else ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Else'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            return new Else();
        }

        public override void Write(Utf8JsonWriter writer, Else value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteEndObject();
        }
    }
}
