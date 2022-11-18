namespace Mech3DotNet.Json.Gamez.Nodes
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Nodes.Converters.DisplayConverter))]
    public class Display
    {
        public string name;
        public uint resolutionX;
        public uint resolutionY;
        public Mech3DotNet.Json.Types.Color clearColor;
        public uint dataPtr;

        public Display(string name, uint resolutionX, uint resolutionY, Mech3DotNet.Json.Types.Color clearColor, uint dataPtr)
        {
            this.name = name;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.clearColor = clearColor;
            this.dataPtr = dataPtr;
        }
    }
}
