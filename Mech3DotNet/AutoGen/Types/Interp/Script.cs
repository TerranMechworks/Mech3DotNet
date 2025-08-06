using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Interp
{
    public sealed class Script
    {
        public string name;
        public System.DateTime datetime;
        public System.Collections.Generic.List<string> lines;

        public Script(string name, System.DateTime datetime, System.Collections.Generic.List<string> lines)
        {
            this.name = name;
            this.datetime = datetime;
            this.lines = lines;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Script> Converter = new TypeConverter<Script>(Deserialize, Serialize);

        public static void Serialize(Script v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("datetime");
            ((Action<DateTime>)s.SerializeDateTime)(v.datetime);
            s.SerializeFieldName("lines");
            s.SerializeVec(((Action<string>)s.SerializeString))(v.lines);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<System.DateTime> datetime;
            public Field<System.Collections.Generic.List<string>> lines;
        }

        public static Script Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                datetime = new Field<System.DateTime>(),
                lines = new Field<System.Collections.Generic.List<string>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "datetime":
                        fields.datetime.Value = d.DeserializeDateTime();
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

                fields.datetime.Unwrap("Script", "datetime"),

                fields.lines.Unwrap("Script", "lines")

            );
        }

        #endregion
    }
}
