using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Zbd
{
    public partial class Zmap
    {
        public static readonly TypeConverter<Zmap> Converter = new TypeConverter<Zmap>(Deserialize, Serialize);
        public uint unk04;
        public float maxX;
        public float maxY;
        public System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature> features;

        public Zmap(uint unk04, float maxX, float maxY, System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature> features)
        {
            this.unk04 = unk04;
            this.maxX = maxX;
            this.maxY = maxY;
            this.features = features;
        }

        private struct Fields
        {
            public Field<uint> unk04;
            public Field<float> maxX;
            public Field<float> maxY;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature>> features;
        }

        public static void Serialize(Zmap v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("max_x");
            ((Action<float>)s.SerializeF32)(v.maxX);
            s.SerializeFieldName("max_y");
            ((Action<float>)s.SerializeF32)(v.maxY);
            s.SerializeFieldName("features");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Zmap.MapFeature.Converter))(v.features);
        }

        public static Zmap Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk04 = new Field<uint>(),
                maxX = new Field<float>(),
                maxY = new Field<float>(),
                features = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "unk04":
                        fields.unk04.Value = d.DeserializeU32();
                        break;
                    case "max_x":
                        fields.maxX.Value = d.DeserializeF32();
                        break;
                    case "max_y":
                        fields.maxY.Value = d.DeserializeF32();
                        break;
                    case "features":
                        fields.features.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Zmap.MapFeature.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("Zmap", fieldName);
                }
            }
            return new Zmap(

                fields.unk04.Unwrap("Zmap", "unk04"),

                fields.maxX.Unwrap("Zmap", "maxX"),

                fields.maxY.Unwrap("Zmap", "maxY"),

                fields.features.Unwrap("Zmap", "features")

            );
        }
    }
}
