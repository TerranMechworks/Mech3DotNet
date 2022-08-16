using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class GameZ
    {
        public static GameZData ReadMW(string inputPath)
        {
            return ReadData<GameZData>(inputPath, false, Interop.ReadGameZ);
        }

        public static void WriteMW(string outputPath, GameZData gamez)
        {
            WriteData(outputPath, false, Interop.WriteGameZ, gamez);
        }
    }
}
