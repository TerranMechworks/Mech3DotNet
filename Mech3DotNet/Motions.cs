using System.Collections.Generic;
using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Motions<TQuaternion, TVec3>
    {
        private static Dictionary<string, Motion<TQuaternion, TVec3>> Read(string inputPath, bool isPM, out byte[] manifest)
        {
            var motions = new Dictionary<string, Motion<TQuaternion, TVec3>>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.ReadMotion, (string name, byte[] data) =>
            {
                var motion = Interop.Deserialize<Motion<TQuaternion, TVec3>>(data);
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                motions.Add(name.ToLowerInvariant(), motion);
            });
            return motions;
        }

        public static Dictionary<string, Motion<TQuaternion, TVec3>> ReadMW(string inputPath)
        {
            return Read(inputPath, false, out _);
        }

        public static Dictionary<string, Motion<TQuaternion, TVec3>> ReadPM(string inputPath)
        {
            return Read(inputPath, true, out _);
        }

        public static Archive<Motion<TQuaternion, TVec3>> ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest);
            return new Archive<Motion<TQuaternion, TVec3>>(items, manifest);
        }

        public static Archive<Motion<TQuaternion, TVec3>> ReadArchivePM(string inputPath)
        {
            var items = Read(inputPath, true, out byte[] manifest);
            return new Archive<Motion<TQuaternion, TVec3>>(items, manifest);
        }

        private static void Write(string outputPath, bool isPM, Archive<Motion<TQuaternion, TVec3>> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.WriteMotion, (string name) =>
            {
                // there is at least one file, "shadowcat_Fallb" that isn't lowercased
                var item = archive.items[name.ToLowerInvariant()];
                return Interop.Serialize(item);
            });
        }

        public static void WriteArchiveMW(string outputPath, Archive<Motion<TQuaternion, TVec3>> archive)
        {
            Write(outputPath, false, archive);
        }

        public static void WriteArchivePM(string outputPath, Archive<Motion<TQuaternion, TVec3>> archive)
        {
            Write(outputPath, true, archive);
        }
    }
}
