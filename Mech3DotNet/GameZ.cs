using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class GameZ
    {
        public static GameZData<V2, V3, Color> ReadMW<V2, V3, Color>(string inputPath)
        {
            return ReadData<GameZData<V2, V3, Color>>(inputPath, false, Interop.read_gamez);
        }

        public static void WriteMW<V2, V3, Color>(string outputPath, GameZData<V2, V3, Color> gamez)
        {
            WriteData(outputPath, false, Interop.write_gamez, gamez);
        }
    }
}
