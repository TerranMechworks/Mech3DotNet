namespace Mech3DotNet.Json.Gamez.Nodes
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Gamez.Nodes.Converters.WindowConverter))]
    public class Window
    {
        public string name;
        public uint resolutionX;
        public uint resolutionY;
        public uint dataPtr;

        public Window(string name, uint resolutionX, uint resolutionY, uint dataPtr)
        {
            this.name = name;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.dataPtr = dataPtr;
        }
    }
}
