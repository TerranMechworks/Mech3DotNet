namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.TranslateDataConverter))]
    public class TranslateData
    {
        public Mech3DotNet.Json.Types.Vec3 value;
        public byte[] unk;

        public TranslateData(Mech3DotNet.Json.Types.Vec3 value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
