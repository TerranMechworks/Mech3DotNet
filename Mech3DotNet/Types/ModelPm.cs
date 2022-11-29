using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Mechlib
{
    public sealed class ModelPm
    {
        public static readonly TypeConverter<ModelPm> Converter = new TypeConverter<ModelPm>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm> nodes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg> meshes;
        public System.Collections.Generic.List<int> meshPtrs;

        public ModelPm(System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm> nodes, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg> meshes, System.Collections.Generic.List<int> meshPtrs)
        {
            this.nodes = nodes;
            this.meshes = meshes;
            this.meshPtrs = meshPtrs;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm>> nodes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg>> meshes;
            public Field<System.Collections.Generic.List<int>> meshPtrs;
        }

        public static void Serialize(ModelPm v, Serializer s)
        {
            s.SerializeStruct("ModelPm", 3);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Nodes.Pm.NodePm.Converter))(v.nodes);
            s.SerializeFieldName("meshes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter))(v.meshes);
            s.SerializeFieldName("mesh_ptrs");
            s.SerializeVec(((Action<int>)s.SerializeI32))(v.meshPtrs);
        }

        public static ModelPm Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Nodes.Pm.NodePm>>(),
                meshes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg>>(),
                meshPtrs = new Field<System.Collections.Generic.List<int>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ModelPm"))
            {
                switch (fieldName)
                {
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Nodes.Pm.NodePm.Converter))();
                        break;
                    case "meshes":
                        fields.meshes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Mesh.Ng.MeshNg.Converter))();
                        break;
                    case "mesh_ptrs":
                        fields.meshPtrs.Value = d.DeserializeVec(d.DeserializeI32)();
                        break;
                    default:
                        throw new UnknownFieldException("ModelPm", fieldName);
                }
            }
            return new ModelPm(

                fields.nodes.Unwrap("ModelPm", "nodes"),

                fields.meshes.Unwrap("ModelPm", "meshes"),

                fields.meshPtrs.Unwrap("ModelPm", "meshPtrs")

            );
        }
    }
}
