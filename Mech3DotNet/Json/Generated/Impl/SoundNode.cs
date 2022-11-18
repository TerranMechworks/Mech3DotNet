namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.SoundNodeConverter))]
    public class SoundNode
    {
        public string name;
        public bool activeState;
        public Mech3DotNet.Json.Anim.Events.AtNode? atNode = null;

        public SoundNode(string name, bool activeState, Mech3DotNet.Json.Anim.Events.AtNode? atNode)
        {
            this.name = name;
            this.activeState = activeState;
            this.atNode = atNode;
        }
    }
}
