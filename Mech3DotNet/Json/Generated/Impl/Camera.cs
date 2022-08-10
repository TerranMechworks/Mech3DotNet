using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(CameraConverter))]
    public class Camera
    {
        public string name;
        public Range clip;
        public Range fov;
        public uint dataPtr;

        public Camera(string name, Range clip, Range fov, uint dataPtr)
        {
            this.name = name;
            this.clip = clip;
            this.fov = fov;
            this.dataPtr = dataPtr;
        }
    }
}
