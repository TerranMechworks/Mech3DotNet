using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class MotionFrame<V3, V4>
    {
        [JsonProperty("translation", Required = Required.Always)]
        public V3 translation;
        [JsonProperty("rotation", Required = Required.Always)]
        public V4 rotation;

        public MotionFrame(V3 translation, V4 rotation)
        {
            this.translation = translation;
            this.rotation = rotation;
        }

        [JsonConstructor]
        private MotionFrame() { }
    }
}
