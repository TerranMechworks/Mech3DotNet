using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class GameZ
    {
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Texture> textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model> models;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node> nodes;
        public Mech3DotNet.Types.Gamez.GameZMetadata metadata;

        public GameZ(System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Texture> textures, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material> materials, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model> models, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node> nodes, Mech3DotNet.Types.Gamez.GameZMetadata metadata)
        {
            this.textures = textures;
            this.materials = materials;
            this.models = models;
            this.nodes = nodes;
            this.metadata = metadata;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<GameZ> Converter = new TypeConverter<GameZ>(Deserialize, Serialize);

        public static void Serialize(GameZ v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("textures");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Texture.Converter))(v.textures);
            s.SerializeFieldName("materials");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))(v.materials);
            s.SerializeFieldName("models");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Model.Model.Converter))(v.models);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Node.Converter))(v.nodes);
            s.SerializeFieldName("metadata");
            s.Serialize(Mech3DotNet.Types.Gamez.GameZMetadata.Converter)(v.metadata);
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Texture>> textures;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>> materials;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model>> models;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node>> nodes;
            public Field<Mech3DotNet.Types.Gamez.GameZMetadata> metadata;
        }

        public static GameZ Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                textures = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Texture>>(),
                materials = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Materials.Material>>(),
                models = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model>>(),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node>>(),
                metadata = new Field<Mech3DotNet.Types.Gamez.GameZMetadata>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "textures":
                        fields.textures.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Texture.Converter))();
                        break;
                    case "materials":
                        fields.materials.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Materials.Material.Converter))();
                        break;
                    case "models":
                        fields.models.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Model.Model.Converter))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Node.Converter))();
                        break;
                    case "metadata":
                        fields.metadata.Value = d.Deserialize(Mech3DotNet.Types.Gamez.GameZMetadata.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("GameZ", fieldName);
                }
            }
            return new GameZ(

                fields.textures.Unwrap("GameZ", "textures"),

                fields.materials.Unwrap("GameZ", "materials"),

                fields.models.Unwrap("GameZ", "models"),

                fields.nodes.Unwrap("GameZ", "nodes"),

                fields.metadata.Unwrap("GameZ", "metadata")

            );
        }

        #endregion
    }
}
