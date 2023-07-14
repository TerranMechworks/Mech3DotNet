using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class TextureName
    {
        public static readonly TypeConverter<TextureName> Converter = new TypeConverter<TextureName>(Deserialize, Serialize);
        public string original;
        public string? renamed;

        public TextureName(string original, string? renamed)
        {
            this.original = original;
            this.renamed = renamed;
        }

        private struct Fields
        {
            public Field<string> original;
            public Field<string?> renamed;
        }

        public static void Serialize(TextureName v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("original");
            ((Action<string>)s.SerializeString)(v.original);
            s.SerializeFieldName("renamed");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.renamed);
        }

        public static TextureName Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                original = new Field<string>(),
                renamed = new Field<string?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "original":
                        fields.original.Value = d.DeserializeString();
                        break;
                    case "renamed":
                        fields.renamed.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    default:
                        throw new UnknownFieldException("TextureName", fieldName);
                }
            }
            return new TextureName(

                fields.original.Unwrap("TextureName", "original"),

                fields.renamed.Unwrap("TextureName", "renamed")

            );
        }
    }
}
