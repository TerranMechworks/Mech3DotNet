using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class MechlibColoredMaterial
    {
        public static readonly TypeConverter<MechlibColoredMaterial> Converter = new TypeConverter<MechlibColoredMaterial>(Deserialize, Serialize);
        public Mech3DotNet.Types.Common.Color color;
        public byte alpha;

        public MechlibColoredMaterial(Mech3DotNet.Types.Common.Color color, byte alpha)
        {
            this.color = color;
            this.alpha = alpha;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Color> color;
            public Field<byte> alpha;
        }

        public static void Serialize(MechlibColoredMaterial v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("alpha");
            ((Action<byte>)s.SerializeU8)(v.alpha);
        }

        public static MechlibColoredMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                color = new Field<Mech3DotNet.Types.Common.Color>(),
                alpha = new Field<byte>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "alpha":
                        fields.alpha.Value = d.DeserializeU8();
                        break;
                    default:
                        throw new UnknownFieldException("MechlibColoredMaterial", fieldName);
                }
            }
            return new MechlibColoredMaterial(

                fields.color.Unwrap("MechlibColoredMaterial", "color"),

                fields.alpha.Unwrap("MechlibColoredMaterial", "alpha")

            );
        }
    }
}
