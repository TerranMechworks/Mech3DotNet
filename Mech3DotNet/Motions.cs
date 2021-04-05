using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using System.Collections.Generic;

namespace Mech3DotNet
{
    public static class Motions<V3, V4>
    {
        private static Dictionary<string, Motion<V3, V4>> Read(string inputPath, bool isPM, out byte[] manifest)
        {
            var motions = new Dictionary<string, Motion<V3, V4>>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.read_motion, (string name, byte[] data) =>
            {
                var json = Interop.GetString(data);
                var motion = Settings.DeserializeObject<Motion<V3, V4>>(json);
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                motions.Add(name.ToLowerInvariant(), motion);
            });
            return motions;
        }

        /// <summary>
        /// Read a motion archive (motion.zbd) from the base game.
        ///
        /// This is a lossy operation, the manifest is discarded. This means
        /// the original order is lost, as well as the archive metadata/comment
        /// for each entry.
        /// </summary>
        public static Dictionary<string, Motion<V3, V4>> ReadMW(string inputPath)
        {
            return Read(inputPath, false, out _);
        }

        /// <summary>
        /// Read a motion archive (motion.zbd) from the expansion.
        ///
        /// This is a lossy operation, the manifest is discarded. This means
        /// the original order is lost, as well as the archive metadata/comment
        /// for each entry.
        /// </summary>
        public static Dictionary<string, Motion<V3, V4>> ReadPM(string inputPath)
        {
            return Read(inputPath, true, out _);
        }

        /// <summary>
        /// Read a motion archive (motion.zbd) from the base game.
        /// </summary>
        public static Archive<Motion<V3, V4>> ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest);
            return new Archive<Motion<V3, V4>>(items, manifest);
        }

        /// <summary>
        /// Read a motion archive (motion.zbd) from the expansion.
        /// </summary>
        public static Archive<Motion<V3, V4>> ReadArchivePM(string inputPath)
        {
            var items = Read(inputPath, true, out byte[] manifest);
            return new Archive<Motion<V3, V4>>(items, manifest);
        }

        private static void Write(string outputPath, bool isPM, Archive<Motion<V3, V4>> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.write_motion, (string name) =>
            {
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                var item = archive.items[name.ToLowerInvariant()];
                var json = Settings.SerializeObject(item);
                return Interop.GetBytes(json);
            });
        }

        /// <summary>
        /// Write a motion archive (motion.zbd) from the base game.
        /// </summary>
        public static void WriteArchiveMW(string outputPath, Archive<Motion<V3, V4>> archive)
        {
            Write(outputPath, false, archive);
        }

        /// <summary>
        /// Write a motion archive (motion.zbd) from the expansion.
        /// </summary>
        public static void WriteArchivePM(string outputPath, Archive<Motion<V3, V4>> archive)
        {
            Write(outputPath, true, archive);
        }
    }
}