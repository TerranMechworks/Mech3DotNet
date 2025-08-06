using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Light
    {
        public Mech3DotNet.Types.Gamez.Nodes.LightFlags flags;
        public Mech3DotNet.Types.Common.Vec3 orientation;
        public Mech3DotNet.Types.Common.Vec3 translate;
        public float diffuse;
        public float ambient;
        public Mech3DotNet.Types.Common.Color color;
        public Mech3DotNet.Types.Common.Color colorAmbient;
        public Mech3DotNet.Types.Common.Color colorDiffuseMixed;
        public Mech3DotNet.Types.Common.Color colorAmbientMixed;
        public Mech3DotNet.Types.Common.Color colorDaCombined;
        public Mech3DotNet.Types.Common.Range range;
        public System.Collections.Generic.List<short> parentIndices;
        public uint parentPtr;

        public Light(Mech3DotNet.Types.Gamez.Nodes.LightFlags flags, Mech3DotNet.Types.Common.Vec3 orientation, Mech3DotNet.Types.Common.Vec3 translate, float diffuse, float ambient, Mech3DotNet.Types.Common.Color color, Mech3DotNet.Types.Common.Color colorAmbient, Mech3DotNet.Types.Common.Color colorDiffuseMixed, Mech3DotNet.Types.Common.Color colorAmbientMixed, Mech3DotNet.Types.Common.Color colorDaCombined, Mech3DotNet.Types.Common.Range range, System.Collections.Generic.List<short> parentIndices, uint parentPtr)
        {
            this.flags = flags;
            this.orientation = orientation;
            this.translate = translate;
            this.diffuse = diffuse;
            this.ambient = ambient;
            this.color = color;
            this.colorAmbient = colorAmbient;
            this.colorDiffuseMixed = colorDiffuseMixed;
            this.colorAmbientMixed = colorAmbientMixed;
            this.colorDaCombined = colorDaCombined;
            this.range = range;
            this.parentIndices = parentIndices;
            this.parentPtr = parentPtr;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Light> Converter = new TypeConverter<Light>(Deserialize, Serialize);

        public static void Serialize(Light v, Serializer s)
        {
            s.SerializeStruct(13);
            s.SerializeFieldName("flags");
            s.Serialize(Mech3DotNet.Types.Gamez.Nodes.LightFlagsConverter.Converter)(v.flags);
            s.SerializeFieldName("orientation");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.orientation);
            s.SerializeFieldName("translate");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.translate);
            s.SerializeFieldName("diffuse");
            ((Action<float>)s.SerializeF32)(v.diffuse);
            s.SerializeFieldName("ambient");
            ((Action<float>)s.SerializeF32)(v.ambient);
            s.SerializeFieldName("color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.color);
            s.SerializeFieldName("color_ambient");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.colorAmbient);
            s.SerializeFieldName("color_diffuse_mixed");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.colorDiffuseMixed);
            s.SerializeFieldName("color_ambient_mixed");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.colorAmbientMixed);
            s.SerializeFieldName("color_da_combined");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.colorDaCombined);
            s.SerializeFieldName("range");
            s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)(v.range);
            s.SerializeFieldName("parent_indices");
            s.SerializeVec(((Action<short>)s.SerializeI16))(v.parentIndices);
            s.SerializeFieldName("parent_ptr");
            ((Action<uint>)s.SerializeU32)(v.parentPtr);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Gamez.Nodes.LightFlags> flags;
            public Field<Mech3DotNet.Types.Common.Vec3> orientation;
            public Field<Mech3DotNet.Types.Common.Vec3> translate;
            public Field<float> diffuse;
            public Field<float> ambient;
            public Field<Mech3DotNet.Types.Common.Color> color;
            public Field<Mech3DotNet.Types.Common.Color> colorAmbient;
            public Field<Mech3DotNet.Types.Common.Color> colorDiffuseMixed;
            public Field<Mech3DotNet.Types.Common.Color> colorAmbientMixed;
            public Field<Mech3DotNet.Types.Common.Color> colorDaCombined;
            public Field<Mech3DotNet.Types.Common.Range> range;
            public Field<System.Collections.Generic.List<short>> parentIndices;
            public Field<uint> parentPtr;
        }

        public static Light Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                flags = new Field<Mech3DotNet.Types.Gamez.Nodes.LightFlags>(),
                orientation = new Field<Mech3DotNet.Types.Common.Vec3>(),
                translate = new Field<Mech3DotNet.Types.Common.Vec3>(),
                diffuse = new Field<float>(),
                ambient = new Field<float>(),
                color = new Field<Mech3DotNet.Types.Common.Color>(),
                colorAmbient = new Field<Mech3DotNet.Types.Common.Color>(),
                colorDiffuseMixed = new Field<Mech3DotNet.Types.Common.Color>(),
                colorAmbientMixed = new Field<Mech3DotNet.Types.Common.Color>(),
                colorDaCombined = new Field<Mech3DotNet.Types.Common.Color>(),
                range = new Field<Mech3DotNet.Types.Common.Range>(),
                parentIndices = new Field<System.Collections.Generic.List<short>>(),
                parentPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "flags":
                        fields.flags.Value = d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.LightFlagsConverter.Converter)();
                        break;
                    case "orientation":
                        fields.orientation.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "translate":
                        fields.translate.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "diffuse":
                        fields.diffuse.Value = d.DeserializeF32();
                        break;
                    case "ambient":
                        fields.ambient.Value = d.DeserializeF32();
                        break;
                    case "color":
                        fields.color.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "color_ambient":
                        fields.colorAmbient.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "color_diffuse_mixed":
                        fields.colorDiffuseMixed.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "color_ambient_mixed":
                        fields.colorAmbientMixed.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "color_da_combined":
                        fields.colorDaCombined.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    case "range":
                        fields.range.Value = d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)();
                        break;
                    case "parent_indices":
                        fields.parentIndices.Value = d.DeserializeVec(d.DeserializeI16)();
                        break;
                    case "parent_ptr":
                        fields.parentPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Light", fieldName);
                }
            }
            return new Light(

                fields.flags.Unwrap("Light", "flags"),

                fields.orientation.Unwrap("Light", "orientation"),

                fields.translate.Unwrap("Light", "translate"),

                fields.diffuse.Unwrap("Light", "diffuse"),

                fields.ambient.Unwrap("Light", "ambient"),

                fields.color.Unwrap("Light", "color"),

                fields.colorAmbient.Unwrap("Light", "colorAmbient"),

                fields.colorDiffuseMixed.Unwrap("Light", "colorDiffuseMixed"),

                fields.colorAmbientMixed.Unwrap("Light", "colorAmbientMixed"),

                fields.colorDaCombined.Unwrap("Light", "colorDaCombined"),

                fields.range.Unwrap("Light", "range"),

                fields.parentIndices.Unwrap("Light", "parentIndices"),

                fields.parentPtr.Unwrap("Light", "parentPtr")

            );
        }

        #endregion
    }
}
