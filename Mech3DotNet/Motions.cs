using System.Collections.Generic;
using Mech3DotNet.Json.Motion;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Motions<TQuaternion, TVec3>
    {
        private static Dictionary<string, Motion<TQuaternion, TVec3>> Read(string inputPath, GameType gameType, out byte[] manifest)
        {
            var motions = new Dictionary<string, Motion<TQuaternion, TVec3>>();
            manifest = Helpers.ReadArchiveRaw(inputPath, gameType, "manifest.json", Interop.ReadMotion, (string name, byte[] data) =>
            {
                var motion = Interop.Deserialize<Motion<TQuaternion, TVec3>>(data);
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                motions.Add(name.ToLowerInvariant(), motion);
            });
            return motions;
        }

        public static Dictionary<string, Motion<TQuaternion, TVec3>> ReadMW(string inputPath)
        {
            return Read(inputPath, GameType.MW, out _);
        }

        public static Dictionary<string, Motion<TQuaternion, TVec3>> ReadPM(string inputPath)
        {
            return Read(inputPath, GameType.PM, out _);
        }

        public static Archive<Motion<TQuaternion, TVec3>> ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, GameType.MW, out byte[] manifest);
            return new Archive<Motion<TQuaternion, TVec3>>(items, manifest);
        }

        public static Archive<Motion<TQuaternion, TVec3>> ReadArchivePM(string inputPath)
        {
            var items = Read(inputPath, GameType.PM, out byte[] manifest);
            return new Archive<Motion<TQuaternion, TVec3>>(items, manifest);
        }

        private static void Write(string outputPath, GameType gameType, Archive<Motion<TQuaternion, TVec3>> archive)
        {
            var manifest = archive.SerializeManifest();
            Helpers.WriteArchiveRaw(outputPath, gameType, manifest, Interop.WriteMotion, (string name) =>
            {
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                var item = archive.items[name.ToLowerInvariant()];
                return Interop.Serialize(item);
            });
        }

        public static void WriteArchiveMW(string outputPath, Archive<Motion<TQuaternion, TVec3>> archive)
        {
            Write(outputPath, GameType.MW, archive);
        }

        public static void WriteArchivePM(string outputPath, Archive<Motion<TQuaternion, TVec3>> archive)
        {
            Write(outputPath, GameType.PM, archive);
        }
    }
}
