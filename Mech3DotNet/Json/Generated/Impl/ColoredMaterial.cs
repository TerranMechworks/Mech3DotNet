namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ColoredMaterialConverter))]
    public class ColoredMaterial
    {
        public Color color;
        public byte alpha;
        public float specular;

        public ColoredMaterial(Color color, byte alpha, float specular)
        {
            this.color = color;
            this.alpha = alpha;
            this.specular = specular;
        }
    }
}
