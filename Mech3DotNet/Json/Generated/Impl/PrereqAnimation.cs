namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.PrereqAnimationConverter))]
    public struct PrereqAnimation
    {
        public string name;

        public PrereqAnimation(string name)
        {
            this.name = name;
        }
    }
}
