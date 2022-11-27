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

        public static void Serialize(Mech3DotNet.Types.Anim.Events.EndIf v, Serializer s)
        {
            s.SerializeStruct("EndIf", 0);
        }

        public static Mech3DotNet.Types.Anim.Events.EndIf Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
            };
            foreach (var fieldName in d.DeserializeStruct("EndIf"))
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
