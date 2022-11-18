using Mech3DotNet.Json.Gamez;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class GameZ
    {
        public static GameZMwData ReadMW(string inputPath)
        {
            return ReadData<GameZMwData>(inputPath, false, Interop.ReadGameZ);
        }

        public static void WriteMW(string outputPath, GameZMwData gamez)
        {
            WriteData(outputPath, false, Interop.WriteGameZ, gamez);
        }
    }
}
