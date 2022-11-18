namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.DetonateWeaponConverter))]
    public class DetonateWeapon
    {
        public string name;
        public AtNode atNode;

        public DetonateWeapon(string name, AtNode atNode)
        {
            this.name = name;
            this.atNode = atNode;
        }
    }
}
