﻿using Mech3DotNet.Json;
using Mech3DotNet.Unsafe;
using System;
using System.Collections.Generic;

namespace Mech3DotNet
{
    public class MechlibArchive<V2, V3, Color> : Archive<Model<V2, V3, Color>>
    {
        public List<Material> materials;

        public MechlibArchive(
            Dictionary<string, Model<V2, V3, Color>> items,
            List<Material> materials,
            byte[] manifest) : base(items, manifest)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }

        public MechlibArchive(
            Dictionary<string, Model<V2, V3, Color>> items,
            List<Material> materials,
            List<ArchiveEntry> entries) : base(items, entries)
        {
            this.materials = materials ?? throw new ArgumentNullException(nameof(materials));
        }
    }

    public static class Mechlib<V2, V3, Color>
    {
        private static readonly byte[] VERSION_MW = BitConverter.GetBytes(27u);
        private static readonly byte[] VERSION_PM = BitConverter.GetBytes(41u);
        private static readonly byte[] FORMAT = BitConverter.GetBytes(1u);

        private static Dictionary<string, Model<V2, V3, Color>> Read(string inputPath, bool isPM, out byte[] manifest, out List<Material> materials)
        {
            List<Material> capture = null;
            var models = new Dictionary<string, Model<V2, V3, Color>>();
            manifest = Helpers.ReadArchiveRaw(inputPath, isPM, Interop.read_mechlib, (string name, byte[] data) =>
            {
                if (name == "format" || name == "version")
                    return;
                var json = Interop.GetString(data);
                if (name == "materials")
                    capture = Settings.DeserializeObject<List<Material>>(json);
                else
                {
                    var model = Settings.DeserializeObject<Model<V2, V3, Color>>(json);
                    models.Add(name, model);
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
        public static MechlibArchive<V2, V3, Color> ReadArchiveMW(string inputPath)
        {
            var items = Read(inputPath, false, out byte[] manifest, out List<Material> materials);
            return new MechlibArchive<V2, V3, Color>(items, materials, manifest);
        }

        private static void Write(string outputPath, bool isPM, MechlibArchive<V2, V3, Color> archive)
        {
            var manifest = archive.GetManifest();
            Helpers.WriteArchiveRaw(outputPath, isPM, manifest, Interop.write_mechlib, (string name) =>
            {
                if (name == "format")
                    return FORMAT;
                if (name == "version")
                    return isPM ? VERSION_PM : VERSION_MW;

                string json = null;
                if (name == "materials")
                    json = Settings.SerializeObject(archive.materials);
                else
                {
                    var item = archive.items[name];
                    json = Settings.SerializeObject(item);
                }
                return Interop.GetBytes(json);
            });
        }

        /// <summary>
        /// Write a mechlib archive (mechlib.zbd) from the base game.
        /// </summary>
        public static void WriteArchiveMW(string outputPath, MechlibArchive<V2, V3, Color> archive)
        {
            Write(outputPath, false, archive);
        }
    }
}
