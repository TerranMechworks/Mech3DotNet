using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class BounceSequences
    {
        public static readonly TypeConverter<BounceSequences> Converter = new TypeConverter<BounceSequences>(Deserialize, Serialize);
        public string? default_;
        public string? water;
        public string? lava;

        public BounceSequences(string? default_, string? water, string? lava)
        {
            this.default_ = default_;
            this.water = water;
            this.lava = lava;
        }

        private struct Fields
        {
            public Field<string?> default_;
            public Field<string?> water;
            public Field<string?> lava;
        }

        public static void Serialize(BounceSequences v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("default");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.default_);
            s.SerializeFieldName("water");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.water);
            s.SerializeFieldName("lava");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.lava);
        }

        public static BounceSequences Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                default_ = new Field<string?>(),
                water = new Field<string?>(),
                lava = new Field<string?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "default":
                        fields.default_.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "water":
                        fields.water.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "lava":
                        fields.lava.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    default:
                        throw new UnknownFieldException("BounceSequences", fieldName);
                }
            }
            return new BounceSequences(

                fields.default_.Unwrap("BounceSequences", "default_"),

                fields.water.Unwrap("BounceSequences", "water"),

                fields.lava.Unwrap("BounceSequences", "lava")

            );
        }
    }
}
