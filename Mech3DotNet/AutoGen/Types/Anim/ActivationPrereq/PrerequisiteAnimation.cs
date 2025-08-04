using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.ActivationPrereq
{
    public sealed class PrerequisiteAnimation
    {
        public static readonly TypeConverter<PrerequisiteAnimation> Converter = new TypeConverter<PrerequisiteAnimation>(Deserialize, Serialize);
        public string name;
        public bool required;

        public PrerequisiteAnimation(string name, bool required)
        {
            this.name = name;
            this.required = required;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> required;
        }

        public static void Serialize(PrerequisiteAnimation v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("required");
            ((Action<bool>)s.SerializeBool)(v.required);
        }

        public static PrerequisiteAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                required = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "required":
                        fields.required.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("PrerequisiteAnimation", fieldName);
                }
            }
            return new PrerequisiteAnimation(

                fields.name.Unwrap("PrerequisiteAnimation", "name"),

                fields.required.Unwrap("PrerequisiteAnimation", "required")

            );
        }
    }
}
