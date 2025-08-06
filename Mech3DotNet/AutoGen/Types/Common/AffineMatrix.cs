using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Common
{
    public sealed class AffineMatrix
    {
        public float r00;
        public float r01;
        public float r02;
        public float r10;
        public float r11;
        public float r12;
        public float r20;
        public float r21;
        public float r22;
        public float r30;
        public float r31;
        public float r32;

        public AffineMatrix(float r00, float r01, float r02, float r10, float r11, float r12, float r20, float r21, float r22, float r30, float r31, float r32)
        {
            this.r00 = r00;
            this.r01 = r01;
            this.r02 = r02;
            this.r10 = r10;
            this.r11 = r11;
            this.r12 = r12;
            this.r20 = r20;
            this.r21 = r21;
            this.r22 = r22;
            this.r30 = r30;
            this.r31 = r31;
            this.r32 = r32;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<AffineMatrix> Converter = new TypeConverter<AffineMatrix>(Deserialize, Serialize);

        public static void Serialize(AffineMatrix v, Serializer s)
        {
            s.SerializeStruct(12);
            s.SerializeFieldName("r00");
            ((Action<float>)s.SerializeF32)(v.r00);
            s.SerializeFieldName("r01");
            ((Action<float>)s.SerializeF32)(v.r01);
            s.SerializeFieldName("r02");
            ((Action<float>)s.SerializeF32)(v.r02);
            s.SerializeFieldName("r10");
            ((Action<float>)s.SerializeF32)(v.r10);
            s.SerializeFieldName("r11");
            ((Action<float>)s.SerializeF32)(v.r11);
            s.SerializeFieldName("r12");
            ((Action<float>)s.SerializeF32)(v.r12);
            s.SerializeFieldName("r20");
            ((Action<float>)s.SerializeF32)(v.r20);
            s.SerializeFieldName("r21");
            ((Action<float>)s.SerializeF32)(v.r21);
            s.SerializeFieldName("r22");
            ((Action<float>)s.SerializeF32)(v.r22);
            s.SerializeFieldName("r30");
            ((Action<float>)s.SerializeF32)(v.r30);
            s.SerializeFieldName("r31");
            ((Action<float>)s.SerializeF32)(v.r31);
            s.SerializeFieldName("r32");
            ((Action<float>)s.SerializeF32)(v.r32);
        }

        private struct Fields
        {
            public Field<float> r00;
            public Field<float> r01;
            public Field<float> r02;
            public Field<float> r10;
            public Field<float> r11;
            public Field<float> r12;
            public Field<float> r20;
            public Field<float> r21;
            public Field<float> r22;
            public Field<float> r30;
            public Field<float> r31;
            public Field<float> r32;
        }

        public static AffineMatrix Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                r00 = new Field<float>(),
                r01 = new Field<float>(),
                r02 = new Field<float>(),
                r10 = new Field<float>(),
                r11 = new Field<float>(),
                r12 = new Field<float>(),
                r20 = new Field<float>(),
                r21 = new Field<float>(),
                r22 = new Field<float>(),
                r30 = new Field<float>(),
                r31 = new Field<float>(),
                r32 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "r00":
                        fields.r00.Value = d.DeserializeF32();
                        break;
                    case "r01":
                        fields.r01.Value = d.DeserializeF32();
                        break;
                    case "r02":
                        fields.r02.Value = d.DeserializeF32();
                        break;
                    case "r10":
                        fields.r10.Value = d.DeserializeF32();
                        break;
                    case "r11":
                        fields.r11.Value = d.DeserializeF32();
                        break;
                    case "r12":
                        fields.r12.Value = d.DeserializeF32();
                        break;
                    case "r20":
                        fields.r20.Value = d.DeserializeF32();
                        break;
                    case "r21":
                        fields.r21.Value = d.DeserializeF32();
                        break;
                    case "r22":
                        fields.r22.Value = d.DeserializeF32();
                        break;
                    case "r30":
                        fields.r30.Value = d.DeserializeF32();
                        break;
                    case "r31":
                        fields.r31.Value = d.DeserializeF32();
                        break;
                    case "r32":
                        fields.r32.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("AffineMatrix", fieldName);
                }
            }
            return new AffineMatrix(

                fields.r00.Unwrap("AffineMatrix", "r00"),

                fields.r01.Unwrap("AffineMatrix", "r01"),

                fields.r02.Unwrap("AffineMatrix", "r02"),

                fields.r10.Unwrap("AffineMatrix", "r10"),

                fields.r11.Unwrap("AffineMatrix", "r11"),

                fields.r12.Unwrap("AffineMatrix", "r12"),

                fields.r20.Unwrap("AffineMatrix", "r20"),

                fields.r21.Unwrap("AffineMatrix", "r21"),

                fields.r22.Unwrap("AffineMatrix", "r22"),

                fields.r30.Unwrap("AffineMatrix", "r30"),

                fields.r31.Unwrap("AffineMatrix", "r31"),

                fields.r32.Unwrap("AffineMatrix", "r32")

            );
        }

        #endregion
    }
}
