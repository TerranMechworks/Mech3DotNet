using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(DisplayConverter))]
    public class Display
    {
        public string name;
        public uint resolutionX;
        public uint resolutionY;
        public Color clearColor;
        public uint dataPtr;

        public Display(string name, uint resolutionX, uint resolutionY, Color clearColor, uint dataPtr)
        {
            this.name = name;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.clearColor = clearColor;
            this.dataPtr = dataPtr;
        }
    }
}
