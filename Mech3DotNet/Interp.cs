using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Interp;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class Interp
    {
        private static readonly TypeConverter<List<Script>> ScriptsConverter = new TypeConverter<List<Script>>(DeserializeScripts, SerializeScripts);

        public static List<Script> Read(string inputPath)
        {
            return ReadData(inputPath, Helpers.IGNORED, Interop.ReadInterp, ScriptsConverter);
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
            WriteData(outputPath, Helpers.IGNORED, Interop.WriteInterp, scripts, ScriptsConverter);
        }

        private static void SerializeScripts(List<Script> v, Serializer s)
        {
            s.SerializeVec(s.Serialize(Script.Converter))(v);
        }

        private static List<Script> DeserializeScripts(Deserializer d)
        {
            return d.DeserializeVec(d.Deserialize(Script.Converter))();
        }
    }
}
