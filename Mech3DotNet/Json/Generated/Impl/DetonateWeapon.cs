namespace Mech3DotNet.Json.Anim.Events
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.DetonateWeaponConverter))]
    public class DetonateWeapon
    {
        public string name;
        public Mech3DotNet.Json.Anim.Events.AtNode atNode;

        public DetonateWeapon(string name, Mech3DotNet.Json.Anim.Events.AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }
    }
}
