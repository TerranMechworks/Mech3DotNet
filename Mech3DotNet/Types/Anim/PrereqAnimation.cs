using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public struct PrereqAnimation
    {
        public string name;

        public PrereqAnimation(string name)
        {
            this.name = name;
        }
    }

    public static class PrereqAnimationConverter
    {
        public static readonly TypeConverter<PrereqAnimation> Converter = new TypeConverter<PrereqAnimation>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<string> name;
        }

        public static void Serialize(PrereqAnimation v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        public static PrereqAnimation Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("PrereqAnimation", fieldName);
                }
            }
            return new PrereqAnimation(

                fields.name.Unwrap("PrereqAnimation", "name")

            );
        }
    }
}
