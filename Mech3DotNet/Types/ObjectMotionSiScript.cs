using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectMotionSiScript
    {
        public static readonly TypeConverter<ObjectMotionSiScript> Converter = new TypeConverter<ObjectMotionSiScript>(Deserialize, Serialize);
        public string node;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.ObjectMotionSiFrame> frames;

        public ObjectMotionSiScript(string node, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.ObjectMotionSiFrame> frames)
        {
            this.node = node;
            this.frames = frames;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.ObjectMotionSiFrame>> frames;
        }

        public static void Serialize(ObjectMotionSiScript v, Serializer s)
        {
            s.SerializeStruct("ObjectMotionSiScript", 2);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("frames");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionSiFrame.Converter))(v.frames);
        }

        public static ObjectMotionSiScript Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                frames = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.ObjectMotionSiFrame>>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ObjectMotionSiScript"))
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "frames":
                        fields.frames.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionSiFrame.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectMotionSiScript", fieldName);
                }
            }
            return new ObjectMotionSiScript(

                fields.node.Unwrap("ObjectMotionSiScript", "node"),

                fields.frames.Unwrap("ObjectMotionSiScript", "frames")

            );
        }
    }
}
