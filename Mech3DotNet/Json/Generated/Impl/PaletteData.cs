namespace Mech3DotNet.Json.Image
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Image.Converters.PaletteDataConverter))]
    public class PaletteData
    {
        public byte[] data;

        public PaletteData(byte[] data)
        {
            this.data = data;
        }
    }
}
