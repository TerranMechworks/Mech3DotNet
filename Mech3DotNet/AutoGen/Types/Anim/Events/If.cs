using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class If
    {
        public Mech3DotNet.Types.Anim.Events.Condition condition;

        public If(Mech3DotNet.Types.Anim.Events.Condition condition)
        {
            this.condition = condition;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<If> Converter = new TypeConverter<If>(Deserialize, Serialize);

        public static void Serialize(If v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("condition");
            s.Serialize(Mech3DotNet.Types.Anim.Events.Condition.Converter)(v.condition);
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Anim.Events.Condition> condition;
        }

        public static If Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("If", fieldName);
                }
            }
            return new If(

                fields.condition.Unwrap("If", "condition")

            );
        }

        #endregion
    }
}
