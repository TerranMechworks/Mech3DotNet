using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TexturedMaterialConverter))]
    public class TexturedMaterial
    {
        public string texture;
        public uint pointer = 0;
        public CycleData? cycle = null;
        public uint unk32;
        public bool flag;

        public TexturedMaterial(string texture, uint pointer, CycleData? cycle, uint unk32, bool flag)
        {
            this.texture = texture;
            this.pointer = pointer;
            this.cycle = cycle;
            this.unk32 = unk32;
            this.flag = flag;
        }
    }
}
