namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.CameraConverter))]
    public class Camera
    {
        public string name;
        public Range clip;
        public Range fov;
        public uint dataPtr;

        public Camera(string name, Range clip, Range fov, uint dataPtr)
        {
            this.name = name;
            this.clip = clip;
            this.fov = fov;
            this.dataPtr = dataPtr;
        }
    }
}
