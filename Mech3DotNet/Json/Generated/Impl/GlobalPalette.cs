namespace Mech3DotNet.Json.Image
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Image.Converters.GlobalPaletteConverter))]
    public class GlobalPalette
    {
        public int index;
        public ushort count;

        public GlobalPalette(int index, ushort count)
        {
            this.index = index;
            this.count = count;
        }
    }
}
