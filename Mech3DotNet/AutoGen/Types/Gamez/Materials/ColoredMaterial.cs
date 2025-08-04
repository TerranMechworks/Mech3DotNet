using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Materials
{
    public sealed class ColoredMaterial
    {
        public static readonly TypeConverter<ColoredMaterial> Converter = new TypeConverter<ColoredMaterial>(Deserialize, Serialize);
        public Mech3DotNet.Types.Common.Color color;
        public byte alpha;
        public Mech3DotNet.Types.Gamez.Materials.Soil soil = Mech3DotNet.Types.Gamez.Materials.Soil.Default;

        public ColoredMaterial(Mech3DotNet.Types.Common.Color color, byte alpha, Mech3DotNet.Types.Gamez.Materials.Soil soil)
        {
            this.color = color;
            this.alpha = alpha;
            this.soil = soil;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Color> color;
            public Field<byte> alpha;
            public Field<Mech3DotNet.Types.Gamez.Materials.Soil> soil;
        }

        public static void Serialize(ColoredMaterial v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("alpha");
            ((Action<byte>)s.SerializeU8)(v.alpha);
            s.SerializeFieldName("soil");
            s.Serialize(Mech3DotNet.Types.Gamez.Materials.SoilConverter.Converter)(v.soil);
        }

        public static ColoredMaterial Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                color = new Field<Mech3DotNet.Types.Common.Color>(),
                alpha = new Field<byte>(),
                soil = new Field<Mech3DotNet.Types.Gamez.Materials.Soil>(Mech3DotNet.Types.Gamez.Materials.Soil.Default),
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
                    case "soil":
                        fields.soil.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Materials.SoilConverter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ColoredMaterial", fieldName);
                }
            }
            return new ColoredMaterial(

                fields.color.Unwrap("ColoredMaterial", "color"),

                fields.alpha.Unwrap("ColoredMaterial", "alpha"),

                fields.soil.Unwrap("ColoredMaterial", "soil")

            );
        }
    }
}
