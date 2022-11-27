using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotion
    {
        public static readonly TypeConverter<ObjectMotion> Converter = new TypeConverter<ObjectMotion>(Deserialize, Serialize);
        public string node;
        public bool impactForce;
        public Mech3DotNet.Types.Anim.Events.Gravity? gravity = null;
        public Mech3DotNet.Types.Types.Quaternion? translationRangeMin = null;
        public Mech3DotNet.Types.Types.Quaternion? translationRangeMax = null;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation? translation = null;
        public Mech3DotNet.Types.Anim.Events.ForwardRotation? forwardRotation = null;
        public Mech3DotNet.Types.Anim.Events.XyzRotation? xyzRotation = null;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionScale? scale = null;
        public Mech3DotNet.Types.Anim.Events.BounceSequence? bounceSequence = null;
        public Mech3DotNet.Types.Anim.Events.BounceSound? bounceSound = null;
        public float? runtime = null;

        public ObjectMotion(string node, bool impactForce, Mech3DotNet.Types.Anim.Events.Gravity? gravity, Mech3DotNet.Types.Types.Quaternion? translationRangeMin, Mech3DotNet.Types.Types.Quaternion? translationRangeMax, Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation? translation, Mech3DotNet.Types.Anim.Events.ForwardRotation? forwardRotation, Mech3DotNet.Types.Anim.Events.XyzRotation? xyzRotation, Mech3DotNet.Types.Anim.Events.ObjectMotionScale? scale, Mech3DotNet.Types.Anim.Events.BounceSequence? bounceSequence, Mech3DotNet.Types.Anim.Events.BounceSound? bounceSound, float? runtime)
        {
            this.node = node;
            this.impactForce = impactForce;
            this.gravity = gravity;
            this.translationRangeMin = translationRangeMin;
            this.translationRangeMax = translationRangeMax;
            this.translation = translation;
            this.forwardRotation = forwardRotation;
            this.xyzRotation = xyzRotation;
            this.scale = scale;
            this.bounceSequence = bounceSequence;
            this.bounceSound = bounceSound;
            this.runtime = runtime;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<bool> impactForce;
            public Field<Mech3DotNet.Types.Anim.Events.Gravity?> gravity;
            public Field<Mech3DotNet.Types.Types.Quaternion?> translationRangeMin;
            public Field<Mech3DotNet.Types.Types.Quaternion?> translationRangeMax;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation?> translation;
            public Field<Mech3DotNet.Types.Anim.Events.ForwardRotation?> forwardRotation;
            public Field<Mech3DotNet.Types.Anim.Events.XyzRotation?> xyzRotation;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectMotionScale?> scale;
            public Field<Mech3DotNet.Types.Anim.Events.BounceSequence?> bounceSequence;
            public Field<Mech3DotNet.Types.Anim.Events.BounceSound?> bounceSound;
            public Field<float?> runtime;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotion v, Serializer s)
        {
            s.SerializeStruct("ObjectMotion", 12);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("impact_force");
            ((Action<bool>)s.SerializeBool)(v.impactForce);
            s.SerializeFieldName("gravity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Gravity.Converter))(v.gravity);
            s.SerializeFieldName("translation_range_min");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Quaternion.Converter))(v.translationRangeMin);
            s.SerializeFieldName("translation_range_max");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Quaternion.Converter))(v.translationRangeMax);
            s.SerializeFieldName("translation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation.Converter))(v.translation);
            s.SerializeFieldName("forward_rotation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ForwardRotation.Converter))(v.forwardRotation);
            s.SerializeFieldName("xyz_rotation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.XyzRotation.Converter))(v.xyzRotation);
            s.SerializeFieldName("scale");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionScale.Converter))(v.scale);
            s.SerializeFieldName("bounce_sequence");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSequence.Converter))(v.bounceSequence);
            s.SerializeFieldName("bounce_sound");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))(v.bounceSound);
            s.SerializeFieldName("runtime");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.runtime);
        }

        public static Mech3DotNet.Types.Anim.Events.ObjectMotion Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                impactForce = new Field<bool>(),
                gravity = new Field<Mech3DotNet.Types.Anim.Events.Gravity?>(null),
                translationRangeMin = new Field<Mech3DotNet.Types.Types.Quaternion?>(null),
                translationRangeMax = new Field<Mech3DotNet.Types.Types.Quaternion?>(null),
                translation = new Field<Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation?>(null),
                forwardRotation = new Field<Mech3DotNet.Types.Anim.Events.ForwardRotation?>(null),
                xyzRotation = new Field<Mech3DotNet.Types.Anim.Events.XyzRotation?>(null),
                scale = new Field<Mech3DotNet.Types.Anim.Events.ObjectMotionScale?>(null),
                bounceSequence = new Field<Mech3DotNet.Types.Anim.Events.BounceSequence?>(null),
                bounceSound = new Field<Mech3DotNet.Types.Anim.Events.BounceSound?>(null),
                runtime = new Field<float?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectMotion"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "impact_force":
                        fields.impactForce.Value = d.DeserializeBool();
                        break;
                    case "gravity":
                        fields.gravity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Gravity.Converter))();
                        break;
                    case "translation_range_min":
                        fields.translationRangeMin.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Quaternion.Converter))();
                        break;
                    case "translation_range_max":
                        fields.translationRangeMax.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Quaternion.Converter))();
                        break;
                    case "translation":
                        fields.translation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation.Converter))();
                        break;
                    case "forward_rotation":
                        fields.forwardRotation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ForwardRotation.Converter))();
                        break;
                    case "xyz_rotation":
                        fields.xyzRotation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.XyzRotation.Converter))();
                        break;
                    case "scale":
                        fields.scale.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionScale.Converter))();
                        break;
                    case "bounce_sequence":
                        fields.bounceSequence.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSequence.Converter))();
                        break;
                    case "bounce_sound":
                        fields.bounceSound.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSound.Converter))();
                        break;
                    case "runtime":
                        fields.runtime.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotion", fieldName);
                }
            }
            return new ObjectMotion(

                fields.node.Unwrap("ObjectMotion", "node"),

                fields.impactForce.Unwrap("ObjectMotion", "impactForce"),

                fields.gravity.Unwrap("ObjectMotion", "gravity"),

                fields.translationRangeMin.Unwrap("ObjectMotion", "translationRangeMin"),

                fields.translationRangeMax.Unwrap("ObjectMotion", "translationRangeMax"),

                fields.translation.Unwrap("ObjectMotion", "translation"),

                fields.forwardRotation.Unwrap("ObjectMotion", "forwardRotation"),

                fields.xyzRotation.Unwrap("ObjectMotion", "xyzRotation"),

                fields.scale.Unwrap("ObjectMotion", "scale"),

                fields.bounceSequence.Unwrap("ObjectMotion", "bounceSequence"),

                fields.bounceSound.Unwrap("ObjectMotion", "bounceSound"),

                fields.runtime.Unwrap("ObjectMotion", "runtime")

            );
        }
    }
}
