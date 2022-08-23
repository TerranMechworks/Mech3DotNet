using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CallAnimationConverter))]
    public class CallAnimation
    {
        public string name;
        public ushort? waitForCompletion = null;
        public CallAnimationParameters parameters;

        public CallAnimation(string name, ushort? waitForCompletion, CallAnimationParameters parameters)
        {
            this.name = name;
            this.waitForCompletion = waitForCompletion;
            this.parameters = parameters;
        }
    }
}
