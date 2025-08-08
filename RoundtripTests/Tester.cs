using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mech3DotNet;
using Mech3DotNet.FileUtils;
using Mech3DotNet.Types.Common;
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
                Mech3DotNet.Zbd.Sounds.Read);
        }

        public void Interp()
        {
            Roundtrip(
                "Interpreter",
                @"interp\.zbd$",
                Mech3DotNet.Zbd.Interp.Read);
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
                    var messages = Mech3DotNet.Zbd.Messages.Read(inputPath, gameType);
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
                Mech3DotNet.Zbd.Textures.Read);
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
                Mech3DotNet.Zbd.ReaderArchiveGeneric.Read);
        }

        public void ReadersJson()
        {
            var readerRegex = gameType switch
            {
                GameType.MW => @"reader.*\.zbd$",
                GameType.PM => @"reader.*\.zbd$",
                GameType.RC => @"zrdr.*\.zbd$",
                GameType.CS => @"zrdr.*\.zbd$",
                _ => throw new ArgumentOutOfRangeException(),
            };
            var matches = RecursiveGlob(new Regex(readerRegex), basePath);
            var name = "ReaderJson";
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                try
                {
                    var json = Mech3DotNet.Zbd.ReaderArchive.ReadAsJson(inputPath, gameType);
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

        public void Motions()
        {
            switch (gameType)
            {
                case GameType.MW:
                    Roundtrip(
                        "Motions (MW)",
                        @"motion\.zbd$",
                        Mech3DotNet.Zbd.Motions<Quaternion, Vec3>.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Motions (PM)",
                        @"motion\.zbd$",
                        Mech3DotNet.Zbd.Motions<Quaternion, Vec3>.Read);
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
                        Mech3DotNet.Zbd.MechlibArchiveMw.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Mechlib (PM)",
                        @"mechlib\.zbd$",
                        Mech3DotNet.Zbd.MechlibArchivePm.Read);
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
                        Mech3DotNet.Zbd.GameZ.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "GameZ (PM)",
                        @"gamez\.zbd$",
                        Mech3DotNet.Zbd.GameZ.Read);
                    break;
                case GameType.RC:
                    Roundtrip(
                        "GameZ (RC)",
                        @"m([1234578]|1[0123])/gamez\.zbd$",
                        Mech3DotNet.Zbd.GameZ.Read);
                    break;
                case GameType.CS:
                    Console.WriteLine("Skipping GameZ for CS");
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
                        Mech3DotNet.Zbd.Anim.Read);
                    break;
                case GameType.PM:
                    Roundtrip(
                        "Animations (PM)",
                        @"anim\.zbd$",
                        Mech3DotNet.Zbd.Anim.Read);
                    break;
                case GameType.RC:
                    Roundtrip(
                        "Animations (RC)",
                        @"anim\.zbd$",
                        Mech3DotNet.Zbd.Anim.Read);
                    break;
                case GameType.CS:
                    Console.WriteLine("Skipping Anim for CS");
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
                        Mech3DotNet.Zbd.Zmap.Read);
                    break;
                case GameType.CS:
                    Console.WriteLine("No zmap for CS");
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

        public void ReaderParsing()
        {
            switch (gameType)
            {
                case GameType.MW:
                    ReaderParsingMw();
                    break;
                case GameType.PM:
                    Console.WriteLine("No specific reader for PM");
                    break;
                case GameType.RC:
                    Console.WriteLine("No specific reader for RC");
                    break;
                case GameType.CS:
                    Console.WriteLine("No specific reader for CS");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ReaderParsingMw()
        {
            // TODO: make it less jank to find the root reader
            var matches = RecursiveGlob(new Regex(@"/zbd/reader\.zbd$"), basePath);
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                var archive = Mech3DotNet.Zbd.ReaderArchiveMw.Read(inputPath);
                var fonts = archive.GetFonts();
                foreach (var font in fonts)
                {
                    Console.WriteLine("{0} {1}", font.Key, font.Value);
                }
                var satmaps = archive.GetSatMaps();
                foreach (var satmap in satmaps)
                {
                    Console.WriteLine("{0}", satmap);
                }
                var soundSets = archive.GetSoundSets();
                foreach (var soundSet in soundSets)
                {
                    Console.WriteLine("{0}", soundSet.Key);
                    foreach (var soundDef in soundSet.Value.definitions)
                    {
                        Console.WriteLine("{0}", soundDef);
                    }
                }
                var soundGroups = archive.GetSoundGroups();
                foreach (var soundGroup in soundGroups)
                {
                    Console.WriteLine("{0}", soundGroup);
                }
                var chassisNames = new string[] {
                    "annihilator",
                    "avatar",
                    "blackhawk",
                    "bushwacker",
                    "cauldron",
                    "champion",
                    "daishi",
                    "elemental",
                    "firefly",
                    "madcat",
                    "orion",
                    "owens",
                    "puma",
                    "shadowcat",
                    "strider",
                    "sunder",
                    "supernova",
                    "thor",
                    "vulture",
                };
                foreach (var chassisName in chassisNames)
                {
                    Console.WriteLine("{0}", chassisName);
                    var chassisDef = archive.GetMechDfn(chassisName);
                    Console.WriteLine("{0}", chassisDef);
                }
            }
        }
    }
}
