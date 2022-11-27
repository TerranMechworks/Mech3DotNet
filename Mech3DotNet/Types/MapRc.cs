using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Zmap
{
    public sealed class MapRc
    {
        public static readonly TypeConverter<MapRc> Converter = new TypeConverter<MapRc>(Deserialize, Serialize);
        public uint unk04;
        public float maxX;
        public float maxY;
        public System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature> features;

        public MapRc(uint unk04, float maxX, float maxY, System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature> features)
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

        public static void Serialize(Mech3DotNet.Types.Zmap.MapRc v, Serializer s)
        {
            s.SerializeStruct("MapRc", 4);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("max_x");
            ((Action<float>)s.SerializeF32)(v.maxX);
            s.SerializeFieldName("max_y");
            ((Action<float>)s.SerializeF32)(v.maxY);
            s.SerializeFieldName("features");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Zmap.MapFeature.Converter))(v.features);
        }

        public static Mech3DotNet.Types.Zmap.MapRc Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk04 = new Field<uint>(),
                maxX = new Field<float>(),
                maxY = new Field<float>(),
                features = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("MapRc"))
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
                        throw new UnknownFieldException("MapRc", fieldName);
                }
            }
            return new MapRc(

                fields.unk04.Unwrap("MapRc", "unk04"),

                fields.maxX.Unwrap("MapRc", "maxX"),

                fields.maxY.Unwrap("MapRc", "maxY"),

                fields.features.Unwrap("MapRc", "features")

            );
        }
    }
}
