using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Motion;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>Motion data.</summary>
    public class Motions<TQuaternion, TVec3> : Archive<Motion<TQuaternion, TVec3>>, IWritable
        where TQuaternion : notnull
        where TVec3 : notnull
    {
        public GameType gameType;

        private static GameType ValidateGameType(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.MW:
                case GameType.PM:
                    return gameType;
                case GameType.RC:
                case GameType.CS:
                    throw new System.ArgumentException("unsupported game type");
                default:
                    throw new System.ArgumentOutOfRangeException(nameof(GameType));
            }
        }

        public Motions(
            Dictionary<string, Motion<TQuaternion, TVec3>> items,
            List<ArchiveEntry> entries,
            GameType gameType) : base(items, entries)
        {
            this.gameType = ValidateGameType(gameType);
        }

        private static Dictionary<string, Motion<TQuaternion, TVec3>> ReadRaw(string inputPath, GameType gameType, out byte[] manifest_data)
        {
            ValidateGameType(gameType);
            var motions = new Dictionary<string, Motion<TQuaternion, TVec3>>();
            manifest_data = Helpers.ReadArchive(inputPath, gameType, Helpers.MANIFEST, Interop.ReadMotion, (string name, byte[] data) =>
            {
                var motion = Interop.Deserialize(data, Motion<TQuaternion, TVec3>.Converter);
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                motions.Add(name.ToLowerInvariant(), motion);
            });
            return motions;
        }

        /// <summary>
        /// Read motion data, discarding the manifest.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        public static Dictionary<string, Motion<TQuaternion, TVec3>> ReadAsDict(string inputPath, GameType gameType)
        {
            return ReadRaw(inputPath, gameType, out _);
        }

        /// <summary>Read motion data, retaining the manifest.</summary>
        public static Motions<TQuaternion, TVec3> Read(string inputPath, GameType gameType)
        {
            var items = ReadRaw(inputPath, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new Motions<TQuaternion, TVec3>(items, manifest, gameType);
        }

        /// <summary>Write motion data.</summary>
        public void Write(string outputPath)
        {
            ValidateGameType(gameType);
            var manifest = SerializeManifest();
            Helpers.WriteArchive(outputPath, gameType, manifest, Interop.WriteMotion, (string name) =>
            {
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                var item = items[name.ToLowerInvariant()];
                return Interop.Serialize(item, Motion<TQuaternion, TVec3>.Converter);
            });
        }
    }
}
