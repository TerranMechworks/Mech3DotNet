namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.MapFeatureConverter))]
    public class MapFeature
    {
        public MapColor color;
        public System.Collections.Generic.List<MapVertex> vertices;
        public int objective;

        public MapFeature(MapColor color, System.Collections.Generic.List<MapVertex> vertices, int objective)
        {
            this.color = color;
            this.vertices = vertices;
            this.objective = objective;
        }
    }
}
