using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Elseif
    {
        public Mech3DotNet.Types.Anim.Events.Condition condition;

        public Elseif(Mech3DotNet.Types.Anim.Events.Condition condition)
        {
            this.condition = condition;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Elseif> Converter = new TypeConverter<Elseif>(Deserialize, Serialize);

        public static void Serialize(Elseif v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("condition");
            s.Serialize(Mech3DotNet.Types.Anim.Events.Condition.Converter)(v.condition);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.Condition> condition;
        }

        public static Elseif Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                condition = new Field<Mech3DotNet.Types.Anim.Events.Condition>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "condition":
                        fields.condition.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.Condition.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("Elseif", fieldName);
                }
            }
            return new Elseif(

                fields.condition.Unwrap("Elseif", "condition")

            );
        }

        #endregion
    }
}
