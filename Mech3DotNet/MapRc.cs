using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Types.Zmap
{
    /// <summary>Zmap data.</summary>
    public partial class MapRc : IWritable
    {
        /// <summary>Read zmap data.</summary>
        public static MapRc Read(string inputPath)
        {
            return ReadData(inputPath, GameType.RC, Interop.ReadZmap, Converter);
        }

        /// <summary>Write zmap data.</summary>
        public void Write(string outputPath)
        {
            WriteData(outputPath, GameType.RC, Interop.WriteZmap, this, Converter);
        }
    }
}
