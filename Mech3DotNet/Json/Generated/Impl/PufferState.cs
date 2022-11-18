namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.PufferStateConverter))]
    public class PufferState
    {
        public string name;
        public bool state;
        public bool translate;
        public int? activeState = null;
        public Mech3DotNet.Json.Anim.Events.AtNode? atNode = null;
        public Mech3DotNet.Json.Types.Vec3? localVelocity = null;
        public Mech3DotNet.Json.Types.Vec3? worldVelocity = null;
        public Mech3DotNet.Json.Types.Vec3? minRandomVelocity = null;
        public Mech3DotNet.Json.Types.Vec3? maxRandomVelocity = null;
        public Mech3DotNet.Json.Types.Vec3? worldAcceleration = null;
        public Mech3DotNet.Json.Anim.Events.Interval interval;
        public Mech3DotNet.Json.Types.Range? sizeRange = null;
        public Mech3DotNet.Json.Types.Range? lifetimeRange = null;
        public Mech3DotNet.Json.Types.Range? startAgeRange = null;
        public float? deviationDistance = null;
        public Mech3DotNet.Json.Types.Range? fadeRange = null;
        public float? friction = null;
        public Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures? textures = null;
        public float? growthFactor = null;

        public PufferState(string name, bool state, bool translate, int? activeState, Mech3DotNet.Json.Anim.Events.AtNode? atNode, Mech3DotNet.Json.Types.Vec3? localVelocity, Mech3DotNet.Json.Types.Vec3? worldVelocity, Mech3DotNet.Json.Types.Vec3? minRandomVelocity, Mech3DotNet.Json.Types.Vec3? maxRandomVelocity, Mech3DotNet.Json.Types.Vec3? worldAcceleration, Mech3DotNet.Json.Anim.Events.Interval interval, Mech3DotNet.Json.Types.Range? sizeRange, Mech3DotNet.Json.Types.Range? lifetimeRange, Mech3DotNet.Json.Types.Range? startAgeRange, float? deviationDistance, Mech3DotNet.Json.Types.Range? fadeRange, float? friction, Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures? textures, float? growthFactor)
        {
            this.name = name;
            this.state = state;
            this.translate = translate;
            this.activeState = activeState;
            this.atNode = atNode;
            this.localVelocity = localVelocity;
            this.worldVelocity = worldVelocity;
            this.minRandomVelocity = minRandomVelocity;
            this.maxRandomVelocity = maxRandomVelocity;
            this.worldAcceleration = worldAcceleration;
            this.interval = interval;
            this.sizeRange = sizeRange;
            this.lifetimeRange = lifetimeRange;
            this.startAgeRange = startAgeRange;
            this.deviationDistance = deviationDistance;
            this.fadeRange = fadeRange;
            this.friction = friction;
            this.textures = textures;
            this.growthFactor = growthFactor;
        }
    }
}
