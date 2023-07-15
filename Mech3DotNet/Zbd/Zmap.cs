using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    /// <summary>Zmap data.</summary>
    public partial class Zmap : IWritable
    {
        /// <summary>Read zmap data.</summary>
        public static Zmap Read(string inputPath)
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
