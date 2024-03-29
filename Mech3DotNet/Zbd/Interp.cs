using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Interp;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Unsafe.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>Interpreter data.</summary>
    public class Interp : IWritable
    {
        public List<Script> scripts;

        public Interp(List<Script> scripts)
        {
            this.scripts = scripts ?? throw new System.ArgumentNullException(nameof(scripts));
        }

        /// <summary>Read interpreter data, and index by lowercase script name.</summary>
        public static Dictionary<string, Script> ReadAsDict(string path)
        {
            var scripts = ReadData(path, Helpers.IGNORED, Interop.ReadInterp, ScriptsConverter);
            var dict = new Dictionary<string, Script>(scripts.Count);
            foreach (var script in scripts)
                dict.Add(script.name.ToLowerInvariant(), script);
            return dict;
        }

        /// <summary>Read a <c>interp.zbd</c> file from the specified path.</summary>
        public static Interp Read(string path)
        {
            var scripts = ReadData(path, Helpers.IGNORED, Interop.ReadInterp, ScriptsConverter);
            return new Interp(scripts);
        }

        /// <summary>Write a <c>interp.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            WriteData(path, Helpers.IGNORED, Interop.WriteInterp, scripts, ScriptsConverter);
        }

        private static readonly TypeConverter<List<Script>> ScriptsConverter = new TypeConverter<List<Script>>(DeserializeScripts, SerializeScripts);

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
