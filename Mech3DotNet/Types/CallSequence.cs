using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallSequence
    {
        public static readonly TypeConverter<CallSequence> Converter = new TypeConverter<CallSequence>(Deserialize, Serialize);
        public string name;

        public CallSequence(string name)
        {
            this.name = name;
        }

        private struct Fields
        {
            public Field<string> name;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.CallSequence v, Serializer s)
        {
            s.SerializeStruct("CallSequence", 1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        public static Mech3DotNet.Types.Anim.Events.CallSequence Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct("CallSequence"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    default:
                        throw new UnknownFieldException("CallSequence", fieldName);
                }
            }
            return new CallSequence(

                fields.name.Unwrap("CallSequence", "name")

            );
        }
    }
}
