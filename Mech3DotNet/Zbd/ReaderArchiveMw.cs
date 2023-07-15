using System.Collections.Generic;
using Mech3DotNet.Reader;
using Mech3DotNet.Reader.Structs;
using Mech3DotNet.Types.Archive;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// A MW reader archive with parsing convenience functions.
    /// </summary>
    public class ReaderArchiveMw : ReaderArchive, IWritable
    {
        public ReaderArchiveMw(
            Dictionary<string, ReaderValue> items,
            List<ArchiveEntry> entries) : base(items, entries) { }

        /// <summary>Read reader data, retaining entry information.</summary>
        public static ReaderArchiveMw Read(string path)
        {
            var items = ReadRaw(path, GameType.MW, out var manifest_data);
            var manifest = DeserializeManifest(manifest_data);
            return new ReaderArchiveMw(items, manifest);
        }

        /// <summary>Write reader data.</summary>
        public void Write(string path)
        {
            WriteRaw(path, GameType.MW);
        }

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
}
