using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(BounceSequenceConverter))]
    public class BounceSequence
    {
        public string? seqName0;
        public string? seqName1;
        public string? seqName2;

        public BounceSequence(string? seqName0, string? seqName1, string? seqName2)
        {
            this.seqName0 = seqName0;
            this.seqName1 = seqName1;
            this.seqName2 = seqName2;
        }
    }
}
