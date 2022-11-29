using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Types
{
    public struct Color
    {
        public float r;
        public float g;
        public float b;

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }

    public static class ColorConverter
    {
        public static readonly TypeConverter<Color> Converter = new TypeConverter<Color>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> r;
            public Field<float> g;
            public Field<float> b;
        }

        public static void Serialize(Color v, Serializer s)
        {
            s.SerializeStruct("Color", 3);
            s.SerializeFieldName("r");
            ((Action<float>)s.SerializeF32)(v.r);
            s.SerializeFieldName("g");
            ((Action<float>)s.SerializeF32)(v.g);
            s.SerializeFieldName("b");
            ((Action<float>)s.SerializeF32)(v.b);
        }

        public static Color Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                r = new Field<float>(),
                g = new Field<float>(),
                b = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Color"))
            {
                switch (fieldName)
                {
                    case "r":
                        fields.r.Value = d.DeserializeF32();
                        break;
                    case "g":
                        fields.g.Value = d.DeserializeF32();
                        break;
                    case "b":
                        fields.b.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Color", fieldName);
                }
            }
            return new Color(

                fields.r.Unwrap("Color", "r"),

                fields.g.Unwrap("Color", "g"),

                fields.b.Unwrap("Color", "b")

            );
        }
    }
}
