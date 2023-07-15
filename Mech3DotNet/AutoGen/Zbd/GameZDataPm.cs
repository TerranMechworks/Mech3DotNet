using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataPm
    {
        public static readonly TypeConverter<GameZDataPm> Converter = new TypeConverter<GameZDataPm>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg> meshes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm> nodes;
        public Mech3DotNet.Types.Gamez.GameZMetadataPm metadata;

        public GameZDataPm(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg> meshes, System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm> nodes, Mech3DotNet.Types.Gamez.GameZMetadataPm metadata)
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
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg>> meshes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm>> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZMetadataPm> metadata;
        }

        public static void Serialize(GameZDataPm v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter))(v.meshes);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Pm.NodePm.Converter))(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZMetadataPm.Converter)(v.metadata);
        }

        public static GameZDataPm Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg>>(),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm>>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZMetadataPm>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
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
                        fields.meshes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Pm.NodePm.Converter))();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZMetadataPm.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZDataPm", fieldName);
                }
            }
            return new GameZDataPm(

                fields.textures.Unwrap("GameZDataPm", "textures"),

                fields.materials.Unwrap("GameZDataPm", "materials"),

                fields.meshes.Unwrap("GameZDataPm", "meshes"),

                fields.nodes.Unwrap("GameZDataPm", "nodes"),

                fields.metadata.Unwrap("GameZDataPm", "metadata")

            );
        }
    }
}
