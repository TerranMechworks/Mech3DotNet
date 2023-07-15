using System.Collections.Generic;
using System.IO;
using Mech3DotNet.Reader;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// Reader archive base.
    ///
    /// Use <see>ReaderArchiveGeneric</see> or a game-specific reader archive
    /// with parsing convenience functions.
    /// </summary>
    public abstract class ReaderArchive : Archive<ReaderValue>
    {
        public ReaderArchive(
            Dictionary<string, ReaderValue> items,
            List<ArchiveEntry> entries) : base(items, entries) { }

        /// <summary>
        /// Read reader data as JSON, discarding entry information.
        ///
        /// Without entry information, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, byte[]> ReadAsJson(string path, GameType gameType)
        {
            var readers = new Dictionary<string, byte[]>();
            var manifest_data = Helpers.ReadArchive(path, gameType, Helpers.MANIFEST, Interop.ReadReaderJson, (string name, byte[] data) =>
            {
                readers.Add(name, data);
            });
            return readers;
        }

        protected static Dictionary<string, ReaderValue> ReadRaw(string path, GameType gameType, out byte[] manifest_data)
        {
            var readers = new Dictionary<string, ReaderValue>();
            manifest_data = Helpers.ReadArchive(path, gameType, Helpers.MANIFEST, Interop.ReadReaderRaw, (string name, byte[] data) =>
            {
                var stream = new MemoryStream(data);
                var reader = new BinaryReader(stream);
                var root = ReaderValue.Read(reader);
                readers.Add(name, root);
            });
            return readers;
        }

        /// <summary>
        /// Read reader data, discarding entry information.
        ///
        /// Without entry information, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, ReaderValue> ReadAsDict(string path, GameType gameType)
        {
            return ReadRaw(path, gameType, out _);
        }

        protected void WriteRaw(string path, GameType gameType)
        {
            var manifest_data = SerializeManifest();
            Helpers.WriteArchive(path, gameType, manifest_data, Interop.WriteReaderRaw, (string name) =>
            {
                var root = items[name];
                var stream = new MemoryStream();
                var writer = new BinaryWriter(stream);
                root.Write(writer);
                return stream.ToArray();
            });
        }
    }
}
