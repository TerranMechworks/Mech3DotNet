using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh
{
    public struct UvCoord
    {
        public float u;
        public float v;

        public UvCoord(float u, float v)
        {
            this.u = u;
            this.v = v;
        }
    }

    public static class UvCoordConverter
    {
        public static readonly TypeConverter<UvCoord> Converter = new TypeConverter<UvCoord>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> u;
            public Field<float> v;
        }

        public static void Serialize(UvCoord v, Serializer s)
        {
            s.SerializeStruct("UvCoord", 2);
            s.SerializeFieldName("u");
            ((Action<float>)s.SerializeF32)(v.u);
            s.SerializeFieldName("v");
            ((Action<float>)s.SerializeF32)(v.v);
        }

        public static UvCoord Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                u = new Field<float>(),
                v = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct("UvCoord"))
            {
                switch (fieldName)
                {
                    case "u":
                        fields.u.Value = d.DeserializeF32();
                        break;
                    case "v":
                        fields.v.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("UvCoord", fieldName);
                }
            }
            return new UvCoord(

                fields.u.Unwrap("UvCoord", "u"),

                fields.v.Unwrap("UvCoord", "v")

            );
        }
    }
}
