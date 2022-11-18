namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ResetAnimationConverter))]
    public class ResetAnimation
    {
        public string name;

        public ResetAnimation(string name)
        {
            this.name = name;
        }
    }
}
