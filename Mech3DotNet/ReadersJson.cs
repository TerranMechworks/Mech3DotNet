using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Mech3DotNet.Reader;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class ReadersJson
    {
        private static Dictionary<string, byte[]> Read(string inputPath, bool isPM, out byte[] manifest)
        {
            var readers = new Dictionary<string, byte[]>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, "manifest.json", Interop.ReadReader, (string name, byte[] data) =>
            {
                readers.Add(name, data);
            });
            return readers;
        }

        public static Dictionary<string, byte[]> ReadMW(string inputPath)
        {
            return Read(inputPath, false, out _);
        }

        public static Dictionary<string, byte[]> ReadPM(string inputPath)
        {
            return Read(inputPath, true, out _);
        }
    }
}
