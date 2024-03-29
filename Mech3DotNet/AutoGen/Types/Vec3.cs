using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types
{
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    public static class Vec3Converter
    {
        public static readonly TypeConverter<Vec3> Converter = new TypeConverter<Vec3>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> x;
            public Field<float> y;
            public Field<float> z;
        }

        public static void Serialize(Vec3 v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("x");
            ((Action<float>)s.SerializeF32)(v.x);
            s.SerializeFieldName("y");
            ((Action<float>)s.SerializeF32)(v.y);
            s.SerializeFieldName("z");
            ((Action<float>)s.SerializeF32)(v.z);
        }

        public static Vec3 Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<float>(),
                y = new Field<float>(),
                z = new Field<float>(),
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
                    default:
                        throw new UnknownFieldException("Vec3", fieldName);
                }
            }
            return new Vec3(

                fields.x.Unwrap("Vec3", "x"),

                fields.y.Unwrap("Vec3", "y"),

                fields.z.Unwrap("Vec3", "z")

            );
        }
    }
}
