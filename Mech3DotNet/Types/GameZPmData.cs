using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZPmData
    {
        public static readonly TypeConverter<GameZPmData> Converter = new TypeConverter<GameZPmData>(Deserialize, Serialize);
        public System.Collections.Generic.List<string> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg> meshes;
        public byte[] nodes;
        public Mech3DotNet.Types.Gamez.GameZPmMetadata metadata;

        public GameZPmData(System.Collections.Generic.List<string> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg> meshes, byte[] nodes, Mech3DotNet.Types.Gamez.GameZPmMetadata metadata)
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
            public Field<byte[]> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZPmMetadata> metadata;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.GameZPmData v, Serializer s)
        {
            s.SerializeStruct("GameZPmData", 5);
            s.SerializeFieldName("textures");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter))(v.meshes);
            s.SerializeFieldName("nodes");
            ((Action<byte[]>)s.SerializeBytes)(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZPmMetadata.Converter)(v.metadata);
        }

        public static Mech3DotNet.Types.Gamez.GameZPmData Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<string>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg>>(),
                nodes = new Field<byte[]>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZPmMetadata>(),
            };
            foreach (var fieldName in d.DeserializeStruct("GameZPmData"))
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
                        fields.nodes.Value = d.DeserializeBytes();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZPmMetadata.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZPmData", fieldName);
                }
            }
            return new GameZPmData(

                fields.textures.Unwrap("GameZPmData", "textures"),

                fields.materials.Unwrap("GameZPmData", "materials"),

                fields.meshes.Unwrap("GameZPmData", "meshes"),

                fields.nodes.Unwrap("GameZPmData", "nodes"),

                fields.metadata.Unwrap("GameZPmData", "metadata")

            );
        }
    }
}
