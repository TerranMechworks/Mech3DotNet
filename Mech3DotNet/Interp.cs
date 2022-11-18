using System.Collections.Generic;
using Mech3DotNet.Json.Interp;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class Interp
    {
        public static List<Script> Read(string inputPath)
        {
            // interp.zbd has no difference between MW and PM, it's just for consistency
            return ReadData<List<Script>>(inputPath, false, Interop.ReadInterp);
        }

        public static Dictionary<string, Script> ReadAsDict(string inputPath)
        {
            var scripts = Read(inputPath);
            var dict = new Dictionary<string, Script>(scripts.Count);
            foreach (var script in scripts)
                dict.Add(script.name.ToLowerInvariant(), script);
            return dict;
        }

        public static void Write(string outputPath, List<Script> scripts)
        {
            // interp.zbd has no difference between MW and PM, it's just for consistency
            WriteData(outputPath, false, Interop.WriteInterp, scripts);
        }
    }
}
