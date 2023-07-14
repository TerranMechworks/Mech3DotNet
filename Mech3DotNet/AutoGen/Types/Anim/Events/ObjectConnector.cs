using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectConnector
    {
        public static readonly TypeConverter<ObjectConnector> Converter = new TypeConverter<ObjectConnector>(Deserialize, Serialize);
        public string node;
        public string? fromNode = null;
        public string? toNode = null;
        public Mech3DotNet.Types.Types.Vec3? fromPos = null;
        public Mech3DotNet.Types.Types.Vec3? toPos = null;
        public float? maxLength = null;

        public ObjectConnector(string node, string? fromNode, string? toNode, Mech3DotNet.Types.Types.Vec3? fromPos, Mech3DotNet.Types.Types.Vec3? toPos, float? maxLength)
        {
            this.node = node;
            this.fromNode = fromNode;
            this.toNode = toNode;
            this.fromPos = fromPos;
            this.toPos = toPos;
            this.maxLength = maxLength;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<string?> fromNode;
            public Field<string?> toNode;
            public Field<Mech3DotNet.Types.Types.Vec3?> fromPos;
            public Field<Mech3DotNet.Types.Types.Vec3?> toPos;
            public Field<float?> maxLength;
        }

        public static void Serialize(ObjectConnector v, Serializer s)
        {
            s.SerializeStruct(6);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("from_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.fromNode);
            s.SerializeFieldName("to_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.toNode);
            s.SerializeFieldName("from_pos");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.fromPos);
            s.SerializeFieldName("to_pos");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.toPos);
            s.SerializeFieldName("max_length");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.maxLength);
        }

        public static ObjectConnector Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                fromNode = new Field<string?>(null),
                toNode = new Field<string?>(null),
                fromPos = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                toPos = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                maxLength = new Field<float?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "from_node":
                        fields.fromNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "to_node":
                        fields.toNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "from_pos":
                        fields.fromPos.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "to_pos":
                        fields.toPos.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "max_length":
                        fields.maxLength.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectConnector", fieldName);
                }
            }
            return new ObjectConnector(

                fields.node.Unwrap("ObjectConnector", "node"),

                fields.fromNode.Unwrap("ObjectConnector", "fromNode"),

                fields.toNode.Unwrap("ObjectConnector", "toNode"),

                fields.fromPos.Unwrap("ObjectConnector", "fromPos"),

                fields.toPos.Unwrap("ObjectConnector", "toPos"),

                fields.maxLength.Unwrap("ObjectConnector", "maxLength")

            );
        }
    }
}
