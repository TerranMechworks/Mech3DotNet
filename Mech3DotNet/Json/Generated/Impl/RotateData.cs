using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(RotateDataConverter))]
    public class RotateData
    {
        public Quaternion value;
        public byte[] unk;

        public RotateData(Quaternion value, byte[] unk)
        {
            this.value = value;
            this.unk = unk;
        }
    }
}
