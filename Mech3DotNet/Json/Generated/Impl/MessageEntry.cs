namespace Mech3DotNet.Json.Messages
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Messages.Converters.MessageEntryConverter))]
    public class MessageEntry
    {
        public string key;
        public uint id;
        public string value;

        public MessageEntry(string key, uint id, string value)
        {
            this.key = key;
            this.id = id;
            this.value = value;
        }
    }
}
