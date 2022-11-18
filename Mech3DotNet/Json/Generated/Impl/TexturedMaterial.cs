namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.TexturedMaterialConverter))]
    public class TexturedMaterial
    {
        public string texture;
        public uint pointer = 0;
        public CycleData? cycle = null;
        public float specular;
        public bool flag;

        public TexturedMaterial(string texture, uint pointer, CycleData? cycle, float specular, bool flag)
        {
            this.texture = texture;
            this.pointer = pointer;
            this.cycle = cycle;
            this.specular = specular;
            this.flag = flag;
        }
    }
}
