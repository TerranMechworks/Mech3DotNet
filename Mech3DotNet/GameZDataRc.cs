using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Types.Gamez
{
    public partial class GameZDataRc : IWritable
    {
        public static GameZDataRc Read(string inputPath)
        {
            return ReadData(inputPath, GameType.RC, Interop.ReadGameZ, Converter);
        }

        public void Write(string outputPath)
        {
            WriteData(outputPath, GameType.RC, Interop.WriteGameZ, this, Converter);
        }
    }
}
