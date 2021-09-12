using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mech3DotNet;
using Mech3DotNet.Json;
using static Mech3DotNet.FileCompare;
using static RoundtripTests.RecursiveFileGlob;

namespace RoundtripTests
{
    static class Program
    {
        delegate T ReadArchive<T>(string inputPath);
        delegate void WriteArchive<T>(string outputPath, T archive);

        static void Roundtrip<T>(string basePath, string name, string glob, ReadArchive<T> readFn, WriteArchive<T> writeFn)
        {
            var matches = RecursiveGlob(new Regex(glob), basePath);
            var failures = new List<string>();
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                var archive = readFn(inputPath);
                using (var outputPath = new TemporaryFile())
                {
                    writeFn(outputPath, archive);
                    var cmp = CompareFiles(inputPath, outputPath);
                    if (cmp != null)
                        failures.Add($"{inputPath}: {cmp}");
                }
            }
            if (failures.Count > 0)
            {
                Console.WriteLine("--- {0} failures ---", name);
                foreach (var failure in failures)
                    Console.WriteLine(failure);
            }
            else
                Console.WriteLine("--- {0} OK ---", name);
        }

        static void Sounds(string basePath)
        {
            Roundtrip(
                basePath,
                "Sounds",
                @"sounds[LH]\.zbd$",
                Mech3DotNet.Sounds.ReadArchiveMW,
                Mech3DotNet.Sounds.WriteArchiveMW);
        }

        static void Readers(string basePath)
        {
            Roundtrip(
                basePath,
                "Readers",
                @"reader.*\.zbd$",
                Mech3DotNet.Readers.ReadArchiveMW,
                Mech3DotNet.Readers.WriteArchiveMW);
        }

        static void Motions(string basePath)
        {
            Roundtrip(
                basePath,
                "Motions",
                @"motion\.zbd$",
                Motions<Vec3, Vec4>.ReadArchiveMW,
                Motions<Vec3, Vec4>.WriteArchiveMW);
        }

        static void Mechlib(string basePath)
        {
            Roundtrip(
                basePath,
                "Mechlib",
                @"mechlib\.zbd$",
                Mechlib<Vec2, Vec3, Color>.ReadArchiveMW,
                Mechlib<Vec2, Vec3, Color>.WriteArchiveMW);
        }

        static void Textures(string basePath)
        {
            Roundtrip(
                basePath,
                "Textures",
                @"r?texture[12]?\.zbd$",
                Mech3DotNet.Textures.ReadArchive,
                Mech3DotNet.Textures.WriteArchive);
        }

        static void Interp(string basePath)
        {
            Roundtrip(
                basePath,
                "Interpreter",
                @"interp\.zbd$",
                Mech3DotNet.Interp.Read,
                Mech3DotNet.Interp.Write);
        }

        static void GameZ(string basePath)
        {
            Roundtrip(
                basePath,
                "GameZ",
                @"gamez\.zbd$",
                Mech3DotNet.GameZ.ReadMW<Vec2, Vec3, Color>,
                Mech3DotNet.GameZ.WriteMW);
        }

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("usage: RoundtripTests <zbdPath>");
                return;
            }

            string zbdPath = args[0];
            Sounds(zbdPath);
            Motions(zbdPath);
            Mechlib(zbdPath);
            Textures(zbdPath);
            Interp(zbdPath);
            GameZ(zbdPath);
            Readers(zbdPath);

            Console.WriteLine("All tests complete, press any key to exit...");
            Console.ReadKey();
        }
    }
}
