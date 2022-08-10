using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(MeshLightConverter))]
    public class MeshLight
    {
        public uint unk00;
        public uint unk04;
        public uint unk08;
        public List<Vec3> extra;
        public uint unk16;
        public uint unk20;
        public uint unk24;
        public float unk28;
        public float unk32;
        public float unk36;
        public float unk40;
        public uint ptr;
        public float unk48;
        public float unk52;
        public float unk56;
        public float unk60;
        public float unk64;
        public float unk68;
        public float unk72;

        public MeshLight(uint unk00, uint unk04, uint unk08, List<Vec3> extra, uint unk16, uint unk20, uint unk24, float unk28, float unk32, float unk36, float unk40, uint ptr, float unk48, float unk52, float unk56, float unk60, float unk64, float unk68, float unk72)
        {
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk08 = unk08;
            this.extra = extra;
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
    }
}
