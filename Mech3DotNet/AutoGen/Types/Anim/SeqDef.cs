using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class SeqDef
    {
        public static readonly TypeConverter<SeqDef> Converter = new TypeConverter<SeqDef>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.SeqActivation activation;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event> events;
        public uint pointer;

        public SeqDef(string name, Mech3DotNet.Types.Anim.SeqActivation activation, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event> events, uint pointer)
        {
            this.name = name;
            this.activation = activation;
            this.events = events;
            this.pointer = pointer;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.SeqActivation> activation;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event>> events;
            public Field<uint> pointer;
        }

        public static void Serialize(SeqDef v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("activation");
            s.Serialize(Mech3DotNet.Types.Anim.SeqActivationConverter.Converter)(v.activation);
            s.SerializeFieldName("events");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Events.Event.Converter))(v.events);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
        }

        public static SeqDef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                activation = new Field<Mech3DotNet.Types.Anim.SeqActivation>(),
                events = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event>>(),
                pointer = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "activation":
                        fields.activation.Value = d.Deserialize(Mech3DotNet.Types.Anim.SeqActivationConverter.Converter)();
                        break;
                    case "events":
                        fields.events.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Events.Event.Converter))();
                        break;
                    case "pointer":
                        fields.pointer.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("SeqDef", fieldName);
                }
            }
            return new SeqDef(

                fields.name.Unwrap("SeqDef", "name"),

                fields.activation.Unwrap("SeqDef", "activation"),

                fields.events.Unwrap("SeqDef", "events"),

                fields.pointer.Unwrap("SeqDef", "pointer")

            );
        }
    }
}
