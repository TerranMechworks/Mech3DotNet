using System.Collections.Generic;
using Mech3DotNet.Reader;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public static class Readers
    {
        private static Dictionary<string, ReaderData> Read(string inputPath, bool isPM, ReaderDeserializer deserializer, out byte[] manifest)
        {
            var readers = new Dictionary<string, ReaderData>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.read_reader, (string name, byte[] data) =>
            {
                var json = Interop.GetString(data);
                var reader = ReaderData.Deserialize(json, deserializer);
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
        public static Dictionary<string, ReaderData> ReadMW(string inputPath, ReaderDeserializer deserializer)
        {
            return Read(inputPath, false, deserializer, out _);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the expansion.
        ///
        /// This is a lossy operation, the manifest is discarded. This means
        /// the original order is lost, as well as the archive metadata/comment
        /// for each entry.
        /// </summary>
        public static Dictionary<string, ReaderData> ReadPM(string inputPath, ReaderDeserializer deserializer)
        {
            return Read(inputPath, true, deserializer, out _);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the base game.
        /// </summary>
        public static Archive<ReaderData> ReadArchiveMW(string inputPath, ReaderDeserializer deserializer)
        {
            var items = Read(inputPath, false, deserializer, out byte[] manifest);
            return new Archive<ReaderData>(items, manifest);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the base game.
        /// </summary>
        public static Archive<ReaderData> ReadArchiveMW(string inputPath)
        {
            return ReadArchiveMW(inputPath, new ReaderDeserializer());
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the expansion.
        /// </summary>
        public static Archive<ReaderData> ReadArchivePM(string inputPath, ReaderDeserializer deserializer)
        {
            var items = Read(inputPath, true, deserializer, out byte[] manifest);
            return new Archive<ReaderData>(items, manifest);
        }

        /// <summary>
        /// Read a reader archive (reader*.zbd) from the expansion.
        /// </summary>
        public static Archive<ReaderData> ReadArchivePM(string inputPath)
        {
            return ReadArchivePM(inputPath, new ReaderDeserializer());
        }

        private static void Write(string outputPath, bool isPM, Archive<ReaderData> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.write_reader, (string name) =>
            {
                var item = archive.items[name];
                var json = item.Serialize();
                return Interop.GetBytes(json);
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
