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
        public byte unk00;
        public uint unk32;

        public ColoredMaterial(Color color, byte unk00, uint unk32)
        {
            this.color = color;
            this.unk00 = unk00;
            this.unk32 = unk32;
        }
    }
}
