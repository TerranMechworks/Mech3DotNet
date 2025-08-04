using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class BounceSounds
    {
        public static readonly TypeConverter<BounceSounds> Converter = new TypeConverter<BounceSounds>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.BounceSound? default_;
        public Mech3DotNet.Types.Anim.Events.BounceSound? water;
        public Mech3DotNet.Types.Anim.Events.BounceSound? lava;

        public BounceSounds(Mech3DotNet.Types.Anim.Events.BounceSound? default_, Mech3DotNet.Types.Anim.Events.BounceSound? water, Mech3DotNet.Types.Anim.Events.BounceSound? lava)
        {
            this.default_ = default_;
            this.water = water;
            this.lava = lava;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.BounceSound?> default_;
            public Field<Mech3DotNet.Types.Anim.Events.BounceSound?> water;
            public Field<Mech3DotNet.Types.Anim.Events.BounceSound?> lava;
        }

        public static void Serialize(BounceSounds v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("default");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))(v.default_);
            s.SerializeFieldName("water");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))(v.water);
            s.SerializeFieldName("lava");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))(v.lava);
        }

        public static BounceSounds Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                default_ = new Field<Mech3DotNet.Types.Anim.Events.BounceSound?>(),
                water = new Field<Mech3DotNet.Types.Anim.Events.BounceSound?>(),
                lava = new Field<Mech3DotNet.Types.Anim.Events.BounceSound?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "default":
                        fields.default_.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))();
                        break;
                    case "water":
                        fields.water.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))();
                        break;
                    case "lava":
                        fields.lava.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("BounceSounds", fieldName);
                }
            }
            return new BounceSounds(

                fields.default_.Unwrap("BounceSounds", "default_"),

                fields.water.Unwrap("BounceSounds", "water"),

                fields.lava.Unwrap("BounceSounds", "lava")

            );
        }
    }
}
