using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(DetonateWeaponConverter))]
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
