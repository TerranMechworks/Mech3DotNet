using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectOpacityFromTo
    {
        public static readonly TypeConverter<ObjectOpacityFromTo> Converter = new TypeConverter<ObjectOpacityFromTo>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityFrom;
        public Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityTo;
        public float runTime;
        public float? opacityDelta = null;

        public ObjectOpacityFromTo(string name, Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityFrom, Mech3DotNet.Types.Anim.Events.ObjectOpacity opacityTo, float runTime, float? opacityDelta)
        {
            this.name = name;
            this.opacityFrom = opacityFrom;
            this.opacityTo = opacityTo;
            this.runTime = runTime;
            this.opacityDelta = opacityDelta;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity> opacityFrom;
            public Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity> opacityTo;
            public Field<float> runTime;
            public Field<float?> opacityDelta;
        }

        public static void Serialize(ObjectOpacityFromTo v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("opacity_from");
            s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectOpacity.Converter)(v.opacityFrom);
            s.SerializeFieldName("opacity_to");
            s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectOpacity.Converter)(v.opacityTo);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
            s.SerializeFieldName("opacity_delta");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.opacityDelta);
        }

        public static ObjectOpacityFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                opacityFrom = new Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity>(),
                opacityTo = new Field<Mech3DotNet.Types.Anim.Events.ObjectOpacity>(),
                runTime = new Field<float>(),
                opacityDelta = new Field<float?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "opacity_from":
                        fields.opacityFrom.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectOpacity.Converter)();
                        break;
                    case "opacity_to":
                        fields.opacityTo.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectOpacity.Converter)();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    case "opacity_delta":
                        fields.opacityDelta.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectOpacityFromTo", fieldName);
                }
            }
            return new ObjectOpacityFromTo(

                fields.name.Unwrap("ObjectOpacityFromTo", "name"),

                fields.opacityFrom.Unwrap("ObjectOpacityFromTo", "opacityFrom"),

                fields.opacityTo.Unwrap("ObjectOpacityFromTo", "opacityTo"),

                fields.runTime.Unwrap("ObjectOpacityFromTo", "runTime"),

                fields.opacityDelta.Unwrap("ObjectOpacityFromTo", "opacityDelta")

            );
        }
    }
}
