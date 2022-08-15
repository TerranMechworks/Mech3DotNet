using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using Mech3DotNet.Json;
using Mech3DotNet.Reader;
using Mech3DotNet.Reader.Structs;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet
{
    public class ReaderArchive : Archive<ReaderData>
    {
        public ReaderArchive(
            Dictionary<string, ReaderData> items,
            byte[] manifest) : base(items, manifest) { }

        public ReaderArchive(
            Dictionary<string, ReaderData> items,
            List<ArchiveEntry> entries) : base(items, entries) { }

        public Dictionary<string, Font> GetFonts()
        {
            var reader = items["fonts.zrd"];
            return reader / Only() / "WINDOWS_FONTS" / Only() / Dict(new ToFont());
        }
    }

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

        public static Dictionary<string, ReaderData> ReadMW(string inputPath)
        {
            return Read(inputPath, false, out _);
        }

        public static Dictionary<string, ReaderData> ReadPM(string inputPath)
        {
            return Read(inputPath, true, out _);
        }

        public static ReaderArchive ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest);
            return new ReaderArchive(items, manifest);
        }

        public static ReaderArchive ReadArchivePM(string inputPath)
        {
            var items = Read(inputPath, true, out byte[] manifest);
            return new ReaderArchive(items, manifest);
        }

        private static void Write(string outputPath, bool isPM, ReaderArchive archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.WriteReader, (string name) =>
            {
                var item = archive.items[name];
                return item.Serialize();
            });
        }

        public static void WriteArchiveMW(string outputPath, ReaderArchive archive)
        {
            Write(outputPath, false, archive);
        }

        public static void WriteArchivePM(string outputPath, ReaderArchive archive)
        {
            Write(outputPath, true, archive);
        }
    }
}
