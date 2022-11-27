using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class StopAnimation
    {
        public static readonly TypeConverter<StopAnimation> Converter = new TypeConverter<StopAnimation>(Deserialize, Serialize);
        public string name;

        public StopAnimation(string name)
        {
            this.name = name;
        }

        private struct Fields
        {
            public Field<string> name;
        }

        public static void Serialize(Mech3DotNet.Types.Anim.Events.StopAnimation v, Serializer s)
        {
            s.SerializeStruct("StopAnimation", 1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        public static Mech3DotNet.Types.Anim.Events.StopAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
            };
            foreach (var fieldName in d.DeserializeStruct("StopAnimation"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    default:
                        throw new UnknownFieldException("StopAnimation", fieldName);
                }
            }
            return new StopAnimation(

                fields.name.Unwrap("StopAnimation", "name")

            );
        }
    }
}
