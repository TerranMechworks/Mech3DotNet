using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class ColoredMaterial
    {
        public static readonly TypeConverter<ColoredMaterial> Converter = new TypeConverter<ColoredMaterial>(Deserialize, Serialize);
        public Mech3DotNet.Types.Types.Color color;
        public byte alpha;
        public float specular;

        public ColoredMaterial(Mech3DotNet.Types.Types.Color color, byte alpha, float specular)
        {
            this.color = color;
            this.alpha = alpha;
            this.specular = specular;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Types.Color> color;
            public Field<byte> alpha;
            public Field<float> specular;
        }

        public static void Serialize(ColoredMaterial v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("alpha");
            ((Action<byte>)s.SerializeU8)(v.alpha);
            s.SerializeFieldName("specular");
            ((Action<float>)s.SerializeF32)(v.specular);
        }

        public static ColoredMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                color = new Field<Mech3DotNet.Types.Types.Color>(),
                alpha = new Field<byte>(),
                specular = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter)();
                        break;
                    case "alpha":
                        fields.alpha.Value = d.DeserializeU8();
                        break;
                    case "specular":
                        fields.specular.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("ColoredMaterial", fieldName);
                }
            }
            return new ColoredMaterial(

                fields.color.Unwrap("ColoredMaterial", "color"),

                fields.alpha.Unwrap("ColoredMaterial", "alpha"),

                fields.specular.Unwrap("ColoredMaterial", "specular")

            );
        }
    }
}
