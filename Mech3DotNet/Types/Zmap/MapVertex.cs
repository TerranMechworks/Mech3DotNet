using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Zmap
{
    public struct MapVertex
    {
        public float x;
        public float z;
        public float y;

        public MapVertex(float x, float z, float y)
        {
            this.x = x;
            this.z = z;
            this.y = y;
        }
    }

    public static class MapVertexConverter
    {
        public static readonly TypeConverter<MapVertex> Converter = new TypeConverter<MapVertex>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<float> x;
            public Field<float> z;
            public Field<float> y;
        }

        public static void Serialize(MapVertex v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("x");
            ((Action<float>)s.SerializeF32)(v.x);
            s.SerializeFieldName("z");
            ((Action<float>)s.SerializeF32)(v.z);
            s.SerializeFieldName("y");
            ((Action<float>)s.SerializeF32)(v.y);
        }

        public static MapVertex Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                x = new Field<float>(),
                z = new Field<float>(),
                y = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "x":
                        fields.x.Value = d.DeserializeF32();
                        break;
                    case "z":
                        fields.z.Value = d.DeserializeF32();
                        break;
                    case "y":
                        fields.y.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("MapVertex", fieldName);
                }
            }
            return new MapVertex(

                fields.x.Unwrap("MapVertex", "x"),

                fields.z.Unwrap("MapVertex", "z"),

                fields.y.Unwrap("MapVertex", "y")

            );
        }
    }
}
