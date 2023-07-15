using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataCs : IWritable
    {
        public static GameZDataCs Read(string inputPath)
        {
            return ReadData(inputPath, GameType.CS, Interop.ReadGameZ, Converter);
        }

        public void Write(string outputPath)
        {
            WriteData(outputPath, GameType.CS, Interop.WriteGameZ, this, Converter);
        }
    }
}
