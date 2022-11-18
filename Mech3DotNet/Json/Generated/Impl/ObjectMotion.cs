namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectMotionConverter))]
    public class ObjectMotion
    {
        public string node;
        public bool impactForce;
        public Mech3DotNet.Json.Anim.Events.Gravity? gravity = null;
        public Mech3DotNet.Json.Types.Quaternion? translationRangeMin = null;
        public Mech3DotNet.Json.Types.Quaternion? translationRangeMax = null;
        public Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation? translation = null;
        public Mech3DotNet.Json.Anim.Events.ForwardRotation? forwardRotation = null;
        public Mech3DotNet.Json.Anim.Events.XyzRotation? xyzRotation = null;
        public Mech3DotNet.Json.Anim.Events.ObjectMotionScale? scale = null;
        public Mech3DotNet.Json.Anim.Events.BounceSequence? bounceSequence = null;
        public Mech3DotNet.Json.Anim.Events.BounceSound? bounceSound = null;
        public float? runtime = null;

        public ObjectMotion(string node, bool impactForce, Mech3DotNet.Json.Anim.Events.Gravity? gravity, Mech3DotNet.Json.Types.Quaternion? translationRangeMin, Mech3DotNet.Json.Types.Quaternion? translationRangeMax, Mech3DotNet.Json.Anim.Events.ObjectMotionTranslation? translation, Mech3DotNet.Json.Anim.Events.ForwardRotation? forwardRotation, Mech3DotNet.Json.Anim.Events.XyzRotation? xyzRotation, Mech3DotNet.Json.Anim.Events.ObjectMotionScale? scale, Mech3DotNet.Json.Anim.Events.BounceSequence? bounceSequence, Mech3DotNet.Json.Anim.Events.BounceSound? bounceSound, float? runtime)
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
    }
}
