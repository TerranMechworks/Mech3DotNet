namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.SoundNodeConverter))]
    public class SoundNode
    {
        public string name;
        public bool activeState;
        public AtNode? atNode = null;

        public SoundNode(string name, bool activeState, AtNode? atNode)
        {
            this.name = name;
            this.activeState = activeState;
            this.atNode = atNode;
        }
    }
}
