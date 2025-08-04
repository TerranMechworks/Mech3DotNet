using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public sealed class SeqDef
    {
        public static readonly TypeConverter<SeqDef> Converter = new TypeConverter<SeqDef>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.AnimDef.SeqDefState seqState;
        public Mech3DotNet.Types.Anim.AnimDef.SeqDefState resetState;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event> events;
        public uint pointer;

        public SeqDef(string name, Mech3DotNet.Types.Anim.AnimDef.SeqDefState seqState, Mech3DotNet.Types.Anim.AnimDef.SeqDefState resetState, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event> events, uint pointer)
        {
            this.name = name;
            this.seqState = seqState;
            this.resetState = resetState;
            this.events = events;
            this.pointer = pointer;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.AnimDef.SeqDefState> seqState;
            public Field<Mech3DotNet.Types.Anim.AnimDef.SeqDefState> resetState;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.Event>> events;
            public Field<uint> pointer;
        }

        public static void Serialize(SeqDef v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("seq_state");
            s.Serialize(Mech3DotNet.Types.Anim.AnimDef.SeqDefStateConverter.Converter)(v.seqState);
            s.SerializeFieldName("reset_state");
            s.Serialize(Mech3DotNet.Types.Anim.AnimDef.SeqDefStateConverter.Converter)(v.resetState);
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
                seqState = new Field<Mech3DotNet.Types.Anim.AnimDef.SeqDefState>(),
                resetState = new Field<Mech3DotNet.Types.Anim.AnimDef.SeqDefState>(),
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
                    case "seq_state":
                        fields.seqState.Value = d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.SeqDefStateConverter.Converter)();
                        break;
                    case "reset_state":
                        fields.resetState.Value = d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.SeqDefStateConverter.Converter)();
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

                fields.seqState.Unwrap("SeqDef", "seqState"),

                fields.resetState.Unwrap("SeqDef", "resetState"),

                fields.events.Unwrap("SeqDef", "events"),

                fields.pointer.Unwrap("SeqDef", "pointer")

            );
        }
    }
}
