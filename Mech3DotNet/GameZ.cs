using Mech3DotNet.Json.Gamez;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class GameZ
    {
        public static GameZMwData ReadMW(string inputPath)
        {
            return ReadData<GameZMwData>(inputPath, GameType.MW, Interop.ReadGameZ);
        }

        public static void WriteMW(string outputPath, GameZMwData gamez)
        {
            WriteData(outputPath, GameType.MW, Interop.WriteGameZ, gamez);
        }

        public static GameZPmData ReadPM(string inputPath)
        {
            return ReadData<GameZPmData>(inputPath, GameType.PM, Interop.ReadGameZ);
        }

        public static void WritePM(string outputPath, GameZPmData gamez)
        {
            WriteData(outputPath, GameType.PM, Interop.WriteGameZ, gamez);
        }

        public static GameZRcData ReadRC(string inputPath)
        {
            return ReadData<GameZRcData>(inputPath, GameType.RC, Interop.ReadGameZ);
        }

        public static void WriteRC(string outputPath, GameZRcData gamez)
        {
            WriteData(outputPath, GameType.RC, Interop.WriteGameZ, gamez);
        }

        public static GameZCsData ReadCS(string inputPath)
        {
            return ReadData<GameZCsData>(inputPath, GameType.CS, Interop.ReadGameZ);
        }

        public static void WriteCS(string outputPath, GameZCsData gamez)
        {
            WriteData(outputPath, GameType.CS, Interop.WriteGameZ, gamez);
        }
    }
}
