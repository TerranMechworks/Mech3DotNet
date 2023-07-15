using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataCs
    {
        public static readonly TypeConverter<GameZDataCs> Converter = new TypeConverter<GameZDataCs>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.TextureName> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?> meshes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Cs.NodeCs> nodes;
        public Mech3DotNet.Types.Gamez.GameZMetadataCs metadata;

        public GameZDataCs(System.Collections.Generic.List<Mech3DotNet.Types.Gamez.TextureName> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?> meshes, System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Cs.NodeCs> nodes, Mech3DotNet.Types.Gamez.GameZMetadataCs metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
            this.metadata = metadata;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.TextureName>> textures;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>> materials;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?>> meshes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Cs.NodeCs>> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZMetadataCs> metadata;
        }

        public static void Serialize(GameZDataCs v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("textures");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.TextureName.Converter))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter)))(v.meshes);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Cs.NodeCs.Converter))(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZMetadataCs.Converter)(v.metadata);
        }

        public static GameZDataCs Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.TextureName>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg?>>(),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Cs.NodeCs>>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZMetadataCs>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "textures":
                        fields.textures.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.TextureName.Converter))();
                        break;
                    case "materials":
                        fields.materials.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))();
                        break;
                    case "meshes":
                        fields.meshes.Value = d.DeserializeVec(d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter)))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Cs.NodeCs.Converter))();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZMetadataCs.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZDataCs", fieldName);
                }
            }
            return new GameZDataCs(

                fields.textures.Unwrap("GameZDataCs", "textures"),

                fields.materials.Unwrap("GameZDataCs", "materials"),

                fields.meshes.Unwrap("GameZDataCs", "meshes"),

                fields.nodes.Unwrap("GameZDataCs", "nodes"),

                fields.metadata.Unwrap("GameZDataCs", "metadata")

            );
        }
    }
}
