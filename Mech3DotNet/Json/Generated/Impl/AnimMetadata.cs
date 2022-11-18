namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.AnimMetadataConverter))]
    public class AnimMetadata
    {
        public uint basePtr;
        public uint worldPtr;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.AnimName> animNames;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.AnimPtr> animPtrs;

        public AnimMetadata(uint basePtr, uint worldPtr, System.Collections.Generic.List<Mech3DotNet.Json.Anim.AnimName> animNames, System.Collections.Generic.List<Mech3DotNet.Json.Anim.AnimPtr> animPtrs)
        {
            this.basePtr = basePtr;
            this.worldPtr = worldPtr;
            this.animNames = animNames;
            this.animPtrs = animPtrs;
        }
    }
}
