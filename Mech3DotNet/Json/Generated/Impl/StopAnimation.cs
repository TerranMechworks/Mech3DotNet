namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.StopAnimationConverter))]
    public class StopAnimation
    {
        public string name;

        public StopAnimation(string name)
        {
            this.name = name;
        }
    }
}
