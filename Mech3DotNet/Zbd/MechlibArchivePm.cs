using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Gamez.Materials;
using Mech3DotNet.Types.Gamez.Mechlib;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// PM MechLib data.
    ///
    /// See <see cref="Read"/> for reading a PM <c>mechlib.zbd</c> file.
    /// </summary>
    public class MechlibArchivePm : MechlibArchive<ModelPm>, IWritable
    {
        public MechlibArchivePm(
            Dictionary<string, ModelPm> items,
            List<ArchiveEntry> entries,
            List<Material> materials) : base(items, entries, materials) { }

        /// <summary>Read a PM <c>mechlib.zbd</c> file from the specified path.</summary>
        public static MechlibArchivePm Read(string path)
        {
            List<Material>? capture = null;
            var items = new Dictionary<string, ModelPm>();
            var manifest_data = Helpers.ReadArchive(path, GameType.PM, Helpers.MANIFEST, Interop.ReadMechlib, (string name, byte[] data) =>
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
                        var model = Interop.Deserialize(data, ModelPm.Converter);
                        items.Add(name, model);
                        return;
                }
            });
            if (capture == null)
                throw new System.InvalidOperationException("materials is null after reading");
            var materials = capture;
            var manifest = MechlibArchivePm.DeserializeManifest(manifest_data);
            return new MechlibArchivePm(items, manifest, materials);
        }

        /// <summary>Write a PM <c>mechlib.zbd</c> file to the specified path.</summary>
        public void Write(string path)
        {
            var manifest = SerializeManifest();
            Helpers.WriteArchive(path, GameType.PM, manifest, Interop.WriteMechlib, (string name) =>
            {
                switch (name)
                {
                    case "format":
                        return FORMAT;
                    case "version":
                        return VERSION_PM;
                    case "materials":
                        return Interop.Serialize(materials, MaterialsConverter);
                    default:
                        var item = items[name];
                        return Interop.Serialize(item, ModelPm.Converter);
                }
            });
        }
    }
}
