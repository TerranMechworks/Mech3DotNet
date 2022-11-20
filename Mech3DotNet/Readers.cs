using System.Collections.Generic;
using System.IO;
using Mech3DotNet.Json.Archive;
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
    }

    public class ReaderArchiveMw : ReaderArchive
    {
        public ReaderArchiveMw(
            Dictionary<string, ReaderValue> items,
            byte[] manifest) : base(items, manifest) { }

        public ReaderArchiveMw(
            Dictionary<string, ReaderValue> items,
            List<ArchiveEntry> entries) : base(items, entries) { }

        public Dictionary<string, Font> GetFonts()
        {
            var reader = items["fonts.zrd"];
            return Root(reader) / Only("WINDOWS_FONTS") / Dict(new ToFont());
        }

        public List<SatMap> GetSatMaps()
        {
            var reader = items["maps.zrd"];
            return Root(reader) / Only("maps") / List(new ToSatMap());
        }

        public Dictionary<string, SoundSet> GetSoundSets()
        {
            var reader = items["sounds.zrd"];
            return Root(reader) / Only("SETS") / Dict(new ToSoundSet());
        }

        public List<SoundGroup> GetSoundGroups()
        {
            var reader = items["sounds.zrd"];
            return Root(reader) / Only("SOUND_GROUPS") / List(new ToSoundGroup());
        }

        public IONet GetIONet(string worldName)
        {
            var name = $"reg_ionet_{worldName}.zrd";
            var reader = items[name];
            return Root(reader) / new ToIONet();
        }

        public MechDfn GetMechDfn(string chassisName)
        {
            chassisName = chassisName.ToLowerInvariant();
            var zrdName = $"dfn_{chassisName}.zrd";
            var reader = items[zrdName];
            return Root(reader) / new ToMechDfn(chassisName);
        }
    }

    public static class Readers
    {
        private static Dictionary<string, ReaderValue> Read(string inputPath, GameType gameType, out byte[] manifest)
        {
            var readers = new Dictionary<string, ReaderValue>();
            manifest = Helpers.ReadArchiveRaw(inputPath, gameType, "manifest.json", Interop.ReadReaderRaw, (string name, byte[] data) =>
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
            return Read(inputPath, GameType.MW, out _);
        }

        public static Dictionary<string, ReaderValue> Read(string inputPath, GameType gameType)
        {
            return Read(inputPath, gameType, out _);
        }
        public static ReaderArchiveMw ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, GameType.MW, out byte[] manifest);
            return new ReaderArchiveMw(items, manifest);
        }

        public static ReaderArchive ReadArchive(string inputPath, GameType gameType)
        {
            var items = Read(inputPath, gameType, out byte[] manifest);
            return new ReaderArchive(items, manifest);
        }

        private static void Write(string outputPath, GameType gameType, ReaderArchive archive)
        {
            var manifest = archive.SerializeManifest();
            Helpers.WriteArchiveRaw(outputPath, gameType, manifest, Interop.WriteReaderRaw, (string name) =>
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
            Write(outputPath, GameType.MW, archive);
        }

        public static void WriteArchive(string outputPath, GameType gameType, ReaderArchive archive)
        {
            Write(outputPath, gameType, archive);
        }
    }
}
