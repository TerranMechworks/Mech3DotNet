using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.SiScript
{
    public sealed class RotateData
    {
        public Mech3DotNet.Types.Common.Quaternion base_;
        public Mech3DotNet.Types.Common.Vec3 delta;
        public byte[] splineX;
        public byte[] splineY;
        public byte[] splineZ;

        public RotateData(Mech3DotNet.Types.Common.Quaternion base_, Mech3DotNet.Types.Common.Vec3 delta, byte[] splineX, byte[] splineY, byte[] splineZ)
        {
            this.base_ = base_;
            this.delta = delta;
            this.splineX = splineX;
            this.splineY = splineY;
            this.splineZ = splineZ;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<RotateData> Converter = new TypeConverter<RotateData>(Deserialize, Serialize);

        public static void Serialize(RotateData v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("base");
            s.Serialize(Mech3DotNet.Types.Common.QuaternionConverter.Converter)(v.base_);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.delta);
            s.SerializeFieldName("spline_x");
            ((Action<byte[]>)s.SerializeBytes)(v.splineX);
            s.SerializeFieldName("spline_y");
            ((Action<byte[]>)s.SerializeBytes)(v.splineY);
            s.SerializeFieldName("spline_z");
            ((Action<byte[]>)s.SerializeBytes)(v.splineZ);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Quaternion> base_;
            public Field<Mech3DotNet.Types.Common.Vec3> delta;
            public Field<byte[]> splineX;
            public Field<byte[]> splineY;
            public Field<byte[]> splineZ;
        }

        public static RotateData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                base_ = new Field<Mech3DotNet.Types.Common.Quaternion>(),
                delta = new Field<Mech3DotNet.Types.Common.Vec3>(),
                splineX = new Field<byte[]>(),
                splineY = new Field<byte[]>(),
                splineZ = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "base":
                        fields.base_.Value = d.Deserialize(Mech3DotNet.Types.Common.QuaternionConverter.Converter)();
                        break;
                    case "delta":
                        fields.delta.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "spline_x":
                        fields.splineX.Value = d.DeserializeBytes();
                        break;
                    case "spline_y":
                        fields.splineY.Value = d.DeserializeBytes();
                        break;
                    case "spline_z":
                        fields.splineZ.Value = d.DeserializeBytes();
                        break;
                    default:
                        throw new UnknownFieldException("RotateData", fieldName);
                }
            }
            return new RotateData(

                fields.base_.Unwrap("RotateData", "base_"),

                fields.delta.Unwrap("RotateData", "delta"),

                fields.splineX.Unwrap("RotateData", "splineX"),

                fields.splineY.Unwrap("RotateData", "splineY"),

                fields.splineZ.Unwrap("RotateData", "splineZ")

            );
        }

        #endregion
    }
}
