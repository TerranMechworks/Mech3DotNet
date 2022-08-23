using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PufferStateCycleTexturesConverter))]
    public class PufferStateCycleTextures
    {
        public string? texture1;
        public string? texture2;
        public string? texture3;
        public string? texture4;
        public string? texture5;
        public string? texture6;

        public PufferStateCycleTextures(string? texture1, string? texture2, string? texture3, string? texture4, string? texture5, string? texture6)
        {
            this.texture1 = texture1;
            this.texture2 = texture2;
            this.texture3 = texture3;
            this.texture4 = texture4;
            this.texture5 = texture5;
            this.texture6 = texture6;
        }
    }
}
