using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct Rgba
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Rgba(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }
    }

    public static class RgbaConverter
    {
        public static readonly TypeConverter<Rgba> Converter = new TypeConverter<Rgba>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> r;
            public Field<float> g;
            public Field<float> b;
            public Field<float> a;
        }

        public static void Serialize(Rgba v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("r");
            ((Action<float>)s.SerializeF32)(v.r);
            s.SerializeFieldName("g");
            ((Action<float>)s.SerializeF32)(v.g);
            s.SerializeFieldName("b");
            ((Action<float>)s.SerializeF32)(v.b);
            s.SerializeFieldName("a");
            ((Action<float>)s.SerializeF32)(v.a);
        }

        public static Rgba Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                r = new Field<float>(),
                g = new Field<float>(),
                b = new Field<float>(),
                a = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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
                    case "a":
                        fields.a.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Rgba", fieldName);
                }
            }
            return new Rgba(

                fields.r.Unwrap("Rgba", "r"),

                fields.g.Unwrap("Rgba", "g"),

                fields.b.Unwrap("Rgba", "b"),

                fields.a.Unwrap("Rgba", "a")

            );
        }
    }
}
