using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet.Types.Gamez
{
    public partial class GameZDataMw : IWritable
    {
        public static GameZDataMw Read(string inputPath)
        {
            return ReadData(inputPath, GameType.MW, Interop.ReadGameZ, Converter);
        }

        public void Write(string outputPath)
        {
            WriteData(outputPath, GameType.MW, Interop.WriteGameZ, this, Converter);
        }
    }
}
