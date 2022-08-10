using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mech3DotNet.Json
{
    public class CycleData
    {
        [JsonProperty("textures", Required = Required.Always)]
        public List<string> textures;
        [JsonProperty("unk00", Required = Required.Always)]
        public bool unk00;
        [JsonProperty("unk04", Required = Required.Always)]
        public uint unk04;
        [JsonProperty("unk12", Required = Required.Always)]
        public float unk12;
        [JsonProperty("info_ptr", Required = Required.Always)]
        public uint infoPtr;
        [JsonProperty("data_ptr", Required = Required.Always)]
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

        [JsonConstructor]
        private CycleData() { }
    }
}
