using Mech3DotNet.Types.Gamez;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Helpers;

namespace Mech3DotNet
{
    public static class GameZ
    {
        public static GameZMwData ReadMW(string inputPath)
        {
            return ReadData(inputPath, GameType.MW, Interop.ReadGameZ, GameZMwData.Converter);
        }

        public static void WriteMW(string outputPath, GameZMwData gamez)
        {
            WriteData(outputPath, GameType.MW, Interop.WriteGameZ, gamez, GameZMwData.Converter);
        }

        public static GameZPmData ReadPM(string inputPath)
        {
            return ReadData(inputPath, GameType.PM, Interop.ReadGameZ, GameZPmData.Converter);
        }

        public static void WritePM(string outputPath, GameZPmData gamez)
        {
            WriteData(outputPath, GameType.PM, Interop.WriteGameZ, gamez, GameZPmData.Converter);
        }

        public static GameZRcData ReadRC(string inputPath)
        {
            return ReadData(inputPath, GameType.RC, Interop.ReadGameZ, GameZRcData.Converter);
        }

        public static void WriteRC(string outputPath, GameZRcData gamez)
        {
            WriteData(outputPath, GameType.RC, Interop.WriteGameZ, gamez, GameZRcData.Converter);
        }

        public static GameZCsData ReadCS(string inputPath)
        {
            return ReadData(inputPath, GameType.CS, Interop.ReadGameZ, GameZCsData.Converter);
        }

        public static void WriteCS(string outputPath, GameZCsData gamez)
        {
            WriteData(outputPath, GameType.CS, Interop.WriteGameZ, gamez, GameZCsData.Converter);
        }
    }
}
