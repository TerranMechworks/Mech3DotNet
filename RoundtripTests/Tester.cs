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
        private delegate void WriteWithGameType<T>(string outputPath, GameType gameType, T archive);

        private delegate T ReadWithoutGameType<T>(string inputPath);
        private delegate void WriteWithoutGameType<T>(string outputPath, T archive);

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

        private void Roundtrip<T>(string name, string glob, ReadWithGameType<T> readFn, WriteWithGameType<T> writeFn)
        {
            ReadWithoutGameType<T> wrappedReadFn = (string inputPath) => readFn(inputPath, gameType);
            WriteWithoutGameType<T> wrappedWriteFn = (string outputPath, T archive) => writeFn(outputPath, gameType, archive);
            Roundtrip<T>(name, glob, wrappedReadFn, wrappedWriteFn);
        }

        private void Roundtrip<T>(string name, string glob, ReadWithoutGameType<T> readFn, WriteWithoutGameType<T> writeFn)
        {
            var matches = RecursiveGlob(new Regex(glob), basePath);
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                var archive = readFn(inputPath);
                using (var outputPath = new TemporaryFile())
                {
                    writeFn(nonNull(outputPath), archive);
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
                Mech3DotNet.Sounds.ReadArchive,
                Mech3DotNet.Sounds.WriteArchive);
        }

        public void Interp()
        {
            Roundtrip(
                "Interpreter",
                @"interp\.zbd$",
                Mech3DotNet.Interp.Read,
                Mech3DotNet.Interp.Write);
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
                    var messages = Mech3DotNet.Mech3Msg.Read(inputPath, gameType);
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
                Mech3DotNet.Textures.ReadPackage,
                Mech3DotNet.Textures.WritePackage);
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
                Mech3DotNet.Readers.ReadArchive,
                Mech3DotNet.Readers.WriteArchive);
        }

        public void Motions()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Roundtrip(
                        "Motions (MW)",
                        @"motion\.zbd$",
                        Mech3DotNet.Motions<Quaternion, Vec3>.ReadArchiveMW,
                        Mech3DotNet.Motions<Quaternion, Vec3>.WriteArchiveMW);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Motions (PM)",
                        @"motion\.zbd$",
                        Mech3DotNet.Motions<Quaternion, Vec3>.ReadArchivePM,
                        Mech3DotNet.Motions<Quaternion, Vec3>.WriteArchivePM);
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
                        Mech3DotNet.MechlibMw.ReadArchive,
                        Mech3DotNet.MechlibMw.WriteArchive);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Mechlib (PM)",
                        @"mechlib\.zbd$",
                        Mech3DotNet.MechlibPm.ReadArchive,
                        Mech3DotNet.MechlibPm.WriteArchive);
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
                        Mech3DotNet.GameZ.ReadMW,
                        Mech3DotNet.GameZ.WriteMW);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "GameZ (PM)",
                        @"gamez\.zbd$",
                        Mech3DotNet.GameZ.ReadPM,
                        Mech3DotNet.GameZ.WritePM);
                    break;
                case GameType.RC:
                    Roundtrip(
                        "GameZ (RC)",
                        @"gamez\.zbd$",
                        Mech3DotNet.GameZ.ReadRC,
                        Mech3DotNet.GameZ.WriteRC);
                    break;
                case GameType.CS:
                    Roundtrip(
                        "GameZ (CS)",
                        @"gamez\.zbd$",
                        Mech3DotNet.GameZ.ReadCS,
                        Mech3DotNet.GameZ.WriteCS);
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
                        Mech3DotNet.Anim.ReadPackageMW,
                        Mech3DotNet.Anim.WritePackageMW);
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
                    Mech3DotNet.Sounds.ReadSoundAsWav(inputPath, (string actualName, int channels, int frequency, float[] samples) =>
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
                    Mech3DotNet.Sounds.ReadSoundsAsWav(inputPath, gameType, (string name, int channels, int frequency, float[] samples) =>
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
