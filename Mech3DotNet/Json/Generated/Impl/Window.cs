using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(WindowConverter))]
    public class Window
    {
        public string name;
        public uint resolutionX;
        public uint resolutionY;
        public uint dataPtr;

        public Window(string name, uint resolutionX, uint resolutionY, uint dataPtr)
        {
            this.name = name;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.dataPtr = dataPtr;
        }
    }
}
