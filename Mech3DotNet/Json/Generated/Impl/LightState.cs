namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.LightStateConverter))]
    public class LightState
    {
        public string name;
        public bool activeState;
        public bool? directional = null;
        public bool? saturated = null;
        public bool? subdivide = null;
        public bool? static_ = null;
        public Mech3DotNet.Json.Anim.Events.AtNode? atNode = null;
        public Mech3DotNet.Json.Types.Range? range = null;
        public Mech3DotNet.Json.Types.Color? color = null;
        public float? ambient = null;
        public float? diffuse = null;

        public LightState(string name, bool activeState, bool? directional, bool? saturated, bool? subdivide, bool? static_, Mech3DotNet.Json.Anim.Events.AtNode? atNode, Mech3DotNet.Json.Types.Range? range, Mech3DotNet.Json.Types.Color? color, float? ambient, float? diffuse)
        {
            this.name = name;
            this.activeState = activeState;
            this.directional = directional;
            this.saturated = saturated;
            this.subdivide = subdivide;
            this.static_ = static_;
            this.atNode = atNode;
            this.range = range;
            this.color = color;
            this.ambient = ambient;
            this.diffuse = diffuse;
        }
    }
}
