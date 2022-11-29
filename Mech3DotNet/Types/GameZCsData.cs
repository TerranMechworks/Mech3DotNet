using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZCsData
    {
        public static readonly TypeConverter<GameZCsData> Converter = new TypeConverter<GameZCsData>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?> meshes;
        public byte[] nodes;
        public Mech3DotNet.Types.Gamez.GameZCsMetadata metadata;

        public GameZCsData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?> meshes, byte[] nodes, Mech3DotNet.Types.Gamez.GameZCsMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<string>> textures;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>> materials;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?>> meshes;
            public Field<byte[]> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZCsMetadata> metadata;
        }

        public static void Serialize(GameZCsData v, Serializer s)
        {
            s.SerializeStruct("GameZCsData", 5);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter)))(v.meshes);
            s.SerializeFieldName("nodes");
            ((Action<byte[]>)s.SerializeBytes)(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZCsMetadata.Converter)(v.metadata);
        }

        public static GameZCsData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?>>(),
                nodes = new Field<byte[]>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZCsMetadata>(),
            };
            foreach (var fieldName in d.DeserializeStruct("GameZCsData"))
            {
                switch (fieldName)
                {
                    case "textures":
                        fields.textures.Value = d.DeserializeVec(d.DeserializeString)();
                        break;
                    case "materials":
                        fields.materials.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))();
                        break;
                    case "meshes":
                        fields.meshes.Value = d.DeserializeVec(d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter)))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeBytes();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZCsMetadata.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZCsData", fieldName);
                }
            }
            return new GameZCsData(

                fields.textures.Unwrap("GameZCsData", "textures"),

                fields.materials.Unwrap("GameZCsData", "materials"),

                fields.meshes.Unwrap("GameZCsData", "meshes"),

                fields.nodes.Unwrap("GameZCsData", "nodes"),

                fields.metadata.Unwrap("GameZCsData", "metadata")

            );
        }
    }
}
