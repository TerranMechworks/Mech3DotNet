using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectConnector
    {
        public static readonly TypeConverter<ObjectConnector> Converter = new TypeConverter<ObjectConnector>(Deserialize, Serialize);
        public string name;
        public string? fromNode;
        public string? toNode;
        public Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? fromPos;
        public Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? toPos;
        public Mech3DotNet.Types.Anim.Events.ObjectConnectorTime? fromT;
        public Mech3DotNet.Types.Anim.Events.ObjectConnectorTime? toT;
        public float runTime;
        public float? maxLength;

        public ObjectConnector(string name, string? fromNode, string? toNode, Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? fromPos, Mech3DotNet.Types.Anim.Events.ObjectConnectorPos? toPos, Mech3DotNet.Types.Anim.Events.ObjectConnectorTime? fromT, Mech3DotNet.Types.Anim.Events.ObjectConnectorTime? toT, float runTime, float? maxLength)
        {
            this.name = name;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.fromPos = fromPos;
            this.toPos = toPos;
            this.fromT = fromT;
            this.toT = toT;
            this.runTime = runTime;
            this.maxLength = maxLength;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<string?> fromNode;
            public Field<string?> toNode;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?> fromPos;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?> toPos;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorTime?> fromT;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorTime?> toT;
            public Field<float> runTime;
            public Field<float?> maxLength;
        }

        public static void Serialize(ObjectConnector v, Serializer s)
        {
            s.SerializeStruct(9);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("from_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.fromNode);
            s.SerializeFieldName("to_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.toNode);
            s.SerializeFieldName("from_pos");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))(v.fromPos);
            s.SerializeFieldName("to_pos");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))(v.toPos);
            s.SerializeFieldName("from_t");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorTime.Converter))(v.fromT);
            s.SerializeFieldName("to_t");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorTime.Converter))(v.toT);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
            s.SerializeFieldName("max_length");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.maxLength);
        }

        public static ObjectConnector Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                fromNode = new Field<string?>(),
                toNode = new Field<string?>(),
                fromPos = new Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?>(),
                toPos = new Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorPos?>(),
                fromT = new Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorTime?>(),
                toT = new Field<Mech3DotNet.Types.Anim.Events.ObjectConnectorTime?>(),
                runTime = new Field<float>(),
                maxLength = new Field<float?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "from_node":
                        fields.fromNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "to_node":
                        fields.toNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "from_pos":
                        fields.fromPos.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))();
                        break;
                    case "to_pos":
                        fields.toPos.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorPos.Converter))();
                        break;
                    case "from_t":
                        fields.fromT.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorTime.Converter))();
                        break;
                    case "to_t":
                        fields.toT.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnectorTime.Converter))();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    case "max_length":
                        fields.maxLength.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectConnector", fieldName);
                }
            }
            return new ObjectConnector(

                fields.name.Unwrap("ObjectConnector", "name"),

                fields.fromNode.Unwrap("ObjectConnector", "fromNode"),

                fields.toNode.Unwrap("ObjectConnector", "toNode"),

                fields.fromPos.Unwrap("ObjectConnector", "fromPos"),

                fields.toPos.Unwrap("ObjectConnector", "toPos"),

                fields.fromT.Unwrap("ObjectConnector", "fromT"),

                fields.toT.Unwrap("ObjectConnector", "toT"),

                fields.runTime.Unwrap("ObjectConnector", "runTime"),

                fields.maxLength.Unwrap("ObjectConnector", "maxLength")

            );
        }
    }
}
