namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ResetAnimationConverter))]
    public class ResetAnimation
    {
        public string name;

        public ResetAnimation(string name)
        {
            this.name = name;
        }
    }
}
