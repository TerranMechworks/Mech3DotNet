namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectMotionFromToConverter))]
    public class ObjectMotionFromTo
    {
        public string node;
        public float runTime;
        public FloatFromTo? morph = null;
        public Vec3FromTo? translate = null;
        public Vec3FromTo? rotate = null;
        public Vec3FromTo? scale = null;

        public ObjectMotionFromTo(string node, float runTime, FloatFromTo? morph, Vec3FromTo? translate, Vec3FromTo? rotate, Vec3FromTo? scale)
        {
            this.node = node;
            this.runTime = runTime;
            this.morph = morph;
            this.translate = translate;
            this.rotate = rotate;
            this.scale = scale;
        }
    }
}
