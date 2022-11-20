using System.Collections.Generic;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class ReadersJson
    {
        private static Dictionary<string, byte[]> Read(string inputPath, GameType gameType, out byte[] manifest)
        {
            var readers = new Dictionary<string, byte[]>();
            manifest = Helpers.ReadArchiveRaw(inputPath, gameType, "manifest.json", Interop.ReadReader, (string name, byte[] data) =>
            {
                readers.Add(name, data);
            });
            return readers;
        }

        [System.Obsolete("Use Read with a specific GameType instead.")]
        public static Dictionary<string, byte[]> ReadMW(string inputPath)
        {
            return Read(inputPath, GameType.MW, out _);
        }

        public static Dictionary<string, byte[]> Read(string inputPath, GameType gameType)
        {
            return Read(inputPath, gameType, out _);
        }
    }
}
