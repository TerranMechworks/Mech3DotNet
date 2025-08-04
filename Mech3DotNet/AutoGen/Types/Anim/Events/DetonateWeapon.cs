using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class DetonateWeapon
    {
        public static readonly TypeConverter<DetonateWeapon> Converter = new TypeConverter<DetonateWeapon>(Deserialize, Serialize);
        public string weapon;
        public Mech3DotNet.Types.Anim.Events.AtNode atNode;

        public DetonateWeapon(string weapon, Mech3DotNet.Types.Anim.Events.AtNode atNode)
        {
            this.weapon = weapon;
            this.atNode = atNode;
        }

        private struct Fields
        {
            public Field<string> weapon;
            public Field<Mech3DotNet.Types.Anim.Events.AtNode> atNode;
        }

        public static void Serialize(DetonateWeapon v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("weapon");
            ((Action<string>)s.SerializeString)(v.weapon);
            s.SerializeFieldName("at_node");
            s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)(v.atNode);
        }

        public static DetonateWeapon Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                weapon = new Field<string>(),
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "weapon":
                        fields.weapon.Value = d.DeserializeString();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("DetonateWeapon", fieldName);
                }
            }
            return new DetonateWeapon(

                fields.weapon.Unwrap("DetonateWeapon", "weapon"),

                fields.atNode.Unwrap("DetonateWeapon", "atNode")

            );
        }
    }
}
