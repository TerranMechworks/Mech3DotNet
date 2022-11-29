using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectOpacityFromTo
    {
        public static readonly TypeConverter<ObjectOpacityFromTo> Converter = new TypeConverter<ObjectOpacityFromTo>(Deserialize, Serialize);
        public string node;
        public Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityFrom;
        public Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityTo;
        public float runtime;
        public bool fudge = false;

        public ObjectOpacityFromTo(string node, Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityFrom, Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityTo, float runtime, bool fudge)
        {
            this.node = node;
            this.opacityFrom = opacityFrom;
            this.opacityTo = opacityTo;
            this.runtime = runtime;
            this.fudge = fudge;
        }

        private struct Fields
        {
            public Field<string> node;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity> opacityFrom;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity> opacityTo;
            public Field<float> runtime;
            public Field<bool> fudge;
        }

        public static void Serialize(ObjectOpacityFromTo v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("node");
            ((Action<string>)s.SerializeString)(v.node);
            s.SerializeFieldName("opacity_from");
            s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityConverter.Converter)(v.opacityFrom);
            s.SerializeFieldName("opacity_to");
            s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityConverter.Converter)(v.opacityTo);
            s.SerializeFieldName("runtime");
            ((Action<float>)s.SerializeF32)(v.runtime);
            s.SerializeFieldName("fudge");
            ((Action<bool>)s.SerializeBool)(v.fudge);
        }

        public static ObjectOpacityFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                node = new Field<string>(),
                opacityFrom = new Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity>(),
                opacityTo = new Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity>(),
                runtime = new Field<float>(),
                fudge = new Field<bool>(false),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "node":
                        fields.node.Value = d.DeserializeString();
                        break;
                    case "opacity_from":
                        fields.opacityFrom.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityConverter.Converter)();
                        break;
                    case "opacity_to":
                        fields.opacityTo.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityConverter.Converter)();
                        break;
                    case "runtime":
                        fields.runtime.Value = d.DeserializeF32();
                        break;
                    case "fudge":
                        fields.fudge.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectOpacityFromTo", fieldName);
                }
            }
            return new ObjectOpacityFromTo(

                fields.node.Unwrap("ObjectOpacityFromTo", "node"),

                fields.opacityFrom.Unwrap("ObjectOpacityFromTo", "opacityFrom"),

                fields.opacityTo.Unwrap("ObjectOpacityFromTo", "opacityTo"),

                fields.runtime.Unwrap("ObjectOpacityFromTo", "runtime"),

                fields.fudge.Unwrap("ObjectOpacityFromTo", "fudge")

            );
        }
    }
}
