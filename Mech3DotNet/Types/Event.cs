using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Event
    {
        public static readonly TypeConverter<Event> Converter = new TypeConverter<Event>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.EventData data;
        public Mech3DotNet.Types.Anim.Events.EventStart? start;

        public Event(Mech3DotNet.Types.Anim.Events.EventData data, Mech3DotNet.Types.Anim.Events.EventStart? start)
        {
            this.data = data;
            this.start = start;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.EventData> data;
            public Field<Mech3DotNet.Types.Anim.Events.EventStart?> start;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.Event v, Serializer s)
        {
            s.SerializeStruct("Event", 2);
            s.SerializeFieldName("data");
            s.Serialize(Mech3DotNet.Types.Anim.Events.EventData.Converter)(v.data);
            s.SerializeFieldName("start");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Anim.Events.EventStart.Converter))(v.start);
        }

        public static Mech3DotNet.Types.Anim.Events.Event Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                data = new Field<Mech3DotNet.Types.Anim.Events.EventData>(),
                start = new Field<Mech3DotNet.Types.Anim.Events.EventStart?>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Event"))
            {
                switch (fieldName)
                {
                    case "data":
                        fields.data.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.EventData.Converter)();
                        break;
                    case "start":
                        fields.start.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.EventStart.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("Event", fieldName);
                }
            }
            return new Event(

                fields.data.Unwrap("Event", "data"),

                fields.start.Unwrap("Event", "start")

            );
        }
    }
}
