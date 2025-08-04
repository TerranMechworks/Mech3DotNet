using System.Collections.Generic;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Gamez;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// MW MechLib data.
    ///
    /// See <see cref="Read"/> for reading a MW <c>mechlib.zbd</c> file.
    /// </summary>
    public class MechlibArchiveMw : MechlibArchive, IWritable
    {
        public MechlibArchiveMw(
            Dictionary<string, MechlibModel> items,
            List<ArchiveEntry> entries,
            List<MechlibMaterial> materials) : base(items, entries, materials) { }

        /// <summary>Read a MW <c>mechlib.zbd</c> file from the specified path.</summary>
        public static MechlibArchiveMw Read(string path)
        {
            List<MechlibMaterial>? capture = null;
            var items = new Dictionary<string, MechlibModel>();
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
                        var model = Interop.Deserialize(data, MechlibModel.Converter);
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

        /// <summary>Write a MW <c>mechlib.zbd</c> file to the specified path.</summary>
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
                        return Interop.Serialize(item, MechlibModel.Converter);
                }
            });
        }
    }
}
