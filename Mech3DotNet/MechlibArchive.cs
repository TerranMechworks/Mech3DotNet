using System;
using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Gamez.Materials;

namespace Mech3DotNet
{
    public abstract class MechlibArchive<TModel> : Archive<TModel>
    {
        public List<Material> materials;

        public MechlibArchive(
            Dictionary<string, TModel> items,
            List<ArchiveEntry> entries,
            List<Material> materials) : base(items, entries)
        {
            this.materials = materials ?? throw new System.ArgumentNullException(nameof(materials));
        }

        protected static readonly byte[] VERSION_MW = BitConverter.GetBytes(27u);
        protected static readonly byte[] VERSION_PM = BitConverter.GetBytes(41u);
        protected static readonly byte[] FORMAT = BitConverter.GetBytes(1u);

        protected static readonly TypeConverter<List<Material>> MaterialsConverter = new TypeConverter<List<Material>>(DeserializeMaterials, SerializeMaterials);

        private static void SerializeMaterials(List<Material> v, Serializer s)
        {
            s.SerializeVec(s.Serialize(Material.Converter))(v);
        }

        private static List<Material> DeserializeMaterials(Deserializer d)
        {
            return d.DeserializeVec(d.Deserialize(Material.Converter))();
        }
    }
}
