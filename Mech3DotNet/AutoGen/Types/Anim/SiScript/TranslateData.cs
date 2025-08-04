using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.SiScript
{
    public sealed class TranslateData
    {
        public static readonly TypeConverter<TranslateData> Converter = new TypeConverter<TranslateData>(Deserialize, Serialize);
        public Mech3DotNet.Types.Common.Vec3 base_;
        public Mech3DotNet.Types.Common.Vec3 delta;
        public uint garbage;
        public byte[] splineX;
        public byte[] splineY;
        public byte[] splineZ;

        public TranslateData(Mech3DotNet.Types.Common.Vec3 base_, Mech3DotNet.Types.Common.Vec3 delta, uint garbage, byte[] splineX, byte[] splineY, byte[] splineZ)
        {
            this.base_ = base_;
            this.delta = delta;
            this.garbage = garbage;
            this.splineX = splineX;
            this.splineY = splineY;
            this.splineZ = splineZ;
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

        public static void Serialize(TranslateData v, Serializer s)
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

        public static TranslateData Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("TranslateData", fieldName);
                }
            }
            return new TranslateData(

                fields.base_.Unwrap("TranslateData", "base_"),

                fields.delta.Unwrap("TranslateData", "delta"),

                fields.garbage.Unwrap("TranslateData", "garbage"),

                fields.splineX.Unwrap("TranslateData", "splineX"),

                fields.splineY.Unwrap("TranslateData", "splineY"),

                fields.splineZ.Unwrap("TranslateData", "splineZ")

            );
        }
    }
}
