using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Motion;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// MW or PM motion data.
    ///
    /// See <see cref="Read"/> for reading a MW or PM <c>motion.zbd</c> file.
    /// </summary>
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

        private static Dictionary<string, Motion<TQuaternion, TVec3>> ReadRaw(string path, GameType gameType, out byte[] manifest_data)
        {
            ValidateGameType(gameType);
            var motions = new Dictionary<string, Motion<TQuaternion, TVec3>>();
            manifest_data = Helpers.ReadArchive(path, gameType, Helpers.MANIFEST, Interop.ReadMotion, (string name, byte[] data) =>
            {
                var motion = Interop.Deserialize(data, Motion<TQuaternion, TVec3>.Converter);
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                motions.Add(name.ToLowerInvariant(), motion);
            });
            return motions;
        }

        /// <summary>
        /// Read a MW or PM <c>motion.zbd</c> file from the specified path, discarding the manifest.
        ///
        /// Without the manifest, the data cannot be written again.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the game type is not <see cref="GameType.MW"/> or <see cref="GameType.PM"/>.
        /// </exception>
        public static Dictionary<string, Motion<TQuaternion, TVec3>> ReadAsDict(string path, GameType gameType)
        {
            return ReadRaw(path, gameType, out _);
        }

        /// <summary>
        /// Read a MW or PM <c>motion.zbd</c> file from the specified path.
        /// </summary>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the game type is not <see cref="GameType.MW"/> or <see cref="GameType.PM"/>.
        /// </exception>
        public static Motions<TQuaternion, TVec3> Read(string path, GameType gameType)
        {
            var items = ReadRaw(path, gameType, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new Motions<TQuaternion, TVec3>(items, manifest, gameType);
        }

        /// <summary>Write a MW or PM <c>motion.zbd</c> file to the specified path.</summary>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the game type is not <see cref="GameType.MW"/> or <see cref="GameType.PM"/>.
        /// </exception>
        public void Write(string path)
        {
            ValidateGameType(gameType);
            var manifest = SerializeManifest();
            Helpers.WriteArchive(path, gameType, manifest, Interop.WriteMotion, (string name) =>
            {
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                var item = items[name.ToLowerInvariant()];
                return Interop.Serialize(item, Motion<TQuaternion, TVec3>.Converter);
            });
        }
    }
}
