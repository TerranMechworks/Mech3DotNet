using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Mech3DotNet.Json
{
    public class Light<V3>
    {
        [JsonProperty("unk00", Required = Required.Always)]
        public uint unk00;
        [JsonProperty("unk04", Required = Required.Always)]
        public uint unk04;
        [JsonProperty("unk08", Required = Required.Always)]
        public uint unk08;
        [JsonProperty("extra", Required = Required.Always)]
        public List<V3> extra;
        [JsonProperty("unk16", Required = Required.Always)]
        public uint unk16;
        [JsonProperty("unk20", Required = Required.Always)]
        public uint unk20;
        [JsonProperty("unk24", Required = Required.Always)]
        public uint unk24;
        [JsonProperty("unk28", Required = Required.Always)]
        public float unk28;
        [JsonProperty("unk32", Required = Required.Always)]
        public float unk32;
        [JsonProperty("unk36", Required = Required.Always)]
        public float unk36;
        [JsonProperty("unk40", Required = Required.Always)]
        public float unk40;
        [JsonProperty("ptr", Required = Required.Always)]
        public uint ptr;
        [JsonProperty("unk48", Required = Required.Always)]
        public float unk48;
        [JsonProperty("unk52", Required = Required.Always)]
        public float unk52;
        [JsonProperty("unk56", Required = Required.Always)]
        public float unk56;
        [JsonProperty("unk60", Required = Required.Always)]
        public float unk60;
        [JsonProperty("unk64", Required = Required.Always)]
        public float unk64;
        [JsonProperty("unk68", Required = Required.Always)]
        public float unk68;
        [JsonProperty("unk72", Required = Required.Always)]
        public float unk72;

        public Light(uint unk00, uint unk04, uint unk08, List<V3> extra, uint unk16, uint unk20, uint unk24, float unk28, float unk32, float unk36, float unk40, uint ptr, float unk48, float unk52, float unk56, float unk60, float unk64, float unk68, float unk72)
        {
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk08 = unk08;
            this.extra = extra ?? throw new ArgumentNullException(nameof(extra));
            this.unk16 = unk16;
            this.unk20 = unk20;
            this.unk24 = unk24;
            this.unk28 = unk28;
            this.unk32 = unk32;
            this.unk36 = unk36;
            this.unk40 = unk40;
            this.ptr = ptr;
            this.unk48 = unk48;
            this.unk52 = unk52;
            this.unk56 = unk56;
            this.unk60 = unk60;
            this.unk64 = unk64;
            this.unk68 = unk68;
            this.unk72 = unk72;
        }

        [JsonConstructor]
        private Light() { }
    }
}
