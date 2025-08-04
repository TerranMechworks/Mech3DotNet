using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Event
    {
        public static readonly TypeConverter<Event> Converter = new TypeConverter<Event>(Deserialize, Serialize);
        public Mech3DotNet.Types.Anim.Events.EventStart? start;
        public Mech3DotNet.Types.Anim.Events.EventData data;

        public Event(Mech3DotNet.Types.Anim.Events.EventStart? start, Mech3DotNet.Types.Anim.Events.EventData data)
        {
            this.start = start;
            this.data = data;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.EventStart?> start;
            public Field<Mech3DotNet.Types.Anim.Events.EventData> data;
        }

        public static void Serialize(Event v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("start");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.EventStart.Converter))(v.start);
            s.SerializeFieldName("data");
            s.Serialize(Mech3DotNet.Types.Anim.Events.EventData.Converter)(v.data);
        }

        public static Event Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                start = new Field<Mech3DotNet.Types.Anim.Events.EventStart?>(),
                data = new Field<Mech3DotNet.Types.Anim.Events.EventData>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "start":
                        fields.start.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.EventStart.Converter))();
                        break;
                    case "data":
                        fields.data.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.EventData.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("Event", fieldName);
                }
            }
            return new Event(

                fields.start.Unwrap("Event", "start"),

                fields.data.Unwrap("Event", "data")

            );
        }
    }
}
