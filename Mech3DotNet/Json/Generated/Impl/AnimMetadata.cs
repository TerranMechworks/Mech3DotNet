using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(AnimMetadataConverter))]
    public class AnimMetadata
    {
        public uint basePtr;
        public uint worldPtr;
        public List<AnimName> animNames;
        public List<AnimPtr> animPtrs;

        public AnimMetadata(uint basePtr, uint worldPtr, List<AnimName> animNames, List<AnimPtr> animPtrs)
        {
            this.basePtr = basePtr;
            this.worldPtr = worldPtr;
            this.animNames = animNames;
            this.animPtrs = animPtrs;
        }
    }
}
