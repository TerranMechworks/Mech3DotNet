using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZRcData
    {
        public static readonly TypeConverter<GameZRcData> Converter = new TypeConverter<GameZRcData>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc> meshes;
        public byte[] nodes;
        public Mech3DotNet.Types.Gamez.GameZRcMetadata metadata;

        public GameZRcData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc> meshes, byte[] nodes, Mech3DotNet.Types.Gamez.GameZRcMetadata metadata)
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
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc>> meshes;
            public Field<byte[]> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZRcMetadata> metadata;
        }

        public static void Serialize(GameZRcData v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc.Converter))(v.meshes);
            s.SerializeFieldName("nodes");
            ((Action<byte[]>)s.SerializeBytes)(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZRcMetadata.Converter)(v.metadata);
        }

        public static GameZRcData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Rc.MeshRc>>(),
                nodes = new Field<byte[]>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZRcMetadata>(),
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
                        fields.nodes.Value = d.DeserializeBytes();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZRcMetadata.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZRcData", fieldName);
                }
            }
            return new GameZRcData(

                fields.textures.Unwrap("GameZRcData", "textures"),

                fields.materials.Unwrap("GameZRcData", "materials"),

                fields.meshes.Unwrap("GameZRcData", "meshes"),

                fields.nodes.Unwrap("GameZRcData", "nodes"),

                fields.metadata.Unwrap("GameZRcData", "metadata")

            );
        }
    }
}
