namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectMotionFromToConverter))]
    public class ObjectMotionFromTo
    {
        public string node;
        public float runTime;
        public Mech3DotNet.Json.Anim.Events.FloatFromTo? morph = null;
        public Mech3DotNet.Json.Anim.Events.Vec3FromTo? translate = null;
        public Mech3DotNet.Json.Anim.Events.Vec3FromTo? rotate = null;
        public Mech3DotNet.Json.Anim.Events.Vec3FromTo? scale = null;

        public ObjectMotionFromTo(string node, float runTime, Mech3DotNet.Json.Anim.Events.FloatFromTo? morph, Mech3DotNet.Json.Anim.Events.Vec3FromTo? translate, Mech3DotNet.Json.Anim.Events.Vec3FromTo? rotate, Mech3DotNet.Json.Anim.Events.Vec3FromTo? scale)
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
