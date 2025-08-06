using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class RotateTranslateScale
    {
        public Mech3DotNet.Types.Common.Vec3 rotate;
        public Mech3DotNet.Types.Common.Vec3 translate;
        public Mech3DotNet.Types.Common.Vec3 scale;
        public Mech3DotNet.Types.Common.AffineMatrix? original;

        public RotateTranslateScale(Mech3DotNet.Types.Common.Vec3 rotate, Mech3DotNet.Types.Common.Vec3 translate, Mech3DotNet.Types.Common.Vec3 scale, Mech3DotNet.Types.Common.AffineMatrix? original)
        {
            this.rotate = rotate;
            this.translate = translate;
            this.scale = scale;
            this.original = original;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<RotateTranslateScale> Converter = new TypeConverter<RotateTranslateScale>(Deserialize, Serialize);

        public static void Serialize(RotateTranslateScale v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("rotate");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.rotate);
            s.SerializeFieldName("translate");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.translate);
            s.SerializeFieldName("scale");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.scale);
            s.SerializeFieldName("original");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Common.AffineMatrix.Converter))(v.original);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Vec3> rotate;
            public Field<Mech3DotNet.Types.Common.Vec3> translate;
            public Field<Mech3DotNet.Types.Common.Vec3> scale;
            public Field<Mech3DotNet.Types.Common.AffineMatrix?> original;
        }

        public static RotateTranslateScale Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                rotate = new Field<Mech3DotNet.Types.Common.Vec3>(),
                translate = new Field<Mech3DotNet.Types.Common.Vec3>(),
                scale = new Field<Mech3DotNet.Types.Common.Vec3>(),
                original = new Field<Mech3DotNet.Types.Common.AffineMatrix?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "rotate":
                        fields.rotate.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "translate":
                        fields.translate.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "scale":
                        fields.scale.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "original":
                        fields.original.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Common.AffineMatrix.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("RotateTranslateScale", fieldName);
                }
            }
            return new RotateTranslateScale(

                fields.rotate.Unwrap("RotateTranslateScale", "rotate"),

                fields.translate.Unwrap("RotateTranslateScale", "translate"),

                fields.scale.Unwrap("RotateTranslateScale", "scale"),

                fields.original.Unwrap("RotateTranslateScale", "original")

            );
        }

        #endregion
    }
}
