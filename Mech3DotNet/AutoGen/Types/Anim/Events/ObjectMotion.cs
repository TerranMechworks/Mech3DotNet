using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotion
    {
        public string node;
        public bool impactForce;
        public float? morph;
        public Mech3DotNet.Types.Anim.Events.Gravity? gravity;
        public Mech3DotNet.Types.Anim.Events.TranslationRange? translationRange;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation? translation;
        public Mech3DotNet.Types.Anim.Events.ForwardRotation? forwardRotation;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionXyzRot? xyzRotation;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionScale? scale;
        public Mech3DotNet.Types.Anim.Events.BounceSequences? bounceSequence;
        public Mech3DotNet.Types.Anim.Events.BounceSounds? bounceSound;
        public float? runTime;

        public ObjectMotion(string node, bool impactForce, float? morph, Mech3DotNet.Types.Anim.Events.Gravity? gravity, Mech3DotNet.Types.Anim.Events.TranslationRange? translationRange, Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation? translation, Mech3DotNet.Types.Anim.Events.ForwardRotation? forwardRotation, Mech3DotNet.Types.Anim.Events.ObjectMotionXyzRot? xyzRotation, Mech3DotNet.Types.Anim.Events.ObjectMotionScale? scale, Mech3DotNet.Types.Anim.Events.BounceSequences? bounceSequence, Mech3DotNet.Types.Anim.Events.BounceSounds? bounceSound, float? runTime)
        {
            this.node = node;
            this.impactForce = impactForce;
            this.morph = morph;
            this.gravity = gravity;
            this.translationRange = translationRange;
            this.translation = translation;
            this.forwardRotation = forwardRotation;
            this.xyzRotation = xyzRotation;
            this.scale = scale;
            this.bounceSequence = bounceSequence;
            this.bounceSound = bounceSound;
            this.runTime = runTime;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<ObjectMotion> Converter = new TypeConverter<ObjectMotion>(Deserialize, Serialize);

        public static void Serialize(ObjectMotion v, Serializer s)
        {
            s.SerializeStruct(12);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("impact_force");
            ((Action<bool>)s.SerializeBool)(v.impactForce);
            s.SerializeFieldName("morph");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.morph);
            s.SerializeFieldName("gravity");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Gravity.Converter))(v.gravity);
            s.SerializeFieldName("translation_range");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.TranslationRange.Converter))(v.translationRange);
            s.SerializeFieldName("translation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation.Converter))(v.translation);
            s.SerializeFieldName("forward_rotation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ForwardRotation.Converter))(v.forwardRotation);
            s.SerializeFieldName("xyz_rotation");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionXyzRot.Converter))(v.xyzRotation);
            s.SerializeFieldName("scale");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionScale.Converter))(v.scale);
            s.SerializeFieldName("bounce_sequence");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSequences.Converter))(v.bounceSequence);
            s.SerializeFieldName("bounce_sound");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.BounceSounds.Converter))(v.bounceSound);
            s.SerializeFieldName("run_time");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.runTime);
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<bool> impactForce;
            public Field<float?> morph;
            public Field<Mech3DotNet.Types.Anim.Events.Gravity?> gravity;
            public Field<Mech3DotNet.Types.Anim.Events.TranslationRange?> translationRange;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation?> translation;
            public Field<Mech3DotNet.Types.Anim.Events.ForwardRotation?> forwardRotation;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectMotionXyzRot?> xyzRotation;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectMotionScale?> scale;
            public Field<Mech3DotNet.Types.Anim.Events.BounceSequences?> bounceSequence;
            public Field<Mech3DotNet.Types.Anim.Events.BounceSounds?> bounceSound;
            public Field<float?> runTime;
        }

        public static ObjectMotion Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                impactForce = new Field<bool>(),
                morph = new Field<float?>(),
                gravity = new Field<Mech3DotNet.Types.Anim.Events.Gravity?>(),
                translationRange = new Field<Mech3DotNet.Types.Anim.Events.TranslationRange?>(),
                translation = new Field<Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation?>(),
                forwardRotation = new Field<Mech3DotNet.Types.Anim.Events.ForwardRotation?>(),
                xyzRotation = new Field<Mech3DotNet.Types.Anim.Events.ObjectMotionXyzRot?>(),
                scale = new Field<Mech3DotNet.Types.Anim.Events.ObjectMotionScale?>(),
                bounceSequence = new Field<Mech3DotNet.Types.Anim.Events.BounceSequences?>(),
                bounceSound = new Field<Mech3DotNet.Types.Anim.Events.BounceSounds?>(),
                runTime = new Field<float?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "impact_force":
                        fields.impactForce.Value = d.DeserializeBool();
                        break;
                    case "morph":
                        fields.morph.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "gravity":
                        fields.gravity.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Gravity.Converter))();
                        break;
                    case "translation_range":
                        fields.translationRange.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.TranslationRange.Converter))();
                        break;
                    case "translation":
                        fields.translation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionTranslation.Converter))();
                        break;
                    case "forward_rotation":
                        fields.forwardRotation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ForwardRotation.Converter))();
                        break;
                    case "xyz_rotation":
                        fields.xyzRotation.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionXyzRot.Converter))();
                        break;
                    case "scale":
                        fields.scale.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionScale.Converter))();
                        break;
                    case "bounce_sequence":
                        fields.bounceSequence.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSequences.Converter))();
                        break;
                    case "bounce_sound":
                        fields.bounceSound.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.BounceSounds.Converter))();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotion", fieldName);
                }
            }
            return new ObjectMotion(

                fields.node.Unwrap("ObjectMotion", "node"),

                fields.impactForce.Unwrap("ObjectMotion", "impactForce"),

                fields.morph.Unwrap("ObjectMotion", "morph"),

                fields.gravity.Unwrap("ObjectMotion", "gravity"),

                fields.translationRange.Unwrap("ObjectMotion", "translationRange"),

                fields.translation.Unwrap("ObjectMotion", "translation"),

                fields.forwardRotation.Unwrap("ObjectMotion", "forwardRotation"),

                fields.xyzRotation.Unwrap("ObjectMotion", "xyzRotation"),

                fields.scale.Unwrap("ObjectMotion", "scale"),

                fields.bounceSequence.Unwrap("ObjectMotion", "bounceSequence"),

                fields.bounceSound.Unwrap("ObjectMotion", "bounceSound"),

                fields.runTime.Unwrap("ObjectMotion", "runTime")

            );
        }

        #endregion
    }
}
