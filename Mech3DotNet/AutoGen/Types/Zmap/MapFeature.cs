using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Zmap
{
    public sealed class MapFeature
    {
        public Mech3DotNet.Types.Zmap.MapColor color;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> vertices;
        public int objective;

        public MapFeature(Mech3DotNet.Types.Zmap.MapColor color, System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3> vertices, int objective)
        {
            this.color = color;
            this.vertices = vertices;
            this.objective = objective;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<MapFeature> Converter = new TypeConverter<MapFeature>(Deserialize, Serialize);

        public static void Serialize(MapFeature v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Zmap.MapColorConverter.Converter)(v.color);
            s.SerializeFieldName("vertices");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.vertices);
            s.SerializeFieldName("objective");
            ((Action<int>)s.SerializeI32)(v.objective);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Zmap.MapColor> color;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>> vertices;
            public Field<int> objective;
        }

        public static MapFeature Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                color = new Field<Mech3DotNet.Types.Zmap.MapColor>(),
                vertices = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Vec3>>(),
                objective = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Zmap.MapColorConverter.Converter)();
                        break;
                    case "vertices":
                        fields.vertices.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "objective":
                        fields.objective.Value = d.DeserializeI32();
                        break;
                    default:
                        throw new UnknownFieldException("MapFeature", fieldName);
                }
            }
            return new MapFeature(

                fields.color.Unwrap("MapFeature", "color"),

                fields.vertices.Unwrap("MapFeature", "vertices"),

                fields.objective.Unwrap("MapFeature", "objective")

            );
        }

        #endregion
    }
}
