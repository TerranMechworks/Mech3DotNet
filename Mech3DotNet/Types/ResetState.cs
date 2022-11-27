using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class ResetState
    {
        public static readonly TypeConverter<ResetState> Converter = new TypeConverter<ResetState>(Deserialize, Serialize);
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event> events;
        public uint pointer;

        public ResetState(System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event> events, uint pointer)
        {
            this.events = events;
            this.pointer = pointer;
        }

        private struct Fields
        {
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event>> events;
            public Field<uint> pointer;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.ResetState v, Serializer s)
        {
            s.SerializeStruct("ResetState", 2);
            s.SerializeFieldName("events");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Events.Event.Converter))(v.events);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
        }

        public static Mech3DotNet.Types.Anim.ResetState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                events = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event>>(),
                pointer = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("ResetState"))
            {
                switch (fieldName)
                {
                    case "events":
                        fields.events.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Events.Event.Converter))();
                        break;
                    case "pointer":
                        fields.pointer.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("ResetState", fieldName);
                }
            }
            return new ResetState(

                fields.events.Unwrap("ResetState", "events"),

                fields.pointer.Unwrap("ResetState", "pointer")

            );
        }
    }
}
