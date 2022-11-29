using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class InvalidateAnimation
    {
        public static readonly TypeConverter<InvalidateAnimation> Converter = new TypeConverter<InvalidateAnimation>(Deserialize, Serialize);
        public string name;

        public InvalidateAnimation(string name)
        {
            this.name = name;
        }

        private struct Fields
        {
            public Field<string> name;
        }

        public static void Serialize(InvalidateAnimation v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        public static InvalidateAnimation Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("InvalidateAnimation", fieldName);
                }
            }
            return new InvalidateAnimation(

                fields.name.Unwrap("InvalidateAnimation", "name")

            );
        }
    }
}
