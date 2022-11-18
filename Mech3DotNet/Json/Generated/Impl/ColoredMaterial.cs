using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ColoredMaterialConverter))]
    public class ColoredMaterial
    {
        public Color color;
        public byte alpha;
        public float specular;

        public ColoredMaterial(Color color, byte alpha, float specular)
        {
            this.color = color;
            this.alpha = alpha;
            this.specular = specular;
        }
    }
}
