using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ResetAnimation
    {
        public static readonly TypeConverter<ResetAnimation> Converter = new TypeConverter<ResetAnimation>(Deserialize, Serialize);
        public string name;

        public ResetAnimation(string name)
        {
            this.name = name;
        }

        private struct Fields
        {
            public Field<string> name;
        }

        public static void Serialize(ResetAnimation v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        public static ResetAnimation Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("ResetAnimation", fieldName);
                }
            }
            return new ResetAnimation(

                fields.name.Unwrap("ResetAnimation", "name")

            );
        }
    }
}
