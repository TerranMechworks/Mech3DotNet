using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mesh.Ng
{
    public sealed class PolygonFlags
    {
        public static readonly TypeConverter<PolygonFlags> Converter = new TypeConverter<PolygonFlags>(Deserialize, Serialize);
        public bool unk2 = false;
        public bool unk3 = false;
        public bool triangleStrip = false;
        public bool unk6 = false;

        public PolygonFlags(bool unk2, bool unk3, bool triangleStrip, bool unk6)
        {
            this.unk2 = unk2;
            this.unk3 = unk3;
            this.triangleStrip = triangleStrip;
            this.unk6 = unk6;
        }

        private struct Fields
        {
            public Field<bool> unk2;
            public Field<bool> unk3;
            public Field<bool> triangleStrip;
            public Field<bool> unk6;
        }

        public static void Serialize(PolygonFlags v, Serializer s)
        {
            s.SerializeStruct("PolygonFlags", 4);
            s.SerializeFieldName("unk2");
            ((Action<bool>)s.SerializeBool)(v.unk2);
            s.SerializeFieldName("unk3");
            ((Action<bool>)s.SerializeBool)(v.unk3);
            s.SerializeFieldName("triangle_strip");
            ((Action<bool>)s.SerializeBool)(v.triangleStrip);
            s.SerializeFieldName("unk6");
            ((Action<bool>)s.SerializeBool)(v.unk6);
        }

        public static PolygonFlags Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk2 = new Field<bool>(false),
                unk3 = new Field<bool>(false),
                triangleStrip = new Field<bool>(false),
                unk6 = new Field<bool>(false),
            };
            foreach (var fieldName in d.DeserializeStruct("PolygonFlags"))
            {
                switch (fieldName)
                {
                    case "unk2":
                        fields.unk2.Value = d.DeserializeBool();
                        break;
                    case "unk3":
                        fields.unk3.Value = d.DeserializeBool();
                        break;
                    case "triangle_strip":
                        fields.triangleStrip.Value = d.DeserializeBool();
                        break;
                    case "unk6":
                        fields.unk6.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("PolygonFlags", fieldName);
                }
            }
            return new PolygonFlags(

                fields.unk2.Unwrap("PolygonFlags", "unk2"),

                fields.unk3.Unwrap("PolygonFlags", "unk3"),

                fields.triangleStrip.Unwrap("PolygonFlags", "triangleStrip"),

                fields.unk6.Unwrap("PolygonFlags", "unk6")

            );
        }
    }
}
