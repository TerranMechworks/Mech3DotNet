using System.Collections.Generic;
using Mech3DotNet.Reader;
using Mech3DotNet.Types.Archive;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// A generic reader archive with no parsing convenience functions.
    /// </summary>
    public class ReaderArchiveGeneric : ReaderArchive, IWritable
    {
        public GameType gameType;

        public ReaderArchiveGeneric(
            Dictionary<string, ReaderValue> items,
            List<ArchiveEntry> entries,
            GameType gameType) : base(items, entries)
        {
            this.gameType = gameType;
        }

        /// <summary>Read reader data, retaining entry information.</summary>
        public static ReaderArchiveGeneric Read(string inputPath, GameType gameType)
        {
            var items = ReadRaw(inputPath, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new ReaderArchiveGeneric(items, manifest, gameType);
        }

        /// <summary>Write reader data.</summary>
        public void Write(string outputPath)
        {
            WriteRaw(outputPath, gameType);
        }
    }
}
