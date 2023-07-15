using System.Collections.Generic;
using Mech3DotNet.Reader;
using Mech3DotNet.Types.Archive;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// A generic reader archive with no parsing convenience functions.
    ///
    /// See <see cref="Read"/> for reading a reader ZBD file.
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

        /// <summary>Read a reader ZBD file from the specified path.</summary>
        public static ReaderArchiveGeneric Read(string path, GameType gameType)
        {
            var items = ReadRaw(path, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new ReaderArchiveGeneric(items, manifest, gameType);
        }

        /// <summary>Write a reader ZBD file to the specified path.</summary>
        public void Write(string path)
        {
            WriteRaw(path, gameType);
        }
    }
}
