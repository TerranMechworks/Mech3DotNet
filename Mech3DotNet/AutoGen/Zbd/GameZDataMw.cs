using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataMw
    {
        public static readonly TypeConverter<GameZDataMw> Converter = new TypeConverter<GameZDataMw>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw> meshes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw> nodes;
        public Mech3DotNet.Types.Gamez.GameZMetadataMw metadata;

        public GameZDataMw(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw> meshes, System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw> nodes, Mech3DotNet.Types.Gamez.GameZMetadataMw metadata)
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
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw>> meshes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw>> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZMetadataMw> metadata;
        }

        public static void Serialize(GameZDataMw v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw.Converter))(v.meshes);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Mw.NodeMw.Converter))(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZMetadataMw.Converter)(v.metadata);
        }

        public static GameZDataMw Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw>>(),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw>>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZMetadataMw>(),
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
                        fields.meshes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw.Converter))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Mw.NodeMw.Converter))();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZMetadataMw.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZDataMw", fieldName);
                }
            }
            return new GameZDataMw(

                fields.textures.Unwrap("GameZDataMw", "textures"),

                fields.materials.Unwrap("GameZDataMw", "materials"),

                fields.meshes.Unwrap("GameZDataMw", "meshes"),

                fields.nodes.Unwrap("GameZDataMw", "nodes"),

                fields.metadata.Unwrap("GameZDataMw", "metadata")

            );
        }
    }
}
