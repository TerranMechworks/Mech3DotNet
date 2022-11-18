namespace Mech3DotNet.Json.Messages
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Messages.Converters.MessagesConverter))]
    public class Messages
    {
        public uint languageId;
        public System.Collections.Generic.List<Mech3DotNet.Json.Messages.MessageEntry> entries;

        public Messages(uint languageId, System.Collections.Generic.List<Mech3DotNet.Json.Messages.MessageEntry> entries)
        {
            this.languageId = languageId;
            this.entries = entries;
        }
    }
}
