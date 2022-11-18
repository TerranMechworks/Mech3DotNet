namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.InvalidateAnimationConverter))]
    public class InvalidateAnimation
    {
        public string name;

        public InvalidateAnimation(string name)
        {
            this.name = name;
        }
    }
}
