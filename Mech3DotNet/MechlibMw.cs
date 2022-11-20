using System;
using System.Collections.Generic;
using Mech3DotNet.Json.Archive;
using Mech3DotNet.Json.Gamez.Materials;
using Mech3DotNet.Json.Gamez.Mechlib;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class MechlibArchiveMw : Archive<ModelMw>
    {
        public List<Material> materials;

        public MechlibArchiveMw(
            Dictionary<string, ModelMw> items,
            List<Material> materials,
            byte[] manifest) : base(items, manifest)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }

        public MechlibArchiveMw(
            Dictionary<string, ModelMw> items,
            List<Material> materials,
            List<ArchiveEntry> entries) : base(items, entries)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }
    }

    public static class MechlibMw
    {
        private static readonly byte[] VERSION_MW = BitConverter.GetBytes(27u);
        private static readonly byte[] VERSION_PM = BitConverter.GetBytes(41u);
        private static readonly byte[] FORMAT = BitConverter.GetBytes(1u);

        private static Dictionary<string, ModelMw> Read(string inputPath, out byte[] manifest, out List<Material> materials)
        {
            List<Material>? capture = null;
            var models = new Dictionary<string, ModelMw>();
            manifest = Helpers.ReadArchiveRaw(inputPath, GameType.MW, "manifest.json", Interop.ReadMechlib, (string name, byte[] data) =>
            {
                switch (name)
                {
                    case "format":
                        return;
                    case "version":
                        return;
                    case "materials":
                        capture = Interop.Deserialize<List<Material>>(data);
                        return;
                    default:
                        var model = Interop.Deserialize<ModelMw>(data);
                        models.Add(name, model);
                        return;
                }
            });
            if (capture == null)
                throw new InvalidOperationException("materials is null after reading");
            materials = capture;
            return models;
        }

        public static MechlibArchiveMw ReadArchive(string inputPath)
        {
            var items = Read(inputPath, out byte[] manifest, out List<Material> materials);
            return new MechlibArchiveMw(items, materials, manifest);
        }

        private static void Write(string outputPath, MechlibArchiveMw archive)
        {
            var manifest = archive.SerializeManifest();
            Helpers.WriteArchiveRaw(outputPath, GameType.MW, manifest, Interop.WriteMechlib, (string name) =>
            {
                switch (name)
                {
                    case "format":
                        return FORMAT;
                    case "version":
                        return VERSION_MW;
                    case "materials":
                        return Interop.Serialize(archive.materials);
                    default:
                        var item = archive.items[name];
                        return Interop.Serialize(item);
                }
            });
        }

        public static void WriteArchive(string outputPath, MechlibArchiveMw archive)
        {
            Write(outputPath, archive);
        }
    }
}
