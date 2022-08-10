using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CycleDataConverter))]
    public class CycleData
    {
        public List<string> textures;
        public bool unk00;
        public uint unk04;
        public float unk12;
        public uint infoPtr;
        public uint dataPtr;

        public CycleData(List<string> textures, bool unk00, uint unk04, float unk12, uint infoPtr, uint dataPtr)
        {
            this.textures = textures;
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk12 = unk12;
            this.infoPtr = infoPtr;
            this.dataPtr = dataPtr;
        }
    }
}
