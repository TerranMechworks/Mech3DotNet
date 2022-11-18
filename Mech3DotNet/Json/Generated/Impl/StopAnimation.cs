namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.StopAnimationConverter))]
    public class StopAnimation
    {
        public string name;

        public StopAnimation(string name)
        {
            this.name = name;
        }
    }
}
