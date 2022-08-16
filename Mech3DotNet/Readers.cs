using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Mech3DotNet.Reader;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Readers
    {
        private static Dictionary<string, ReaderData> Read(string inputPath, bool isPM, out byte[] manifest)
        {
            var readers = new Dictionary<string, ReaderData>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.ReadReader, (string name, byte[] data) =>
            {
                var reader = ReaderData.Deserialize(data);
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
        public static Dictionary<string, ReaderData> ReadMW(string inputPath)
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
        public static Dictionary<string, ReaderData> ReadPM(string inputPath)
        {
            return Read(inputPath, true, out _);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the base game.
        /// </summary>
        public static Archive<ReaderData> ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest);
            return new Archive<ReaderData>(items, manifest);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the expansion.
        /// </summary>
        public static Archive<ReaderData> ReadArchivePM(string inputPath)
        {
            var items = Read(inputPath, true, out byte[] manifest);
            return new Archive<ReaderData>(items, manifest);
        }

        private static void Write(string outputPath, bool isPM, Archive<ReaderData> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.WriteReader, (string name) =>
            {
                var item = archive.items[name];
                return item.Serialize();
            });
        }

        /// <summary>
        /// Write a reader archive (reader*.zbd) from the base game.
        /// </summary>
        public static void WriteArchiveMW(string outputPath, Archive<ReaderData> archive)
        {
            Write(outputPath, false, archive);
        }

        /// <summary>
        /// Write a reader archive (reader*.zbd) from the expansion.
        /// </summary>
        public static void WriteArchivePM(string outputPath, Archive<ReaderData> archive)
        {
            Write(outputPath, true, archive);
        }
    }
}
