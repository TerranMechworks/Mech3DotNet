using System;
using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Gamez.Materials;
using Mech3DotNet.Types.Gamez.Mechlib;
using Mech3DotNet.Unsafe;

namespace Mech3DotNet
{
    public class MechlibArchivePm : Archive<ModelPm>
    {
        public List<Material> materials;

        public MechlibArchivePm(
            Dictionary<string, ModelPm> items,
            List<Material> materials,
            byte[] manifest) : base(items, manifest)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }

        public MechlibArchivePm(
            Dictionary<string, ModelPm> items,
            List<Material> materials,
            List<ArchiveEntry> entries) : base(items, entries)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }
    }

    public static class MechlibPm
    {
        private static readonly byte[] VERSION_PM = BitConverter.GetBytes(41u);
        private static readonly byte[] FORMAT = BitConverter.GetBytes(1u);

        private static readonly TypeConverter<List<Material>> MaterialsConverter = new TypeConverter<List<Material>>(DeserializeMaterials, SerializeMaterials);

        private static void SerializeMaterials(List<Material> v, Serializer s)
        {
            s.SerializeVec(s.Serialize(Material.Converter))(v);
        }

        private static List<Material> DeserializeMaterials(Deserializer d)
        {
            return d.DeserializeVec(d.Deserialize(Material.Converter))();
        }

        private static Dictionary<string, ModelPm> Read(string inputPath, out byte[] manifest, out List<Material> materials)
        {
            List<Material>? capture = null;
            var models = new Dictionary<string, ModelPm>();
            manifest = Helpers.ReadArchiveRaw(inputPath, GameType.PM, "manifest.json", Interop.ReadMechlib, (string name, byte[] data) =>
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
                        models.Add(name, model);
                        return;
                }
            });
            if (capture == null)
                throw new InvalidOperationException("materials is null after reading");
            materials = capture;
            return models;
        }

        public static MechlibArchivePm ReadArchive(string inputPath)
        {
            var items = Read(inputPath, out byte[] manifest, out List<Material> materials);
            return new MechlibArchivePm(items, materials, manifest);
        }

        private static void Write(string outputPath, MechlibArchivePm archive)
        {
            var manifest = archive.SerializeManifest();
            Helpers.WriteArchiveRaw(outputPath, GameType.PM, manifest, Interop.WriteMechlib, (string name) =>
            {
                switch (name)
                {
                    case "format":
                        return FORMAT;
                    case "version":
                        return VERSION_PM;
                    case "materials":
                        return Interop.Serialize(archive.materials, MaterialsConverter);
                    default:
                        var item = archive.items[name];
                        return Interop.Serialize(item, ModelPm.Converter);
                }
            });
        }

        public static void WriteArchive(string outputPath, MechlibArchivePm archive)
        {
            Write(outputPath, archive);
        }
    }
}
