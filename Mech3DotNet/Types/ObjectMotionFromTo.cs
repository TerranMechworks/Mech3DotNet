using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionFromTo
    {
        public static readonly TypeConverter<ObjectMotionFromTo> Converter = new TypeConverter<ObjectMotionFromTo>(Deserialize, Serialize);
        public string node;
        public float runTime;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? morph = null;
        public Mech3DotNet.Types.Anim.Events.Vec3FromTo? translate = null;
        public Mech3DotNet.Types.Anim.Events.Vec3FromTo? rotate = null;
        public Mech3DotNet.Types.Anim.Events.Vec3FromTo? scale = null;

        public ObjectMotionFromTo(string node, float runTime, Mech3DotNet.Types.Anim.Events.FloatFromTo? morph, Mech3DotNet.Types.Anim.Events.Vec3FromTo? translate, Mech3DotNet.Types.Anim.Events.Vec3FromTo? rotate, Mech3DotNet.Types.Anim.Events.Vec3FromTo? scale)
        {
            this.node = node;
            this.runTime = runTime;
            this.morph = morph;
            this.translate = translate;
            this.rotate = rotate;
            this.scale = scale;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<float> runTime;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> morph;
            public Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?> translate;
            public Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?> rotate;
            public Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?> scale;
        }

        public static void Serialize(ObjectMotionFromTo v, Serializer s)
        {
            s.SerializeStruct("ObjectMotionFromTo", 6);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
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
        }

        public static ObjectMotionFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                runTime = new Field<float>(),
                morph = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(null),
                translate = new Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?>(null),
                rotate = new Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?>(null),
                scale = new Field<Mech3DotNet.Types.Anim.Events.Vec3FromTo?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectMotionFromTo"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
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
                    default:
                        throw new UnknownFieldException("ObjectMotionFromTo", fieldName);
                }
            }
            return new ObjectMotionFromTo(

                fields.node.Unwrap("ObjectMotionFromTo", "node"),

                fields.runTime.Unwrap("ObjectMotionFromTo", "runTime"),

                fields.morph.Unwrap("ObjectMotionFromTo", "morph"),

                fields.translate.Unwrap("ObjectMotionFromTo", "translate"),

                fields.rotate.Unwrap("ObjectMotionFromTo", "rotate"),

                fields.scale.Unwrap("ObjectMotionFromTo", "scale")

            );
        }
    }
}
