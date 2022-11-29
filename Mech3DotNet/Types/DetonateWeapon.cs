using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class DetonateWeapon
    {
        public static readonly TypeConverter<DetonateWeapon> Converter = new TypeConverter<DetonateWeapon>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.Events.AtNode atNode;

        public DetonateWeapon(string name, Mech3DotNet.Types.Anim.Events.AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.Events.AtNode> atNode;
        }

        public static void Serialize(DetonateWeapon v, Serializer s)
        {
            s.SerializeStruct("DetonateWeapon", 2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("at_node");
            s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)(v.atNode);
        }

        public static DetonateWeapon Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode>(),
            };
            foreach (var fieldName in d.DeserializeStruct("DetonateWeapon"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("DetonateWeapon", fieldName);
                }
            }
            return new DetonateWeapon(

                fields.name.Unwrap("DetonateWeapon", "name"),

                fields.atNode.Unwrap("DetonateWeapon", "atNode")

            );
        }
    }
}
