using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Motion
{
    public sealed class Motion<TQuaternion, TVec3>
        where TQuaternion : notnull
        where TVec3 : notnull
    {
        public static readonly TypeConverter<Motion<TQuaternion, TVec3>> Converter = new TypeConverter<Motion<TQuaternion, TVec3>>(Deserialize, Serialize);
        public float loopTime;
        public System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3>> parts;
        public uint frameCount;

        public Motion(float loopTime, System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3>> parts, uint frameCount)
        {
            this.loopTime = loopTime;
            this.parts = parts;
            this.frameCount = frameCount;
        }

        private struct Fields
        {
            public Field<float> loopTime;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3>>> parts;
            public Field<uint> frameCount;
        }

        public static void Serialize(Motion<TQuaternion, TVec3> v, Serializer s)
        {
            s.SerializeStruct("Motion", 3);
            s.SerializeFieldName("loop_time");
            ((Action<float>)s.SerializeF32)(v.loopTime);
            s.SerializeFieldName("parts");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3>.Converter))(v.parts);
            s.SerializeFieldName("frame_count");
            ((Action<uint>)s.SerializeU32)(v.frameCount);
        }

        public static Motion<TQuaternion, TVec3> Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                loopTime = new Field<float>(),
                parts = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3>>>(),
                frameCount = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Motion"))
            {
                switch (fieldName)
                {
                    case "loop_time":
                        fields.loopTime.Value = d.DeserializeF32();
                        break;
                    case "parts":
                        fields.parts.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3>.Converter))();
                        break;
                    case "frame_count":
                        fields.frameCount.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Motion", fieldName);
                }
            }
            return new Motion<TQuaternion, TVec3>(

                fields.loopTime.Unwrap("Motion", "loopTime"),

                fields.parts.Unwrap("Motion", "parts"),

                fields.frameCount.Unwrap("Motion", "frameCount")

            );
        }
    }
}
