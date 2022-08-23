using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mech3DotNet.FileUtils;
using Mech3DotNet.Json;
using static Mech3DotNet.FileUtils.FileCompare;
using static RoundtripTests.RecursiveFileGlob;

namespace RoundtripTests
{
    public class Tester
    {
        private delegate T ReadArchive<T>(string inputPath);
        private delegate void WriteArchive<T>(string outputPath, T archive);

        private List<string> failures;
        private string basePath;

        public Tester(string basePath)
        {
            this.failures = new List<string>();
            this.basePath = basePath;
        }

        static string nonNull(string? value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return value;
        }

        private void Roundtrip<T>(string name, string glob, ReadArchive<T> readFn, WriteArchive<T> writeFn)
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
            Roundtrip(
                "Sounds",
                @"sounds[LH]\.zbd$",
                Mech3DotNet.Sounds.ReadArchiveMW,
                Mech3DotNet.Sounds.WriteArchiveMW);
        }

        public void Interp()
        {
            Roundtrip(
                "Interpreter",
                @"interp\.zbd$",
                Mech3DotNet.Interp.Read,
                Mech3DotNet.Interp.Write);
        }

        public void Motions()
        {
            Roundtrip(
                "Motions",
                @"motion\.zbd$",
                Mech3DotNet.Motions<Quaternion, Vec3>.ReadArchiveMW,
                Mech3DotNet.Motions<Quaternion, Vec3>.WriteArchiveMW);
        }

        public void Textures()
        {
            Roundtrip(
                "Textures",
                @"r?texture[12]?\.zbd$",
                Mech3DotNet.Textures.ReadPackage,
                Mech3DotNet.Textures.WritePackage);
        }

        public void Mechlib()
        {
            Roundtrip(
                "Mechlib",
                @"mechlib\.zbd$",
                Mech3DotNet.Mechlib.ReadArchiveMW,
                Mech3DotNet.Mechlib.WriteArchiveMW);
        }

        public void GameZ()
        {
            Roundtrip(
                "GameZ",
                @"gamez\.zbd$",
                Mech3DotNet.GameZ.ReadMW,
                Mech3DotNet.GameZ.WriteMW);
        }

        public void Readers()
        {
            Roundtrip(
                "Readers",
                @"reader.*\.zbd$",
                Mech3DotNet.Readers.ReadArchiveMW,
                Mech3DotNet.Readers.WriteArchiveMW);
        }

        public void Anims()
        {
            Roundtrip(
                "Animations",
                @"anim\.zbd$",
                Mech3DotNet.Anim.ReadPackageMW,
                Mech3DotNet.Anim.WritePackageMW);
        }

        public void Mech3Msg()
        {
            var matches = RecursiveGlob(new Regex(@"Mech3Msg\.dll$"), basePath);
            var name = "Mech3Msg";
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                try
                {
                    Mech3DotNet.Mech3Msg.Read(inputPath);
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
            var matches = RecursiveGlob(new Regex(@"sounds[LH]\.zbd$"), basePath);
            var name = "ReadSoundsAsWav";
            var failed = false;
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                try
                {
                    Mech3DotNet.Sounds.ReadSoundsAsWav(inputPath, false, (string name, int channels, int frequency, float[] samples) =>
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
