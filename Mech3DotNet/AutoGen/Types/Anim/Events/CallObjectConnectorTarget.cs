using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallObjectConnectorTarget
    {
        public string name;
        public bool pos;

        public CallObjectConnectorTarget(string name, bool pos)
        {
            this.name = name;
            this.pos = pos;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<CallObjectConnectorTarget> Converter = new TypeConverter<CallObjectConnectorTarget>(Deserialize, Serialize);

        public static void Serialize(CallObjectConnectorTarget v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pos");
            ((Action<bool>)s.SerializeBool)(v.pos);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> pos;
        }

        public static CallObjectConnectorTarget Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pos = new Field<bool>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "pos":
                        fields.pos.Value = d.DeserializeBool();
                        break;
                    default:
                        throw new UnknownFieldException("CallObjectConnectorTarget", fieldName);
                }
            }
            return new CallObjectConnectorTarget(

                fields.name.Unwrap("CallObjectConnectorTarget", "name"),

                fields.pos.Unwrap("CallObjectConnectorTarget", "pos")

            );
        }

        #endregion
    }
}
