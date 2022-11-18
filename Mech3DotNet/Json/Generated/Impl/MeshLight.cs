namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.MeshLightConverter))]
    public class MeshLight
    {
        public uint unk00;
        public uint unk04;
        public float unk08;
        public System.Collections.Generic.List<Vec3> extra;
        public uint unk24;
        public Color color;
        public ushort flags;
        public uint ptr;
        public float unk48;
        public float unk52;
        public float unk56;
        public uint unk60;
        public float unk64;
        public float unk68;
        public float unk72;

        public MeshLight(uint unk00, uint unk04, float unk08, System.Collections.Generic.List<Vec3> extra, uint unk24, Color color, ushort flags, uint ptr, float unk48, float unk52, float unk56, uint unk60, float unk64, float unk68, float unk72)
        {
            this.unk00 = unk00;
            this.unk04 = unk04;
            this.unk08 = unk08;
            this.extra = extra;
            this.unk24 = unk24;
            this.color = color;
            this.flags = flags;
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
