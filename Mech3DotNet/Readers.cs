using System.Collections.Generic;
using System.IO;
using Mech3DotNet.Json;
using Mech3DotNet.Reader;
using Mech3DotNet.Reader.Structs;
using Mech3DotNet.Unsafe;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet
{
    public class ReaderArchive : Archive<ReaderValue>
    {
        public ReaderArchive(
            Dictionary<string, ReaderValue> items,
            byte[] manifest) : base(items, manifest) { }

        public ReaderArchive(
            Dictionary<string, ReaderValue> items,
            List<ArchiveEntry> entries) : base(items, entries) { }

        public Dictionary<string, Font> GetFonts()
        {
            var reader = items["fonts.zrd"];
            return reader / Only() / "WINDOWS_FONTS" / Only() / Dict(new ToFont());
        }

        public List<SatMap> GetSatMaps()
        {
            var reader = items["maps.zrd"];
            return reader / Only() / "maps" / Only() / List(new ToSatMap());
        }

        public Dictionary<string, SoundSet> GetSoundSets()
        {
            var reader = items["sounds.zrd"];
            return reader / Only() / "SETS" / Only() / Dict(new ToSoundSet());
        }
    }

    public static class Readers
    {
        private static Dictionary<string, ReaderValue> Read(string inputPath, bool isPM, out byte[] manifest)
        {
            var readers = new Dictionary<string, ReaderValue>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.ReadReaderRaw, (string name, byte[] data) =>
            {
                var stream = new MemoryStream(data);
                var reader = new BinaryReader(stream);
                var root = ReaderValue.Read(reader);
                readers.Add(name, root);
            });
            return readers;
        }

        public static Dictionary<string, ReaderValue> ReadMW(string inputPath)
        {
            return Read(inputPath, false, out _);
        }

        public static Dictionary<string, ReaderValue> ReadPM(string inputPath)
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
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.WriteReaderRaw, (string name) =>
            {
                var root = archive.items[name];
                var stream = new MemoryStream();
                var writer = new BinaryWriter(stream);
                root.Write(writer);
                return stream.ToArray();
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
