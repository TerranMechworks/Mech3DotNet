namespace Mech3DotNet.Json.Archive
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Archive.Converters.ArchiveEntryConverter))]
    public class ArchiveEntry
    {
        public string name;
        public string? rename = null;
        public byte[] garbage;

        public ArchiveEntry(string name, string? rename, byte[] garbage)
        {
            this.name = name;
            this.rename = rename;
            this.garbage = garbage;
        }
    }
}
