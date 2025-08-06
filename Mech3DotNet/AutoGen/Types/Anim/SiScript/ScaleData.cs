using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.SiScript
{
    public sealed class ScaleData
    {
        public Mech3DotNet.Types.Common.Vec3 base_;
        public Mech3DotNet.Types.Common.Vec3 delta;
        public uint garbage;
        public byte[] splineX;
        public byte[] splineY;
        public byte[] splineZ;

        public ScaleData(Mech3DotNet.Types.Common.Vec3 base_, Mech3DotNet.Types.Common.Vec3 delta, uint garbage, byte[] splineX, byte[] splineY, byte[] splineZ)
        {
            this.base_ = base_;
            this.delta = delta;
            this.garbage = garbage;
            this.splineX = splineX;
            this.splineY = splineY;
            this.splineZ = splineZ;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ScaleData> Converter = new TypeConverter<ScaleData>(Deserialize, Serialize);

        public static void Serialize(ScaleData v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("base");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.base_);
            s.SerializeFieldName("delta");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.delta);
            s.SerializeFieldName("garbage");
            ((Action<uint>)s.SerializeU32)(v.garbage);
            s.SerializeFieldName("spline_x");
            ((Action<byte[]>)s.SerializeBytes)(v.splineX);
            s.SerializeFieldName("spline_y");
            ((Action<byte[]>)s.SerializeBytes)(v.splineY);
            s.SerializeFieldName("spline_z");
            ((Action<byte[]>)s.SerializeBytes)(v.splineZ);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Common.Vec3> base_;
            public Field<Mech3DotNet.Types.Common.Vec3> delta;
            public Field<uint> garbage;
            public Field<byte[]> splineX;
            public Field<byte[]> splineY;
            public Field<byte[]> splineZ;
        }

        public static ScaleData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                base_ = new Field<Mech3DotNet.Types.Common.Vec3>(),
                delta = new Field<Mech3DotNet.Types.Common.Vec3>(),
                garbage = new Field<uint>(),
                splineX = new Field<byte[]>(),
                splineY = new Field<byte[]>(),
                splineZ = new Field<byte[]>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "base":
                        fields.base_.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "delta":
                        fields.delta.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    case "garbage":
                        fields.garbage.Value = d.DeserializeU32();
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
                        throw new UnknownFieldException("ScaleData", fieldName);
                }
            }
            return new ScaleData(

                fields.base_.Unwrap("ScaleData", "base_"),

                fields.delta.Unwrap("ScaleData", "delta"),

                fields.garbage.Unwrap("ScaleData", "garbage"),

                fields.splineX.Unwrap("ScaleData", "splineX"),

                fields.splineY.Unwrap("ScaleData", "splineY"),

                fields.splineZ.Unwrap("ScaleData", "splineZ")

            );
        }

        #endregion
    }
}
