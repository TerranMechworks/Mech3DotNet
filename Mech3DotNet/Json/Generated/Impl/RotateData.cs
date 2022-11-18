namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.RotateDataConverter))]
    public class RotateData
    {
        public Mech3DotNet.Json.Types.Quaternion value;
        public byte[] unk;

        public RotateData(Mech3DotNet.Json.Types.Quaternion value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
