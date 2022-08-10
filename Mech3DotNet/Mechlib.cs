using System;
using System.Collections.Generic;
using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class MechlibArchive : Archive<Model>
    {
        public List<Material> materials;

        public MechlibArchive(
            Dictionary<string, Model> items,
            List<Material> materials,
            byte[] manifest) : base(items, manifest)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }

        public MechlibArchive(
            Dictionary<string, Model> items,
            List<Material> materials,
            List<ArchiveEntry> entries) : base(items, entries)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }
    }

    public static class Mechlib
    {
        private static readonly byte[] VERSION_MW = BitConverter.GetBytes(27u);
        private static readonly byte[] VERSION_PM = BitConverter.GetBytes(41u);
        private static readonly byte[] FORMAT = BitConverter.GetBytes(1u);

        private static Dictionary<string, Model> Read(string inputPath, bool isPM, out byte[] manifest, out List<Material> materials)
        {
            List<Material>? capture = null;
            var models = new Dictionary<string, Model>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.read_mechlib, (string name, byte[] data) =>
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
                        var model = Interop.Deserialize<Model>(data);
                        models.Add(name, model);
                        return;
                }
            });
            if (capture == null)
                throw new InvalidOperationException("materials is null after reading");
            materials = capture;
            return models;
        }

        /// <summary>
        /// Read a mechlib archive (mechlib.zbd) from the base game.
        /// </summary>
        public static MechlibArchive ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest, out List<Material> materials);
            return new MechlibArchive(items, materials, manifest);
        }

        private static void Write(string outputPath, bool isPM, MechlibArchive archive)
        {
            var manifest = archive.GetManifest();
            var version = isPM ? VERSION_PM : VERSION_MW;
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.write_mechlib, (string name) =>
            {
                switch (name)
                {
                    case "format":
                        return FORMAT;
                    case "version":
                        return version;
                    case "materials":
                        return Interop.Serialize(archive.materials);
                    default:
                        var item = archive.items[name];
                        return Interop.Serialize(item);
                }
            });
        }

        /// <summary>
        /// Write a mechlib archive (mechlib.zbd) from the base game.
        /// </summary>
        public static void WriteArchiveMW(string outputPath, MechlibArchive archive)
        {
            Write(outputPath, false, archive);
        }
    }
}
