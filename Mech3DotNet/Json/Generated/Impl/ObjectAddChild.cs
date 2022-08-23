using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(ObjectAddChildConverter))]
    public class ObjectAddChild
    {
        public string parent;
        public string child;

        public ObjectAddChild(string parent, string child)
        {
            this.parent = parent;
            this.child = child;
        }
    }
}
