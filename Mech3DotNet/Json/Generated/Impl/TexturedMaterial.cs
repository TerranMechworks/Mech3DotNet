namespace Mech3DotNet.Json.Gamez.Materials
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Materials.Converters.TexturedMaterialConverter))]
    public class TexturedMaterial
    {
        public string texture;
        public uint pointer = 0;
        public Mech3DotNet.Json.Gamez.Materials.CycleData? cycle = null;
        public float specular;
        public bool flag;

        public TexturedMaterial(string texture, uint pointer, Mech3DotNet.Json.Gamez.Materials.CycleData? cycle, float specular, bool flag)
        {
            this.texture = texture;
            this.pointer = pointer;
            this.cycle = cycle;
            this.specular = specular;
            this.flag = flag;
        }
    }
}
