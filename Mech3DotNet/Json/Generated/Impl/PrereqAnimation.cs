namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.PrereqAnimationConverter))]
    public struct PrereqAnimation
    {
        public string name;

        public PrereqAnimation(string name)
        {
            this.name = name;
        }
    }
}
