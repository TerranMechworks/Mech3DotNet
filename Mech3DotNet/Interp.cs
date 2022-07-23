﻿using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using System.Collections.Generic;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class Interp
    {
        public static List<InterpreterScript> Read(string inputPath)
        {
            // interp.zbd has no difference between MW and PM, it's just for consistency
            return ReadData<List<InterpreterScript>>(inputPath, false, Interop.read_interp);
        }

        public static Dictionary<string, InterpreterScript> ReadAsDict(string inputPath)
        {
            var scripts = Read(inputPath);
            var dict = new Dictionary<string, InterpreterScript>(scripts.Count);
            foreach (var script in scripts)
                dict.Add(script.name.ToLowerInvariant(), script);
            return dict;
        }

        public static void Write(string outputPath, List<InterpreterScript> scripts)
        {
            // interp.zbd has no difference between MW and PM, it's just for consistency
            WriteData(outputPath, false, Interop.write_interp, scripts);
        }
    }
}