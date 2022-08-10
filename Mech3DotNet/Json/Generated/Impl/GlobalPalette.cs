using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(GlobalPaletteConverter))]
    public class GlobalPalette
    {
        public int index;
        public ushort count;

        public GlobalPalette(int index, ushort count)
        {
            this.index = index;
            this.count = count;
        }
    }
}
