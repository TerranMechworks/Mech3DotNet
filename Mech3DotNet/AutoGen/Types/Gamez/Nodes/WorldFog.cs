using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class WorldFog
    {
        public Mech3DotNet.Types.Gamez.Nodes.FogType fogType;
        public Mech3DotNet.Types.Common.Color fogColor;
        public Mech3DotNet.Types.Common.Range fogRange;
        public Mech3DotNet.Types.Common.Range fogAltitude;
        public float fogDensity;

        public WorldFog(Mech3DotNet.Types.Gamez.Nodes.FogType fogType, Mech3DotNet.Types.Common.Color fogColor, Mech3DotNet.Types.Common.Range fogRange, Mech3DotNet.Types.Common.Range fogAltitude, float fogDensity)
        {
            this.fogType = fogType;
            this.fogColor = fogColor;
            this.fogRange = fogRange;
            this.fogAltitude = fogAltitude;
            this.fogDensity = fogDensity;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<WorldFog> Converter = new TypeConverter<WorldFog>(Deserialize, Serialize);

        public static void Serialize(WorldFog v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("fog_type");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.FogTypeConverter.Converter)(v.fogType);
            s.SerializeFieldName("fog_color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.fogColor);
            s.SerializeFieldName("fog_range");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.fogRange);
            s.SerializeFieldName("fog_altitude");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.fogAltitude);
            s.SerializeFieldName("fog_density");
            ((Action<float>)s.SerializeF32)(v.fogDensity);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Gamez.Nodes.FogType> fogType;
            public Field<Mech3DotNet.Types.Common.Color> fogColor;
            public Field<Mech3DotNet.Types.Common.Range> fogRange;
            public Field<Mech3DotNet.Types.Common.Range> fogAltitude;
            public Field<float> fogDensity;
        }

        public static WorldFog Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                fogType = new Field<Mech3DotNet.Types.Gamez.Nodes.FogType>(),
                fogColor = new Field<Mech3DotNet.Types.Common.Color>(),
                fogRange = new Field<Mech3DotNet.Types.Common.Range>(),
                fogAltitude = new Field<Mech3DotNet.Types.Common.Range>(),
                fogDensity = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "fog_type":
                        fields.fogType.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.FogTypeConverter.Converter)();
                        break;
                    case "fog_color":
                        fields.fogColor.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "fog_range":
                        fields.fogRange.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "fog_altitude":
                        fields.fogAltitude.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "fog_density":
                        fields.fogDensity.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("WorldFog", fieldName);
                }
            }
            return new WorldFog(

                fields.fogType.Unwrap("WorldFog", "fogType"),

                fields.fogColor.Unwrap("WorldFog", "fogColor"),

                fields.fogRange.Unwrap("WorldFog", "fogRange"),

                fields.fogAltitude.Unwrap("WorldFog", "fogAltitude"),

                fields.fogDensity.Unwrap("WorldFog", "fogDensity")

            );
        }

        #endregion
    }
}
