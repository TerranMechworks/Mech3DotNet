using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class StopSequence
    {
        public static readonly TypeConverter<StopSequence> Converter = new TypeConverter<StopSequence>(Deserialize, Serialize);
        public string name;

        public StopSequence(string name)
        {
            this.name = name;
        }

        private struct Fields
        {
            public Field<string> name;
        }

        public static void Serialize(StopSequence v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        public static StopSequence Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    default:
                        throw new UnknownFieldException("StopSequence", fieldName);
                }
            }
            return new StopSequence(

                fields.name.Unwrap("StopSequence", "name")

            );
        }
    }
}
