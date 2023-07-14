using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mech3DotNet;
using Mech3DotNet.FileUtils;
using Mech3DotNet.Types.Types;
using static Mech3DotNet.FileUtils.FileCompare;
using static RoundtripTests.RecursiveFileGlob;

namespace RoundtripTests
{
    public class Tester
    {
        private delegate T ReadWithGameType<T>(string inputPath, GameType gameType);
        private delegate T ReadWithoutGameType<T>(string inputPath);

        private List<string> failures;
        private string basePath;
        public GameType gameType;

        private static GameType nameToGame(string basePath)
        {
            if (basePath.EndsWith("-pm") || basePath.EndsWith("-pm/") || basePath.EndsWith("-pm\\"))
                return GameType.PM;
            if (basePath.EndsWith("-recoil") || basePath.EndsWith("-recoil/") || basePath.EndsWith("-recoil\\"))
                return GameType.RC;
            if (basePath.EndsWith("-cs") || basePath.EndsWith("-cs/") || basePath.EndsWith("-cs\\"))
                return GameType.CS;
            return GameType.MW;
        }

        public Tester(string basePath)
        {
            this.failures = new List<string>();
            this.basePath = basePath;
            this.gameType = nameToGame(basePath);
        }

        static string nonNull(string? value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return value;
        }

        private void Roundtrip<T>(string name, string glob, ReadWithGameType<T> readFn)
        where T : IWritable
        {
            ReadWithoutGameType<T> wrappedReadFn = (string inputPath) => readFn(inputPath, gameType);
            Roundtrip<T>(name, glob, wrappedReadFn);
        }

        private void Roundtrip<T>(string name, string glob, ReadWithoutGameType<T> readFn)
        where T : IWritable
        {
            var matches = RecursiveGlob(new Regex(glob), basePath);
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                var archive = readFn(inputPath);
                using (var outputPath = new TemporaryFile())
                {
                    archive.Write(nonNull(outputPath));
                    var cmp = CompareFiles(inputPath, outputPath);
                    if (cmp != null)
                    {
                        failures.Add($"[{name}] {inputPath}: {cmp}");
                        failed = true;
                    }
                }
            }
            if (failed)
                Console.WriteLine("--- {0} FAIL ---", name);
            else
                Console.WriteLine("--- {0} OK ---", name);
        }

        public void Sounds()
        {
            var soundRegex = gameType switch
            {
                GameType.MW => @"sounds[LH]\.zbd$",
                GameType.PM => @"sounds[LH]\.zbd$",
                GameType.RC => @"sounds[lmh]\.zbd$",
                GameType.CS => @"sounds[lh]\.zbd$",
                _ => throw new ArgumentOutOfRangeException(),
            };
            Roundtrip(
                "Sounds",
                soundRegex,
                Mech3DotNet.Sounds.Read);
        }

        public void Interp()
        {
            Roundtrip(
                "Interpreter",
                @"interp\.zbd$",
                Mech3DotNet.Interp.Read);
        }

        public void Messages()
        {
            var messageRegex = gameType switch
            {
                GameType.MW => @"Mech3Msg\.dll$",
                GameType.PM => @"Mech3Msg\.dll$",
                GameType.RC => @"messages\.dll$",
                GameType.CS => @"strings\.dll$",
                _ => throw new ArgumentOutOfRangeException(),
            };
            var matches = RecursiveGlob(new Regex(messageRegex), basePath);
            var name = "Messages";
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                try
                {
                    var messages = Mech3DotNet.Types.Messages.Messages.Read(inputPath, gameType);
                    if (messages.languageId < 1000)
                        throw new Exception($"Lang ID {messages.languageId}");
                    if (messages.entries.Count < 50)
                        throw new Exception($"Count {messages.entries.Count}");
                }
                catch (Exception e)
                {
                    failures.Add($"[{name}] {inputPath}: {e}");
                    failed = true;
                }
            }
            if (failed)
                Console.WriteLine("--- {0} FAIL ---", name);
            else
                Console.WriteLine("--- {0} OK ---", name);
        }

        public void Textures()
        {
            Roundtrip(
                "Textures",
                @".*?tex.*?\.zbd$",
                Mech3DotNet.Textures.Read);
        }

        public void Readers()
        {
            var readerRegex = gameType switch
            {
                GameType.MW => @"reader.*\.zbd$",
                GameType.PM => @"reader.*\.zbd$",
                GameType.RC => @"zrdr.*\.zbd$",
                GameType.CS => @"zrdr.*\.zbd$",
                _ => throw new ArgumentOutOfRangeException(),
            };
            Roundtrip(
                "Readers",
                readerRegex,
                Mech3DotNet.ReaderArchiveGeneric.Read);
        }

        public void Motions()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Roundtrip(
                        "Motions (MW)",
                        @"motion\.zbd$",
                        Mech3DotNet.Motions<Quaternion, Vec3>.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Motions (PM)",
                        @"motion\.zbd$",
                        Mech3DotNet.Motions<Quaternion, Vec3>.Read);
                    break;
                case GameType.RC:
                    Console.WriteLine("No motions for RC");
                    break;
                case GameType.CS:
                    Console.WriteLine("No motions for CS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Mechlib()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Roundtrip(
                        "Mechlib (MW)",
                        @"mechlib\.zbd$",
                        Mech3DotNet.MechlibArchiveMw.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Mechlib (PM)",
                        @"mechlib\.zbd$",
                        Mech3DotNet.MechlibArchivePm.Read);
                    break;
                case GameType.RC:
                    Console.WriteLine("No mechlib for RC");
                    break;
                case GameType.CS:
                    Console.WriteLine("No mechlib for CS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void GameZ()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Roundtrip(
                        "GameZ (MW)",
                        @"gamez\.zbd$",
                        Mech3DotNet.Types.Gamez.GameZDataMw.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "GameZ (PM)",
                        @"gamez\.zbd$",
                        Mech3DotNet.Types.Gamez.GameZDataPm.Read);
                    break;
                case GameType.RC:
                    Roundtrip(
                        "GameZ (RC)",
                        @"m([1234578]|1[0123])/gamez\.zbd$",
                        Mech3DotNet.Types.Gamez.GameZDataRc.Read);
                    break;
                case GameType.CS:
                    Roundtrip(
                        "GameZ (CS)",
                        @"gamez\.zbd$",
                        Mech3DotNet.Types.Gamez.GameZDataCs.Read);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Anims()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Roundtrip(
                        "Animations (MW)",
                        @"anim\.zbd$",
                        Mech3DotNet.AnimMw.Read);
                    break;
                case GameType.PM:
                    Console.WriteLine("Skipping animations for PM");
                    break;
                case GameType.RC:
                    Console.WriteLine("Skipping animations for RC");
                    break;
                case GameType.CS:
                    Console.WriteLine("Skipping animations for CS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SoundWav()
        {
            var matches = RecursiveGlob(new Regex(@".*\.wav$"), basePath);
            var name = "ReadSoundAsWav";
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                var expectedName = System.IO.Path.GetFileName(inputPath);
                try
                {
                    Mech3DotNet.UnitySounds.ReadSoundAsWav(inputPath, (string actualName, int channels, int frequency, float[] samples) =>
                    {
                        if (expectedName != actualName)
                            throw new ArgumentException($"'{expectedName}' != '{actualName}", "name");
                    });
                }
                catch (Exception e)
                {
                    failures.Add($"[{name}] {inputPath}: {e}");
                    failed = true;
                }
            }
            if (failed)
                Console.WriteLine("--- {0} FAIL ---", name);
            else
                Console.WriteLine("--- {0} OK ---", name);
        }

        public void SoundsWav()
        {
            switch (gameType)
            {
                case GameType.MW:
                case GameType.PM:
                    SoundsWav(@"sounds[LH]\.zbd$");
                    break;
                case GameType.RC:
                    SoundsWav(@"sounds[lmh]\.zbd$");
                    break;
                case GameType.CS:
                    // SoundsWav(@"sounds[lh]\.zbd$");
                    Console.WriteLine("Skipping sounds as wav for CS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SoundsWav(string soundRegex)
        {
            var matches = RecursiveGlob(new Regex(soundRegex), basePath);
            var name = "ReadSoundsAsWav";
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                try
                {
                    Mech3DotNet.UnitySounds.ReadSoundsAsWav(inputPath, gameType, (string name, int channels, int frequency, float[] samples) =>
                    { });
                }
                catch (Exception e)
                {
                    failures.Add($"[{name}] {inputPath}: {e}");
                    failed = true;
                }
            }
            if (failed)
                Console.WriteLine("--- {0} FAIL ---", name);
            else
                Console.WriteLine("--- {0} OK ---", name);
        }

        public void Zmap()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Console.WriteLine("No zmap for MW");
                    break;
                case GameType.PM:
                    Console.WriteLine("No zmap for PM");
                    break;
                case GameType.RC:
                    Roundtrip(
                        "Zmap",
                        @"m([123456789]|1[012])\.zmap$",
                        Mech3DotNet.Types.Zmap.MapRc.Read);
                    break;
                case GameType.CS:
                    Console.WriteLine("No zmap for CS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Planes()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Console.WriteLine("No planes for MW");
                    break;
                case GameType.PM:
                    Console.WriteLine("No planes for PM");
                    break;
                case GameType.RC:
                    Console.WriteLine("No planes for RC");
                    break;
                case GameType.CS:
                    Roundtrip(
                        "Planes (CS)",
                        @"planes\.zbd$",
                        Mech3DotNet.Types.Gamez.GameZDataCs.Read);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PrintResults()
        {
            if (failures.Count > 0)
            {
                Console.WriteLine("--- FAIL ---");
                foreach (var failure in failures)
                    Console.WriteLine(failure);
            }
            else
                Console.WriteLine("--- ALL OK ---");
        }
    }
}
