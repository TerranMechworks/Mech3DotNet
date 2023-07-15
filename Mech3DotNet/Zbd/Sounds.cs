using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// Sound data.
    ///
    /// See <see cref="Read"/> for reading a <c>sounds*.zbd</c> file.
    /// </summary>
    public class Sounds : Archive<byte[]>, IWritable
    {
        public GameType gameType;

        public Sounds(
            Dictionary<string, byte[]> items,
            List<ArchiveEntry> entries,
            GameType gameType) : base(items, entries)
        {
            this.gameType = gameType;
        }

        private static Dictionary<string, byte[]> ReadRaw(string path, GameType gameType, out byte[] manifest_data)
        {
            var sounds = new Dictionary<string, byte[]>();
            manifest_data = Helpers.ReadArchive(path, gameType, Helpers.MANIFEST, Interop.ReadSounds, (string name, byte[] data) =>
            {
                // there are duplicate sounds in the archive, however in all
                // instances these seem to contain duplicate data. so they can
                // be overwritten.
                sounds[name] = data;
            });
            return sounds;
        }

        /// <summary>
        /// Read a <c>sounds*.zbd</c> file from the specified path, discarding the manifest.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, byte[]> ReadAsDict(string path, GameType gameType)
        {
            return ReadRaw(path, gameType, out _);
        }

        /// <summary>Read a <c>sounds*.zbd</c> file from the specified path.</summary>
        public static Sounds Read(string path, GameType gameType)
        {
            var items = ReadRaw(path, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new Sounds(items, manifest, gameType);
        }

        /// <summary>Write a <c>sounds*.zbd</c> file to the specified path</summary>
        public void Write(string path)
        {
            var manifest = SerializeManifest();
            Helpers.WriteArchive(path, gameType, manifest, Interop.WriteSounds, (string name) =>
            {
                return items[name];
            });
        }
    }
}
