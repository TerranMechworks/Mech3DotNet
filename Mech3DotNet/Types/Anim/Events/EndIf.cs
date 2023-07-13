using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class EndIf
    {
        public static readonly TypeConverter<EndIf> Converter = new TypeConverter<EndIf>(Deserialize, Serialize);

        public EndIf()
        {
        }

        private struct Fields
        {
        }

        public static void Serialize(EndIf v, Serializer s)
        {
            s.SerializeStruct(0);
        }

        public static EndIf Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    default:
                        throw new UnknownFieldException("EndIf", fieldName);
                }
            }
            return new EndIf(

            );
        }
    }
}
