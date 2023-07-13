using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct ForwardRotationTime
    {
        public float v1;
        public float v2;

        public ForwardRotationTime(float v1, float v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    public static class ForwardRotationTimeConverter
    {
        public static readonly TypeConverter<ForwardRotationTime> Converter = new TypeConverter<ForwardRotationTime>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> v1;
            public Field<float> v2;
        }

        public static void Serialize(ForwardRotationTime v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("v1");
            ((Action<float>)s.SerializeF32)(v.v1);
            s.SerializeFieldName("v2");
            ((Action<float>)s.SerializeF32)(v.v2);
        }

        public static ForwardRotationTime Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                v1 = new Field<float>(),
                v2 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "v1":
                        fields.v1.Value = d.DeserializeF32();
                        break;
                    case "v2":
                        fields.v2.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("ForwardRotationTime", fieldName);
                }
            }
            return new ForwardRotationTime(

                fields.v1.Unwrap("ForwardRotationTime", "v1"),

                fields.v2.Unwrap("ForwardRotationTime", "v2")

            );
        }
    }
}
