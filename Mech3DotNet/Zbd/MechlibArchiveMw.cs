using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Gamez.Materials;
using Mech3DotNet.Types.Gamez.Mechlib;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    public class MechlibArchiveMw : MechlibArchive<ModelMw>, IWritable
    {
        public MechlibArchiveMw(
            Dictionary<string, ModelMw> items,
            List<ArchiveEntry> entries,
            List<Material> materials) : base(items, entries, materials) { }

        public static MechlibArchiveMw Read(string path)
        {
            List<Material>? capture = null;
            var items = new Dictionary<string, ModelMw>();
            var manifest_data = Helpers.ReadArchive(path, GameType.MW, Helpers.MANIFEST, Interop.ReadMechlib, (string name, byte[] data) =>
            {
                switch (name)
                {
                    case "format":
                        return;
                    case "version":
                        return;
                    case "materials":
                        capture = Interop.Deserialize(data, MaterialsConverter);
                        return;
                    default:
                        var model = Interop.Deserialize(data, ModelMw.Converter);
                        items.Add(name, model);
                        return;
                }
            });
            if (capture == null)
                throw new System.InvalidOperationException("materials is null after reading");
            var materials = capture;
            var manifest = DeserializeManifest(manifest_data);
            return new MechlibArchiveMw(items, manifest, materials);
        }

        public void Write(string path)
        {
            var manifest_data = SerializeManifest();
            Helpers.WriteArchive(path, GameType.MW, manifest_data, Interop.WriteMechlib, (string name) =>
            {
                switch (name)
                {
                    case "format":
                        return FORMAT;
                    case "version":
                        return VERSION_MW;
                    case "materials":
                        return Interop.Serialize(materials, MaterialsConverter);
                    default:
                        var item = items[name];
                        return Interop.Serialize(item, ModelMw.Converter);
                }
            });
        }
    }
}
