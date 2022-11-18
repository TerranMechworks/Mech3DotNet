namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.LightAnimationConverter))]
    public class LightAnimation
    {
        public string name;
        public Range range;
        public Color color;
        public float runtime;

        public LightAnimation(string name, Range range, Color color, float runtime)
        {
            this.name = name;
            this.range = range;
            this.color = color;
            this.runtime = runtime;
        }
    }
}
