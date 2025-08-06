using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallObjectConnector
    {
        public string name;
        public short? saveIndex;
        public Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget? fromNode;
        public Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget? toNode;
        public Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? fromPos;
        public Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? toPos;

        public CallObjectConnector(string name, short? saveIndex, Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget? fromNode, Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget? toNode, Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? fromPos, Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? toPos)
        {
            this.name = name;
            this.saveIndex = saveIndex;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.fromPos = fromPos;
            this.toPos = toPos;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<CallObjectConnector> Converter = new TypeConverter<CallObjectConnector>(Deserialize, Serialize);

        public static void Serialize(CallObjectConnector v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("save_index");
            s.SerializeValOption(((Action<short>)s.SerializeI16))(v.saveIndex);
            s.SerializeFieldName("from_node");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget.Converter))(v.fromNode);
            s.SerializeFieldName("to_node");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget.Converter))(v.toNode);
            s.SerializeFieldName("from_pos");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))(v.fromPos);
            s.SerializeFieldName("to_pos");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))(v.toPos);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<short?> saveIndex;
            public Field<Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget?> fromNode;
            public Field<Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget?> toNode;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?> fromPos;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?> toPos;
        }

        public static CallObjectConnector Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                saveIndex = new Field<short?>(),
                fromNode = new Field<Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget?>(),
                toNode = new Field<Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget?>(),
                fromPos = new Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?>(),
                toPos = new Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "save_index":
                        fields.saveIndex.Value = d.DeserializeValOption(d.DeserializeI16)();
                        break;
                    case "from_node":
                        fields.fromNode.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget.Converter))();
                        break;
                    case "to_node":
                        fields.toNode.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.CallObjectConnectorTarget.Converter))();
                        break;
                    case "from_pos":
                        fields.fromPos.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))();
                        break;
                    case "to_pos":
                        fields.toPos.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("CallObjectConnector", fieldName);
                }
            }
            return new CallObjectConnector(

                fields.name.Unwrap("CallObjectConnector", "name"),

                fields.saveIndex.Unwrap("CallObjectConnector", "saveIndex"),

                fields.fromNode.Unwrap("CallObjectConnector", "fromNode"),

                fields.toNode.Unwrap("CallObjectConnector", "toNode"),

                fields.fromPos.Unwrap("CallObjectConnector", "fromPos"),

                fields.toPos.Unwrap("CallObjectConnector", "toPos")

            );
        }

        #endregion
    }
}
