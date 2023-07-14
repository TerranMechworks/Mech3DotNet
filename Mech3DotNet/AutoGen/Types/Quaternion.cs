using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types
{
    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }

    public static class QuaternionConverter
    {
        public static readonly TypeConverter<Quaternion> Converter = new TypeConverter<Quaternion>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> x;
            public Field<float> y;
            public Field<float> z;
            public Field<float> w;
        }

        public static void Serialize(Quaternion v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("x");
            ((Action<float>)s.SerializeF32)(v.x);
            s.SerializeFieldName("y");
            ((Action<float>)s.SerializeF32)(v.y);
            s.SerializeFieldName("z");
            ((Action<float>)s.SerializeF32)(v.z);
            s.SerializeFieldName("w");
            ((Action<float>)s.SerializeF32)(v.w);
        }

        public static Quaternion Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<float>(),
                y = new Field<float>(),
                z = new Field<float>(),
                w = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.DeserializeF32();
                        break;
                    case "y":
                        fields.y.Value = d.DeserializeF32();
                        break;
                    case "z":
                        fields.z.Value = d.DeserializeF32();
                        break;
                    case "w":
                        fields.w.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Quaternion", fieldName);
                }
            }
            return new Quaternion(

                fields.x.Unwrap("Quaternion", "x"),

                fields.y.Unwrap("Quaternion", "y"),

                fields.z.Unwrap("Quaternion", "z"),

                fields.w.Unwrap("Quaternion", "w")

            );
        }
    }
}
