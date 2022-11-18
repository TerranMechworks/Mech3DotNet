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
        public float specular;
        public bool flag;

        public TexturedMaterial(string texture, uint pointer, CycleData? cycle, float specular, bool flag)
        {
            this.texture = texture;
            this.pointer = pointer;
            this.cycle = cycle;
            this.specular = specular;
            this.flag = flag;
        }
    }
}
