namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.ObjectMotionSiScriptConverter))]
    public class ObjectMotionSiScript
    {
        public string node;
        public System.Collections.Generic.List<ObjectMotionSiFrame> frames;

        public ObjectMotionSiScript(string node, System.Collections.Generic.List<ObjectMotionSiFrame> frames)
        {
            this.node = node;
            this.frames = frames;
        }
    }
}
