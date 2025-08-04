using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez
{
    public sealed class MechlibModel
    {
        public static readonly TypeConverter<MechlibModel> Converter = new TypeConverter<MechlibModel>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node> nodes;
        public System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model> models;

        public MechlibModel(System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node> nodes, System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model> models)
        {
            this.nodes = nodes;
            this.models = models;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node>> nodes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model>> models;
        }

        public static void Serialize(MechlibModel v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("nodes");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Nodes.Node.Converter))(v.nodes);
            s.SerializeFieldName("models");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Gamez.Model.Model.Converter))(v.models);
        }

        public static MechlibModel Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Nodes.Node>>(),
                models = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Gamez.Model.Model>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "nodes":
                        fields.nodes.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Nodes.Node.Converter))();
                        break;
                    case "models":
                        fields.models.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Gamez.Model.Model.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("MechlibModel", fieldName);
                }
            }
            return new MechlibModel(

                fields.nodes.Unwrap("MechlibModel", "nodes"),

                fields.models.Unwrap("MechlibModel", "models")

            );
        }
    }
}
