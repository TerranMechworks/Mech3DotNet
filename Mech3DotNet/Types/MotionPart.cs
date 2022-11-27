using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Motion
{
    public sealed class MotionPart<TQuaternion, TVec3>
        where TQuaternion : notnull
        where TVec3 : notnull
    {
        public static readonly TypeConverter<MotionPart<TQuaternion, TVec3>> Converter = new TypeConverter<MotionPart<TQuaternion, TVec3>>(Deserialize, Serialize);
        public string name;
        public System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionFrame<TQuaternion, TVec3>> frames;

        public MotionPart(string name, System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionFrame<TQuaternion, TVec3>> frames)
        {
            this.name = name;
            this.frames = frames;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionFrame<TQuaternion, TVec3>>> frames;
        }

        public static void Serialize(Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3> v, Serializer s)
        {
            s.SerializeStruct("MotionPart", 2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("frames");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Motion.MotionFrame<TQuaternion, TVec3>.Converter))(v.frames);
        }

        public static Mech3DotNet.Types.Motion.MotionPart<TQuaternion, TVec3> Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                frames = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Motion.MotionFrame<TQuaternion, TVec3>>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("MotionPart"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "frames":
                        fields.frames.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Motion.MotionFrame<TQuaternion, TVec3>.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("MotionPart", fieldName);
                }
            }
            return new MotionPart<TQuaternion, TVec3>(

                fields.name.Unwrap("MotionPart", "name"),

                fields.frames.Unwrap("MotionPart", "frames")

            );
        }
    }
}
