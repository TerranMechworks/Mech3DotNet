using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Interp
{
    public sealed class Script
    {
        public static readonly TypeConverter<Script> Converter = new TypeConverter<Script>(Deserialize, Serialize);
        public string name;
        public System.DateTime lastModified;
        public System.Collections.Generic.List<string> lines;

        public Script(string name, System.DateTime lastModified, System.Collections.Generic.List<string> lines)
        {
            this.name = name;
            this.lastModified = lastModified;
            this.lines = lines;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<System.DateTime> lastModified;
            public Field<System.Collections.Generic.List<string>> lines;
        }

        public static void Serialize(Script v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("last_modified");
            ((Action<DateTime>)s.SerializeDateTime)(v.lastModified);
            s.SerializeFieldName("lines");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.lines);
        }

        public static Script Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                lastModified = new Field<System.DateTime>(),
                lines = new Field<System.Collections.Generic.List<string>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "last_modified":
                        fields.lastModified.Value = d.DeserializeDateTime();
                        break;
                    case "lines":
                        fields.lines.Value = d.DeserializeVec(d.DeserializeString)();
                        break;
                    default:
                        throw new UnknownFieldException("Script", fieldName);
                }
            }
            return new Script(

                fields.name.Unwrap("Script", "name"),

                fields.lastModified.Unwrap("Script", "lastModified"),

                fields.lines.Unwrap("Script", "lines")

            );
        }
    }
}
