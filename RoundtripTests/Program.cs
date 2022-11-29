using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static RoundtripTests.RecursiveFileGlob;

namespace RoundtripTests
{
    static class Program
    {

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("usage: RoundtripTests <basePath>");
                return;
            }

            var consoleTracer = new ConsoleTraceListener(true); // stderr
            consoleTracer.Name = "Roundtrip";
            Trace.Listeners.Add(consoleTracer);

            var basePath = args[0];

            var tester = new Tester(basePath);
            Console.WriteLine("{0}", tester.gameType);

            tester.Sounds();
            tester.Interp();
            tester.Messages();
            tester.Readers();
            tester.Textures();
            tester.Mechlib();
            tester.Motions();
            tester.GameZ();
            tester.Anims();
            tester.SoundWav();
            tester.SoundsWav();

            tester.PrintResults();

            var matches = RecursiveGlob(new Regex(@"/zbd/reader\.zbd"), basePath);
            foreach (var inputPath in matches)
            {
                Console.WriteLine(inputPath);
                var archive = Mech3DotNet.Readers.ReadArchiveMW(inputPath);
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

            Console.WriteLine("All tests complete, press any key to exit...");
            Console.ReadKey();

            Trace.Flush();
            Trace.Listeners.Remove(consoleTracer);
            consoleTracer.Close();
            Trace.Close();
        }
    }
}
