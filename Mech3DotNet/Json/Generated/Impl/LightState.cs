namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.LightStateConverter))]
    public class LightState
    {
        public string name;
        public bool activeState;
        public bool? directional = null;
        public bool? saturated = null;
        public bool? subdivide = null;
        public bool? static_ = null;
        public AtNode? atNode = null;
        public Range? range = null;
        public Color? color = null;
        public float? ambient = null;
        public float? diffuse = null;

        public LightState(string name, bool activeState, bool? directional, bool? saturated, bool? subdivide, bool? static_, AtNode? atNode, Range? range, Color? color, float? ambient, float? diffuse)
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
