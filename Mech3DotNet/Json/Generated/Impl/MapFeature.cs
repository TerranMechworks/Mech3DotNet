namespace Mech3DotNet.Json.Zmap
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Zmap.Converters.MapFeatureConverter))]
    public class MapFeature
    {
        public Mech3DotNet.Json.Zmap.MapColor color;
        public System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapVertex> vertices;
        public int objective;

        public MapFeature(Mech3DotNet.Json.Zmap.MapColor color, System.Collections.Generic.List<Mech3DotNet.Json.Zmap.MapVertex> vertices, int objective)
        {
            this.color = color;
            this.vertices = vertices;
            this.objective = objective;
        }
    }
}
