using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>Sound data.</summary>
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
                // there are duplicate sounds in the archive
                sounds[name] = data;
            });
            return sounds;
        }

        /// <summary>
        /// Read sound data, discarding the manifest.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, byte[]> ReadAsDict(string path, GameType gameType)
        {
            return ReadRaw(path, gameType, out _);
        }

        /// <summary>Read sound data, retaining the manifest.</summary>
        public static Sounds Read(string path, GameType gameType)
        {
            var items = ReadRaw(path, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new Sounds(items, manifest, gameType);
        }

        /// <summary>Write sound data.</summary>
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
