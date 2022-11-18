namespace Mech3DotNet.Json
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Converters.AnimMetadataConverter))]
    public class AnimMetadata
    {
        public uint basePtr;
        public uint worldPtr;
        public System.Collections.Generic.List<AnimName> animNames;
        public System.Collections.Generic.List<AnimPtr> animPtrs;

        public AnimMetadata(uint basePtr, uint worldPtr, System.Collections.Generic.List<AnimName> animNames, System.Collections.Generic.List<AnimPtr> animPtrs)
        {
            this.basePtr = basePtr;
            this.worldPtr = worldPtr;
            this.animNames = animNames;
            this.animPtrs = animPtrs;
        }
    }
}
