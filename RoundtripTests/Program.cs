using System;
using System.Diagnostics;

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
            tester.Zmap();
            tester.Planes();

            tester.PrintResults();

            tester.ReaderParsing();

            Console.WriteLine("All tests complete, press any key to exit...");
            Console.ReadKey();

            Trace.Flush();
            Trace.Listeners.Remove(consoleTracer);
            consoleTracer.Close();
            Trace.Close();
        }
    }
}
