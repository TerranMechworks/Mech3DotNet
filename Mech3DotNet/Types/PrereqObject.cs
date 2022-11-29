using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public struct PrereqObject
    {
        public string name;
        public bool required;
        public bool active;
        public uint pointer;

        public PrereqObject(string name, bool required, bool active, uint pointer)
        {
            this.name = name;
            this.required = required;
            this.active = active;
            this.pointer = pointer;
        }
    }

    public static class PrereqObjectConverter
    {
        public static readonly TypeConverter<PrereqObject> Converter = new TypeConverter<PrereqObject>(Deserialize, Serialize);

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> required;
            public Field<bool> active;
            public Field<uint> pointer;
        }

        public static void Serialize(PrereqObject v, Serializer s)
        {
            s.SerializeStruct("PrereqObject", 4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("required");
            ((Action<bool>)s.SerializeBool)(v.required);
            s.SerializeFieldName("active");
            ((Action<bool>)s.SerializeBool)(v.active);
            s.SerializeFieldName("pointer");
            ((Action<uint>)s.SerializeU32)(v.pointer);
        }

        public static PrereqObject Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                required = new Field<bool>(),
                active = new Field<bool>(),
                pointer = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("PrereqObject"))
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
                    case "pointer":
                        fields.pointer.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("PrereqObject", fieldName);
                }
            }
            return new PrereqObject(

                fields.name.Unwrap("PrereqObject", "name"),

                fields.required.Unwrap("PrereqObject", "required"),

                fields.active.Unwrap("PrereqObject", "active"),

                fields.pointer.Unwrap("PrereqObject", "pointer")

            );
        }
    }
}
