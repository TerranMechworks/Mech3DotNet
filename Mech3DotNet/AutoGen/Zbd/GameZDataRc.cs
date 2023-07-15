using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Zbd
{
    public partial class GameZDataRc
    {
        public static readonly TypeConverter<GameZDataRc> Converter = new TypeConverter<GameZDataRc>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc> meshes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Rc.NodeRc> nodes;

        public GameZDataRc(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc> meshes, System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Rc.NodeRc> nodes)
        {
            this.textures = textures;
            this.materials = materials;
            this.meshes = meshes;
            this.nodes = nodes;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<string>> textures;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>> materials;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc>> meshes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Rc.NodeRc>> nodes;
        }

        public static void Serialize(GameZDataRc v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc.Converter))(v.meshes);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Rc.NodeRc.Converter))(v.nodes);
        }

        public static GameZDataRc Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc>>(),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Rc.NodeRc>>(),
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
                        fields.meshes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc.Converter))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Rc.NodeRc.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("GameZDataRc", fieldName);
                }
            }
            return new GameZDataRc(

                fields.textures.Unwrap("GameZDataRc", "textures"),

                fields.materials.Unwrap("GameZDataRc", "materials"),

                fields.meshes.Unwrap("GameZDataRc", "meshes"),

                fields.nodes.Unwrap("GameZDataRc", "nodes")

            );
        }
    }
}
