using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(TranslateDataConverter))]
    public class TranslateData
    {
        public Vec3 value;
        public byte[] unk;

        public TranslateData(Vec3 value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
