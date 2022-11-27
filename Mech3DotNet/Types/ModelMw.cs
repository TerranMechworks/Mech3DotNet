using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mechlib
{
    public sealed class ModelMw
    {
        public static readonly TypeConverter<ModelMw> Converter = new TypeConverter<ModelMw>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw> nodes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw> meshes;
        public System.Collections.Generic.List<int> meshPtrs;

        public ModelMw(System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw> nodes, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw> meshes, System.Collections.Generic.List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw>> nodes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw>> meshes;
            public Field<System.Collections.Generic.List<int>> meshPtrs;
        }

        public static void Serialize(Mech3DotNet.Types.Gamez.Mechlib.ModelMw v, Serializer s)
        {
            s.SerializeStruct("ModelMw", 3);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Mw.NodeMw.Converter))(v.nodes);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw.Converter))(v.meshes);
            s.SerializeFieldName("mesh_ptrs");
            s.SerializeVec(((Action<int>)s.SerializeI32))(v.meshPtrs);
        }

        public static Mech3DotNet.Types.Gamez.Mechlib.ModelMw Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Mw.NodeMw>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw>>(),
                meshPtrs = new Field<System.Collections.Generic.List<int>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ModelMw"))
            {
                switch (fieldName)
                {
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Mw.NodeMw.Converter))();
                        break;
                    case "meshes":
                        fields.meshes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Mw.MeshMw.Converter))();
                        break;
                    case "mesh_ptrs":
                        fields.meshPtrs.Value = d.DeserializeVec(d.DeserializeI32)();
                        break;
                    default:
                        throw new UnknownFieldException("ModelMw", fieldName);
                }
            }
            return new ModelMw(

                fields.nodes.Unwrap("ModelMw", "nodes"),

                fields.meshes.Unwrap("ModelMw", "meshes"),

                fields.meshPtrs.Unwrap("ModelMw", "meshPtrs")

            );
        }
    }
}
