namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.ObjectMotionSiScriptConverter))]
    public class ObjectMotionSiScript
    {
        public string node;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.ObjectMotionSiFrame> frames;

        public ObjectMotionSiScript(string node, System.Collections.Generic.List<Mech3DotNet.Json.Anim.Events.ObjectMotionSiFrame> frames)
        {
            this.node = node;
            this.frames = frames;
        }
    }
}
