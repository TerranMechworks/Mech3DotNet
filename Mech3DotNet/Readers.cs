using Mech3DotNet.Unsafe;
using System.Collections.Generic;

namespace Mech3DotNet
{
    public static class Readers
    {
        private static Dictionary<string, Reader> Read(string inputPath, bool isPM, out byte[] manifest)
        {
            var readers = new Dictionary<string, Reader>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.read_reader, (string name, byte[] data) =>
            {
                var json = Interop.GetString(data);
                var reader = Reader.Parse(json);
                readers.Add(name, reader);
            });
            return readers;
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the base game.
        ///
        /// This is a lossy operation, the manifest is discarded. This means
        /// the original order is lost, as well as the archive metadata/comment
        /// for each entry.
        /// </summary>
        public static Dictionary<string, Reader> ReadMW(string inputPath)
        {
            return Read(inputPath, false, out _);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the expansion.
        ///
        /// This is a lossy operation, the manifest is discarded. This means
        /// the original order is lost, as well as the archive metadata/comment
        /// for each entry.
        /// </summary>
        public static Dictionary<string, Reader> ReadPM(string inputPath)
        {
            return Read(inputPath, true, out _);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the base game.
        /// </summary>
        public static Archive<Reader> ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest);
            return new Archive<Reader>(items, manifest);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the expansion.
        /// </summary>
        public static Archive<Reader> ReadArchivePM(string inputPath)
        {
            var items = Read(inputPath, true, out byte[] manifest);
            return new Archive<Reader>(items, manifest);
        }

        private static void Write(string outputPath, bool isPM, Archive<Reader> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.write_reader, (string name) =>
            {
                var item = archive.items[name];
                var json = item.GetJson();
                return Interop.GetBytes(json);
            });
        }

        /// <summary>
        /// Write a reader archive (reader*.zbd) from the base game.
        /// </summary>
        public static void WriteArchiveMW(string outputPath, Archive<Reader> archive)
        {
            Write(outputPath, false, archive);
        }

        /// <summary>
        /// Write a reader archive (reader*.zbd) from the expansion.
        /// </summary>
        public static void WriteArchivePM(string outputPath, Archive<Reader> archive)
        {
            Write(outputPath, true, archive);
        }
    }
}