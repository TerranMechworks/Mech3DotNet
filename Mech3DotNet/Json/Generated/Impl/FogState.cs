namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.FogStateConverter))]
    public class FogState
    {
        public string name;
        public Mech3DotNet.Json.Anim.Events.FogType fogType;
        public Mech3DotNet.Json.Types.Color color;
        public Mech3DotNet.Json.Types.Range altitude;
        public Mech3DotNet.Json.Types.Range range;

        public FogState(string name, Mech3DotNet.Json.Anim.Events.FogType fogType, Mech3DotNet.Json.Types.Color color, Mech3DotNet.Json.Types.Range altitude, Mech3DotNet.Json.Types.Range range)
        {
            this.name = name;
            this.fogType = fogType;
            this.color = color;
            this.altitude = altitude;
            this.range = range;
        }
    }
}
