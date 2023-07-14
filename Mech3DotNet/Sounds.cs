using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
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

        private static Dictionary<string, byte[]> ReadRaw(string inputPath, GameType gameType, out byte[] manifest_data)
        {
            var sounds = new Dictionary<string, byte[]>();
            manifest_data = Helpers.ReadArchive(inputPath, gameType, Helpers.MANIFEST, Interop.ReadSounds, (string name, byte[] data) =>
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
        public static Dictionary<string, byte[]> ReadAsDict(string inputPath, GameType gameType)
        {
            return ReadRaw(inputPath, gameType, out _);
        }

        /// <summary>Read sound data, retaining the manifest.</summary>
        public static Sounds Read(string inputPath, GameType gameType)
        {
            var items = ReadRaw(inputPath, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new Sounds(items, manifest, gameType);
        }

        /// <summary>Write sound data.</summary>
        public void Write(string outputPath)
        {
            var manifest = SerializeManifest();
            Helpers.WriteArchive(outputPath, gameType, manifest, Interop.WriteSounds, (string name) =>
            {
                return items[name];
            });
        }
    }
}
