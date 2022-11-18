namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.InvalidateAnimationConverter))]
    public class InvalidateAnimation
    {
        public string name;

        public InvalidateAnimation(string name)
        {
            this.name = name;
        }
    }
}
