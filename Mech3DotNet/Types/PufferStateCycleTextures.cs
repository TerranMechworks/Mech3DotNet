using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferStateCycleTextures
    {
        public static readonly TypeConverter<PufferStateCycleTextures> Converter = new TypeConverter<PufferStateCycleTextures>(Deserialize, Serialize);
        public string? texture1;
        public string? texture2;
        public string? texture3;
        public string? texture4;
        public string? texture5;
        public string? texture6;

        public PufferStateCycleTextures(string? texture1, string? texture2, string? texture3, string? texture4, string? texture5, string? texture6)
        {
            this.texture1 = texture1;
            this.texture2 = texture2;
            this.texture3 = texture3;
            this.texture4 = texture4;
            this.texture5 = texture5;
            this.texture6 = texture6;
        }

        private struct Fields
        {
            public Field<string?> texture1;
            public Field<string?> texture2;
            public Field<string?> texture3;
            public Field<string?> texture4;
            public Field<string?> texture5;
            public Field<string?> texture6;
        }

        public static void Serialize(PufferStateCycleTextures v, Serializer s)
        {
            s.SerializeStruct("PufferStateCycleTextures", 6);
            s.SerializeFieldName("texture1");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.texture1);
            s.SerializeFieldName("texture2");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.texture2);
            s.SerializeFieldName("texture3");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.texture3);
            s.SerializeFieldName("texture4");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.texture4);
            s.SerializeFieldName("texture5");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.texture5);
            s.SerializeFieldName("texture6");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.texture6);
        }

        public static PufferStateCycleTextures Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                texture1 = new Field<string?>(),
                texture2 = new Field<string?>(),
                texture3 = new Field<string?>(),
                texture4 = new Field<string?>(),
                texture5 = new Field<string?>(),
                texture6 = new Field<string?>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PufferStateCycleTextures"))
            {
                switch (fieldName)
                {
                    case "texture1":
                        fields.texture1.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "texture2":
                        fields.texture2.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "texture3":
                        fields.texture3.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "texture4":
                        fields.texture4.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "texture5":
                        fields.texture5.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "texture6":
                        fields.texture6.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    default:
                        throw new UnknownFieldException("PufferStateCycleTextures", fieldName);
                }
            }
            return new PufferStateCycleTextures(

                fields.texture1.Unwrap("PufferStateCycleTextures", "texture1"),

                fields.texture2.Unwrap("PufferStateCycleTextures", "texture2"),

                fields.texture3.Unwrap("PufferStateCycleTextures", "texture3"),

                fields.texture4.Unwrap("PufferStateCycleTextures", "texture4"),

                fields.texture5.Unwrap("PufferStateCycleTextures", "texture5"),

                fields.texture6.Unwrap("PufferStateCycleTextures", "texture6")

            );
        }
    }
}
