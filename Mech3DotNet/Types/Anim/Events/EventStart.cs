using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public struct EventStart
    {
        public Mech3DotNet.Types.Anim.Events.StartOffset offset;
        public float time;

        public EventStart(Mech3DotNet.Types.Anim.Events.StartOffset offset, float time)
        {
            this.offset = offset;
            this.time = time;
        }
    }

    public static class EventStartConverter
    {
        public static readonly TypeConverter<EventStart> Converter = new TypeConverter<EventStart>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.StartOffset> offset;
            public Field<float> time;
        }

        public static void Serialize(EventStart v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("offset");
            s.Serialize(Mech3DotNet.Types.Anim.Events.StartOffsetConverter.Converter)(v.offset);
            s.SerializeFieldName("time");
            ((Action<float>)s.SerializeF32)(v.time);
        }

        public static EventStart Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                offset = new Field<Mech3DotNet.Types.Anim.Events.StartOffset>(),
                time = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "offset":
                        fields.offset.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.StartOffsetConverter.Converter)();
                        break;
                    case "time":
                        fields.time.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("EventStart", fieldName);
                }
            }
            return new EventStart(

                fields.offset.Unwrap("EventStart", "offset"),

                fields.time.Unwrap("EventStart", "time")

            );
        }
    }
}
