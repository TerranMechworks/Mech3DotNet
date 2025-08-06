using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionFromTo
    {
        public string name;
        public float runTime;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? morph;
        public Mech3DotNet.Types.Anim.Events.Vec3FromTo? translate;
        public Mech3DotNet.Types.Anim.Events.Vec3FromTo? rotate;
        public Mech3DotNet.Types.Anim.Events.Vec3FromTo? scale;
        public Mech3DotNet.Types.Common.Vec3? translateDelta = null;
        public Mech3DotNet.Types.Common.Vec3? rotateDelta = null;
        public Mech3DotNet.Types.Common.Vec3? scaleDelta = null;

        public ObjectMotionFromTo(string name, float runTime, Mech3DotNet.Types.Anim.Events.FloatFromTo? morph, Mech3DotNet.Types.Anim.Events.Vec3FromTo? translate, Mech3DotNet.Types.Anim.Events.Vec3FromTo? rotate, Mech3DotNet.Types.Anim.Events.Vec3FromTo? scale, Mech3DotNet.Types.Common.Vec3? translateDelta, Mech3DotNet.Types.Common.Vec3? rotateDelta, Mech3DotNet.Types.Common.Vec3? scaleDelta)
        {
            this.name = name;
            this.runTime = runTime;
            this.morph = morph;
            this.translate = translate;
            this.rotate = rotate;
            this.scale = scale;
            this.translateDelta = translateDelta;
            this.rotateDelta = rotateDelta;
            this.scaleDelta = scaleDelta;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ObjectMotionFromTo> Converter = new TypeConverter<ObjectMotionFromTo>(Deserialize, Serialize);

        public static void Serialize(ObjectMotionFromTo v, Serializer s)
        {
            s.SerializeStruct(9);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
            s.SerializeFieldName("morph");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.morph);
            s.SerializeFieldName("translate");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Vec3FromTo.Converter))(v.translate);
            s.SerializeFieldName("rotate");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Vec3FromTo.Converter))(v.rotate);
            s.SerializeFieldName("scale");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Vec3FromTo.Converter))(v.scale);
            s.SerializeFieldName("translate_delta");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.translateDelta);
            s.SerializeFieldName("rotate_delta");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.rotateDelta);
            s.SerializeFieldName("scale_delta");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.scaleDelta);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<float> runTime;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> morph;
            public Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?> translate;
            public Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?> rotate;
            public Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?> scale;
            public Field<Mech3DotNet.Types.Common.Vec3?> translateDelta;
            public Field<Mech3DotNet.Types.Common.Vec3?> rotateDelta;
            public Field<Mech3DotNet.Types.Common.Vec3?> scaleDelta;
        }

        public static ObjectMotionFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                runTime = new Field<float>(),
                morph = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                translate = new Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?>(),
                rotate = new Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?>(),
                scale = new Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?>(),
                translateDelta = new Field<Mech3DotNet.Types.Common.Vec3?>(null),
                rotateDelta = new Field<Mech3DotNet.Types.Common.Vec3?>(null),
                scaleDelta = new Field<Mech3DotNet.Types.Common.Vec3?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    case "morph":
                        fields.morph.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "translate":
                        fields.translate.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Vec3FromTo.Converter))();
                        break;
                    case "rotate":
                        fields.rotate.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Vec3FromTo.Converter))();
                        break;
                    case "scale":
                        fields.scale.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Vec3FromTo.Converter))();
                        break;
                    case "translate_delta":
                        fields.translateDelta.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "rotate_delta":
                        fields.rotateDelta.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "scale_delta":
                        fields.scaleDelta.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionFromTo", fieldName);
                }
            }
            return new ObjectMotionFromTo(

                fields.name.Unwrap("ObjectMotionFromTo", "name"),

                fields.runTime.Unwrap("ObjectMotionFromTo", "runTime"),

                fields.morph.Unwrap("ObjectMotionFromTo", "morph"),

                fields.translate.Unwrap("ObjectMotionFromTo", "translate"),

                fields.rotate.Unwrap("ObjectMotionFromTo", "rotate"),

                fields.scale.Unwrap("ObjectMotionFromTo", "scale"),

                fields.translateDelta.Unwrap("ObjectMotionFromTo", "translateDelta"),

                fields.rotateDelta.Unwrap("ObjectMotionFromTo", "rotateDelta"),

                fields.scaleDelta.Unwrap("ObjectMotionFromTo", "scaleDelta")

            );
        }

        #endregion
    }
}
