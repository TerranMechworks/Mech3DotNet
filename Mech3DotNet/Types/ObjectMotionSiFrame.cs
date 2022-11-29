using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionSiFrame
    {
        public static readonly TypeConverter<ObjectMotionSiFrame> Converter = new TypeConverter<ObjectMotionSiFrame>(Deserialize, Serialize);
        public float startTime;
        public float endTime;
        public Mech3DotNet.Types.Anim.Events.TranslateData? translation = null;
        public Mech3DotNet.Types.Anim.Events.RotateData? rotation = null;
        public Mech3DotNet.Types.Anim.Events.ScaleData? scale = null;

        public ObjectMotionSiFrame(float startTime, float endTime, Mech3DotNet.Types.Anim.Events.TranslateData? translation, Mech3DotNet.Types.Anim.Events.RotateData? rotation, Mech3DotNet.Types.Anim.Events.ScaleData? scale)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.translation = translation;
            this.rotation = rotation;
            this.scale = scale;
        }

        private struct Fields
        {
            public Field<float> startTime;
            public Field<float> endTime;
            public Field<Mech3DotNet.Types.Anim.Events.TranslateData?> translation;
            public Field<Mech3DotNet.Types.Anim.Events.RotateData?> rotation;
            public Field<Mech3DotNet.Types.Anim.Events.ScaleData?> scale;
        }

        public static void Serialize(ObjectMotionSiFrame v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("start_time");
            ((Action<float>)s.SerializeF32)(v.startTime);
            s.SerializeFieldName("end_time");
            ((Action<float>)s.SerializeF32)(v.endTime);
            s.SerializeFieldName("translation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.TranslateData.Converter))(v.translation);
            s.SerializeFieldName("rotation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.RotateData.Converter))(v.rotation);
            s.SerializeFieldName("scale");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ScaleData.Converter))(v.scale);
        }

        public static ObjectMotionSiFrame Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                startTime = new Field<float>(),
                endTime = new Field<float>(),
                translation = new Field<Mech3DotNet.Types.Anim.Events.TranslateData?>(null),
                rotation = new Field<Mech3DotNet.Types.Anim.Events.RotateData?>(null),
                scale = new Field<Mech3DotNet.Types.Anim.Events.ScaleData?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "start_time":
                        fields.startTime.Value = d.DeserializeF32();
                        break;
                    case "end_time":
                        fields.endTime.Value = d.DeserializeF32();
                        break;
                    case "translation":
                        fields.translation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.TranslateData.Converter))();
                        break;
                    case "rotation":
                        fields.rotation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.RotateData.Converter))();
                        break;
                    case "scale":
                        fields.scale.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ScaleData.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionSiFrame", fieldName);
                }
            }
            return new ObjectMotionSiFrame(

                fields.startTime.Unwrap("ObjectMotionSiFrame", "startTime"),

                fields.endTime.Unwrap("ObjectMotionSiFrame", "endTime"),

                fields.translation.Unwrap("ObjectMotionSiFrame", "translation"),

                fields.rotation.Unwrap("ObjectMotionSiFrame", "rotation"),

                fields.scale.Unwrap("ObjectMotionSiFrame", "scale")

            );
        }
    }
}
