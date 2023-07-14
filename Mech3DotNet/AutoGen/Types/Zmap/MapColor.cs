using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Zmap
{
    public struct MapColor
    {
        public byte r;
        public byte g;
        public byte b;

        public MapColor(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }

    public static class MapColorConverter
    {
        public static readonly TypeConverter<MapColor> Converter = new TypeConverter<MapColor>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<byte> r;
            public Field<byte> g;
            public Field<byte> b;
        }

        public static void Serialize(MapColor v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("r");
            ((Action<byte>)s.SerializeU8)(v.r);
            s.SerializeFieldName("g");
            ((Action<byte>)s.SerializeU8)(v.g);
            s.SerializeFieldName("b");
            ((Action<byte>)s.SerializeU8)(v.b);
        }

        public static MapColor Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                r = new Field<byte>(),
                g = new Field<byte>(),
                b = new Field<byte>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "r":
                        fields.r.Value = d.DeserializeU8();
                        break;
                    case "g":
                        fields.g.Value = d.DeserializeU8();
                        break;
                    case "b":
                        fields.b.Value = d.DeserializeU8();
                        break;
                    default:
                        throw new UnknownFieldException("MapColor", fieldName);
                }
            }
            return new MapColor(

                fields.r.Unwrap("MapColor", "r"),

                fields.g.Unwrap("MapColor", "g"),

                fields.b.Unwrap("MapColor", "b")

            );
        }
    }
}
