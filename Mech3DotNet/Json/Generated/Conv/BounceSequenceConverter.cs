using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class BounceSequenceConverter : Mech3DotNet.Json.Converters.StructConverter<BounceSequence>
    {
        protected override BounceSequence ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var seqName0Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var seqName1Field = new Mech3DotNet.Json.Converters.Option<string?>();
            var seqName2Field = new Mech3DotNet.Json.Converters.Option<string?>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "seq_name0":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            seqName0Field.Set(__value);
                            break;
                        }
                    case "seq_name1":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            seqName1Field.Set(__value);
                            break;
                        }
                    case "seq_name2":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            seqName2Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'BounceSequence'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var seqName0 = seqName0Field.Unwrap("seq_name0");
            var seqName1 = seqName1Field.Unwrap("seq_name1");
            var seqName2 = seqName2Field.Unwrap("seq_name2");
            return new BounceSequence(seqName0, seqName1, seqName2);
        }

        public override void Write(Utf8JsonWriter writer, BounceSequence value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("seq_name0");
            JsonSerializer.Serialize(writer, value.seqName0, options);
            writer.WritePropertyName("seq_name1");
            JsonSerializer.Serialize(writer, value.seqName1, options);
            writer.WritePropertyName("seq_name2");
            JsonSerializer.Serialize(writer, value.seqName2, options);
            writer.WriteEndObject();
        }
    }
}
