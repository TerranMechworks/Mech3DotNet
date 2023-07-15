using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataPm : IWritable
    {
        public static GameZDataPm Read(string inputPath)
        {
            return ReadData(inputPath, GameType.PM, Interop.ReadGameZ, Converter);
        }

        public void Write(string outputPath)
        {
            WriteData(outputPath, GameType.PM, Interop.WriteGameZ, this, Converter);
        }
    }
}
