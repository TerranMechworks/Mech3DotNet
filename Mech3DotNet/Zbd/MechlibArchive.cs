using System;
using System.Collections.Generic;
using Mech3DotNet.Exchange;
using Mech3DotNet.Types.Archive;
using Mech3DotNet.Types.Gamez;

namespace Mech3DotNet.Zbd
{
    /// <summary>
    /// A generic mechlib archive.
    ///
    /// See the specific archive implementations for reading and writing ZBDs.
    /// </summary>
    public abstract class MechlibArchive : Archive<MechlibModel>
    {
        public List<MechlibMaterial> materials;

        public MechlibArchive(
            Dictionary<string, MechlibModel> items,
            List<ArchiveEntry> entries,
            List<MechlibMaterial> materials) : base(items, entries)
        {
            this.materials = materials ?? throw new System.ArgumentNullException(nameof(materials));
        }

        protected static readonly byte[] VERSION_MW = BitConverter.GetBytes(27u);
        protected static readonly byte[] VERSION_PM = BitConverter.GetBytes(41u);
        protected static readonly byte[] FORMAT = BitConverter.GetBytes(1u);

        protected static readonly TypeConverter<List<MechlibMaterial>> MaterialsConverter = new TypeConverter<List<MechlibMaterial>>(DeserializeMaterials, SerializeMaterials);

        private static void SerializeMaterials(List<MechlibMaterial> v, Serializer s)
        {
            s.SerializeVec(s.Serialize(MechlibMaterial.Converter))(v);
        }

        private static List<MechlibMaterial> DeserializeMaterials(Deserializer d)
        {
            return d.DeserializeVec(d.Deserialize(MechlibMaterial.Converter))();
        }
    }
}
