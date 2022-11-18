namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.LightAnimationConverter))]
    public class LightAnimation
    {
        public string name;
        public Mech3DotNet.Json.Types.Range range;
        public Mech3DotNet.Json.Types.Color color;
        public float runtime;

        public LightAnimation(string name, Mech3DotNet.Json.Types.Range range, Mech3DotNet.Json.Types.Color color, float runtime)
        {
            this.name = name;
            this.range = range;
            this.color = color;
            this.runtime = runtime;
        }
    }
}
