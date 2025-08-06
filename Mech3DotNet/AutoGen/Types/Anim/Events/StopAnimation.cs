using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class StopAnimation
    {
        public string name;

        public StopAnimation(string name)
        {
            this.name = name;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<StopAnimation> Converter = new TypeConverter<StopAnimation>(Deserialize, Serialize);

        public static void Serialize(StopAnimation v, Serializer s)
        {
            s.SerializeStruct(1);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
        }

        private struct Fields
        {
            public Field<string> name;
        }

        public static StopAnimation Deserialize(Deserializer d)
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
                        throw new UnknownFieldException("StopAnimation", fieldName);
                }
            }
            return new StopAnimation(

                fields.name.Unwrap("StopAnimation", "name")

            );
        }

        #endregion
    }
}
