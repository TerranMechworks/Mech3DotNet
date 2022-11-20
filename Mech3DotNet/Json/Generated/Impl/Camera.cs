namespace Mech3DotNet.Json.Nodes.Mw
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Nodes.Mw.Converters.CameraConverter))]
    public class Camera
    {
        public string name;
        public Mech3DotNet.Json.Types.Range clip;
        public Mech3DotNet.Json.Types.Range fov;
        public uint dataPtr;

        public Camera(string name, Mech3DotNet.Json.Types.Range clip, Mech3DotNet.Json.Types.Range fov, uint dataPtr)
        {
            this.name = name;
            this.clip = clip;
            this.fov = fov;
            this.dataPtr = dataPtr;
        }
    }
}
