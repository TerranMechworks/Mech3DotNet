using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Common
{
    public sealed class Matrix
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
        public float g;
        public float h;
        public float i;

        public Matrix(float a, float b, float c, float d, float e, float f, float g, float h, float i)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Matrix> Converter = new TypeConverter<Matrix>(Deserialize, Serialize);

        public static void Serialize(Matrix v, Serializer s)
        {
            s.SerializeStruct(9);
            s.SerializeFieldName("a");
            ((Action<float>)s.SerializeF32)(v.a);
            s.SerializeFieldName("b");
            ((Action<float>)s.SerializeF32)(v.b);
            s.SerializeFieldName("c");
            ((Action<float>)s.SerializeF32)(v.c);
            s.SerializeFieldName("d");
            ((Action<float>)s.SerializeF32)(v.d);
            s.SerializeFieldName("e");
            ((Action<float>)s.SerializeF32)(v.e);
            s.SerializeFieldName("f");
            ((Action<float>)s.SerializeF32)(v.f);
            s.SerializeFieldName("g");
            ((Action<float>)s.SerializeF32)(v.g);
            s.SerializeFieldName("h");
            ((Action<float>)s.SerializeF32)(v.h);
            s.SerializeFieldName("i");
            ((Action<float>)s.SerializeF32)(v.i);
        }

        private struct Fields
        {
            public Field<float> a;
            public Field<float> b;
            public Field<float> c;
            public Field<float> d;
            public Field<float> e;
            public Field<float> f;
            public Field<float> g;
            public Field<float> h;
            public Field<float> i;
        }

        public static Matrix Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                a = new Field<float>(),
                b = new Field<float>(),
                c = new Field<float>(),
                d = new Field<float>(),
                e = new Field<float>(),
                f = new Field<float>(),
                g = new Field<float>(),
                h = new Field<float>(),
                i = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "a":
                        fields.a.Value = d.DeserializeF32();
                        break;
                    case "b":
                        fields.b.Value = d.DeserializeF32();
                        break;
                    case "c":
                        fields.c.Value = d.DeserializeF32();
                        break;
                    case "d":
                        fields.d.Value = d.DeserializeF32();
                        break;
                    case "e":
                        fields.e.Value = d.DeserializeF32();
                        break;
                    case "f":
                        fields.f.Value = d.DeserializeF32();
                        break;
                    case "g":
                        fields.g.Value = d.DeserializeF32();
                        break;
                    case "h":
                        fields.h.Value = d.DeserializeF32();
                        break;
                    case "i":
                        fields.i.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Matrix", fieldName);
                }
            }
            return new Matrix(

                fields.a.Unwrap("Matrix", "a"),

                fields.b.Unwrap("Matrix", "b"),

                fields.c.Unwrap("Matrix", "c"),

                fields.d.Unwrap("Matrix", "d"),

                fields.e.Unwrap("Matrix", "e"),

                fields.f.Unwrap("Matrix", "f"),

                fields.g.Unwrap("Matrix", "g"),

                fields.h.Unwrap("Matrix", "h"),

                fields.i.Unwrap("Matrix", "i")

            );
        }

        #endregion
    }
}
