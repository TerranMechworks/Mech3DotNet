using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct ForwardRotationDistance
    {
        public float v1;

        public ForwardRotationDistance(float v1)
        {
            this.v1 = v1;
        }
    }

    public static class ForwardRotationDistanceConverter
    {
        public static readonly TypeConverter<ForwardRotationDistance> Converter = new TypeConverter<ForwardRotationDistance>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> v1;
        }

        public static void Serialize(ForwardRotationDistance v, Serializer s)
        {
            s.SerializeStruct("ForwardRotationDistance", 1);
            s.SerializeFieldName("v1");
            ((Action<float>)s.SerializeF32)(v.v1);
        }

        public static ForwardRotationDistance Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                v1 = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ForwardRotationDistance"))
            {
                switch (fieldName)
                {
                    case "v1":
                        fields.v1.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("ForwardRotationDistance", fieldName);
                }
            }
            return new ForwardRotationDistance(

                fields.v1.Unwrap("ForwardRotationDistance", "v1")

            );
        }
    }
}
