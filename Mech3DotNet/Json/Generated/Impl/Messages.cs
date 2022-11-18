namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.MessagesConverter))]
    public class Messages
    {
        public uint languageId;
        public System.Collections.Generic.List<MessageEntry> entries;

        public Messages(uint languageId, System.Collections.Generic.List<MessageEntry> entries)
        {
            this.languageId = languageId;
            this.entries = entries;
        }
    }
}
