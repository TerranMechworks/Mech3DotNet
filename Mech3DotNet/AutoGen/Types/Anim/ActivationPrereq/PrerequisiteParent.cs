using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.ActivationPrereq
{
    public sealed class PrerequisiteParent
    {
        public static readonly TypeConverter<PrerequisiteParent> Converter = new TypeConverter<PrerequisiteParent>(Deserialize, Serialize);
        public string name;
        public bool required;
        public bool active;
        public uint ptr;

        public PrerequisiteParent(string name, bool required, bool active, uint ptr)
        {
            this.name = name;
            this.required = required;
            this.active = active;
            this.ptr = ptr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> required;
            public Field<bool> active;
            public Field<uint> ptr;
        }

        public static void Serialize(PrerequisiteParent v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("required");
            ((Action<bool>)s.SerializeBool)(v.required);
            s.SerializeFieldName("active");
            ((Action<bool>)s.SerializeBool)(v.active);
            s.SerializeFieldName("ptr");
            ((Action<uint>)s.SerializeU32)(v.ptr);
        }

        public static PrerequisiteParent Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                required = new Field<bool>(),
                active = new Field<bool>(),
                ptr = new Field<uint>(),
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
                    case "active":
                        fields.active.Value = d.DeserializeBool();
                        break;
                    case "ptr":
                        fields.ptr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PrerequisiteParent", fieldName);
                }
            }
            return new PrerequisiteParent(

                fields.name.Unwrap("PrerequisiteParent", "name"),

                fields.required.Unwrap("PrerequisiteParent", "required"),

                fields.active.Unwrap("PrerequisiteParent", "active"),

                fields.ptr.Unwrap("PrerequisiteParent", "ptr")

            );
        }
    }
}
