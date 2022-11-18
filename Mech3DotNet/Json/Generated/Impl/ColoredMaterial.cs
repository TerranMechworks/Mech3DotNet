namespace Mech3DotNet.Json.Gamez.Materials
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Materials.Converters.ColoredMaterialConverter))]
    public class ColoredMaterial
    {
        public Mech3DotNet.Json.Types.Color color;
        public byte alpha;
        public float specular;

        public ColoredMaterial(Mech3DotNet.Json.Types.Color color, byte alpha, float specular)
        {
            this.color = color;
            this.alpha = alpha;
            this.specular = specular;
        }
    }
}
