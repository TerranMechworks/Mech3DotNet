using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferStateColor
    {
        public float unk00;
        public Mech3DotNet.Types.Common.Color color;
        public float unk16;

        public PufferStateColor(float unk00, Mech3DotNet.Types.Common.Color color, float unk16)
        {
            this.unk00 = unk00;
            this.color = color;
            this.unk16 = unk16;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<PufferStateColor> Converter = new TypeConverter<PufferStateColor>(Deserialize, Serialize);

        public static void Serialize(PufferStateColor v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("unk00");
            ((Action<float>)s.SerializeF32)(v.unk00);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("unk16");
            ((Action<float>)s.SerializeF32)(v.unk16);
        }

        private struct Fields
        {
            public Field<float> unk00;
            public Field<Mech3DotNet.Types.Common.Color> color;
            public Field<float> unk16;
        }

        public static PufferStateColor Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk00 = new Field<float>(),
                color = new Field<Mech3DotNet.Types.Common.Color>(),
                unk16 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "unk00":
                        fields.unk00.Value = d.DeserializeF32();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "unk16":
                        fields.unk16.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("PufferStateColor", fieldName);
                }
            }
            return new PufferStateColor(

                fields.unk00.Unwrap("PufferStateColor", "unk00"),

                fields.color.Unwrap("PufferStateColor", "color"),

                fields.unk16.Unwrap("PufferStateColor", "unk16")

            );
        }

        #endregion
    }
}
