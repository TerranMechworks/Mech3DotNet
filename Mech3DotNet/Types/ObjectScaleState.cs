using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectScaleState
    {
        public static readonly TypeConverter<ObjectScaleState> Converter = new TypeConverter<ObjectScaleState>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Types.Vec3 scale;

        public ObjectScaleState(string node, Mech3DotNet.Types.Types.Vec3 scale)
        {
            this.node = node;
            this.scale = scale;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Types.Vec3> scale;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.ObjectScaleState v, Serializer s)
        {
            s.SerializeStruct("ObjectScaleState", 2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("scale");
            s.Serialize(Mech3DotNet.Types.Types.Vec3.Converter)(v.scale);
        }

        public static Mech3DotNet.Types.Anim.Events.ObjectScaleState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                scale = new Field<Mech3DotNet.Types.Types.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectScaleState"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "scale":
                        fields.scale.Value = d.Deserialize(Mech3DotNet.Types.Types.Vec3.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectScaleState", fieldName);
                }
            }
            return new ObjectScaleState(

                fields.node.Unwrap("ObjectScaleState", "node"),

                fields.scale.Unwrap("ObjectScaleState", "scale")

            );
        }
    }
}
