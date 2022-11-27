using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectRotateState
    {
        public static readonly TypeConverter<ObjectRotateState> Converter = new TypeConverter<ObjectRotateState>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Anim.Events.RotateState rotate;

        public ObjectRotateState(string node, Mech3DotNet.Types.Anim.Events.RotateState rotate)
        {
            this.node = node;
            this.rotate = rotate;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Anim.Events.RotateState> rotate;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.ObjectRotateState v, Serializer s)
        {
            s.SerializeStruct("ObjectRotateState", 2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("rotate");
            s.Serialize(Mech3DotNet.Types.Anim.Events.RotateState.Converter)(v.rotate);
        }

        public static Mech3DotNet.Types.Anim.Events.ObjectRotateState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                rotate = new Field<Mech3DotNet.Types.Anim.Events.RotateState>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectRotateState"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "rotate":
                        fields.rotate.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.RotateState.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectRotateState", fieldName);
                }
            }
            return new ObjectRotateState(

                fields.node.Unwrap("ObjectRotateState", "node"),

                fields.rotate.Unwrap("ObjectRotateState", "rotate")

            );
        }
    }
}
