namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectMotionConverter))]
    public class ObjectMotion
    {
        public string node;
        public bool impactForce;
        public Gravity? gravity = null;
        public Quaternion? translationRangeMin = null;
        public Quaternion? translationRangeMax = null;
        public ObjectMotionTranslation? translation = null;
        public ForwardRotation? forwardRotation = null;
        public XyzRotation? xyzRotation = null;
        public ObjectMotionScale? scale = null;
        public BounceSequence? bounceSequence = null;
        public BounceSound? bounceSound = null;
        public float? runtime = null;

        public ObjectMotion(string node, bool impactForce, Gravity? gravity, Quaternion? translationRangeMin, Quaternion? translationRangeMax, ObjectMotionTranslation? translation, ForwardRotation? forwardRotation, XyzRotation? xyzRotation, ObjectMotionScale? scale, BounceSequence? bounceSequence, BounceSound? bounceSound, float? runtime)
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
