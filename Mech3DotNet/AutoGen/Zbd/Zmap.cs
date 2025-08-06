using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Zbd
{
    public partial class Zmap
    {
        public uint unk04;
        public Mech3DotNet.Types.Common.Vec3 min;
        public Mech3DotNet.Types.Common.Vec3 max;
        public System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature> features;

        public Zmap(uint unk04, Mech3DotNet.Types.Common.Vec3 min, Mech3DotNet.Types.Common.Vec3 max, System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature> features)
        {
            this.unk04 = unk04;
            this.min = min;
            this.max = max;
            this.features = features;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Zmap> Converter = new TypeConverter<Zmap>(Deserialize, Serialize);

        public static void Serialize(Zmap v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("unk04");
            ((Action<uint>)s.SerializeU32)(v.unk04);
            s.SerializeFieldName("min");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.min);
            s.SerializeFieldName("max");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.max);
            s.SerializeFieldName("features");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Zmap.MapFeature.Converter))(v.features);
        }

        private struct Fields
        {
            public Field<uint> unk04;
            public Field<Mech3DotNet.Types.Common.Vec3> min;
            public Field<Mech3DotNet.Types.Common.Vec3> max;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature>> features;
        }

        public static Zmap Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                unk04 = new Field<uint>(),
                min = new Field<Mech3DotNet.Types.Common.Vec3>(),
                max = new Field<Mech3DotNet.Types.Common.Vec3>(),
                features = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Zmap.MapFeature>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "unk04":
                        fields.unk04.Value = d.DeserializeU32();
                        break;
                    case "min":
                        fields.min.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "max":
                        fields.max.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
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

                fields.min.Unwrap("Zmap", "min"),

                fields.max.Unwrap("Zmap", "max"),

                fields.features.Unwrap("Zmap", "features")

            );
        }

        #endregion
    }
}
