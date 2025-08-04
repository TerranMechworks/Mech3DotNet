using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.SiScript
{
    public sealed class ObjectMotionSiFrame
    {
        public static readonly TypeConverter<ObjectMotionSiFrame> Converter = new TypeConverter<ObjectMotionSiFrame>(Deserialize, Serialize);
        public float startTime;
        public float endTime;
        public Mech3DotNet.Types.Anim.SiScript.TranslateData? translate = null;
        public Mech3DotNet.Types.Anim.SiScript.RotateData? rotate = null;
        public Mech3DotNet.Types.Anim.SiScript.ScaleData? scale = null;

        public ObjectMotionSiFrame(float startTime, float endTime, Mech3DotNet.Types.Anim.SiScript.TranslateData? translate, Mech3DotNet.Types.Anim.SiScript.RotateData? rotate, Mech3DotNet.Types.Anim.SiScript.ScaleData? scale)
        {
            this.startTime = startTime;
            this.endTime = endTime;
            this.translate = translate;
            this.rotate = rotate;
            this.scale = scale;
        }

        private struct Fields
        {
            public Field<float> startTime;
            public Field<float> endTime;
            public Field<Mech3DotNet.Types.Anim.SiScript.TranslateData?> translate;
            public Field<Mech3DotNet.Types.Anim.SiScript.RotateData?> rotate;
            public Field<Mech3DotNet.Types.Anim.SiScript.ScaleData?> scale;
        }

        public static void Serialize(ObjectMotionSiFrame v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("start_time");
            ((Action<float>)s.SerializeF32)(v.startTime);
            s.SerializeFieldName("end_time");
            ((Action<float>)s.SerializeF32)(v.endTime);
            s.SerializeFieldName("translate");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.SiScript.TranslateData.Converter))(v.translate);
            s.SerializeFieldName("rotate");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.SiScript.RotateData.Converter))(v.rotate);
            s.SerializeFieldName("scale");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.SiScript.ScaleData.Converter))(v.scale);
        }

        public static ObjectMotionSiFrame Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                startTime = new Field<float>(),
                endTime = new Field<float>(),
                translate = new Field<Mech3DotNet.Types.Anim.SiScript.TranslateData?>(null),
                rotate = new Field<Mech3DotNet.Types.Anim.SiScript.RotateData?>(null),
                scale = new Field<Mech3DotNet.Types.Anim.SiScript.ScaleData?>(null),
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
                    case "translate":
                        fields.translate.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.SiScript.TranslateData.Converter))();
                        break;
                    case "rotate":
                        fields.rotate.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.SiScript.RotateData.Converter))();
                        break;
                    case "scale":
                        fields.scale.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.SiScript.ScaleData.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionSiFrame", fieldName);
                }
            }
            return new ObjectMotionSiFrame(

                fields.startTime.Unwrap("ObjectMotionSiFrame", "startTime"),

                fields.endTime.Unwrap("ObjectMotionSiFrame", "endTime"),

                fields.translate.Unwrap("ObjectMotionSiFrame", "translate"),

                fields.rotate.Unwrap("ObjectMotionSiFrame", "rotate"),

                fields.scale.Unwrap("ObjectMotionSiFrame", "scale")

            );
        }
    }
}
