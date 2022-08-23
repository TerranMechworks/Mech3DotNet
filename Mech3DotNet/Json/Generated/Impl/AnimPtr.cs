using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(AnimPtrConverter))]
    public class AnimPtr
    {
        public string fileName;
        public uint animPtr;
        public uint animRootPtr;
        public uint objectsPtr;
        public uint nodesPtr;
        public uint lightsPtr;
        public uint puffersPtr;
        public uint dynamicSoundsPtr;
        public uint staticSoundsPtr;
        public uint activPrereqsPtr;
        public uint animRefsPtr;
        public uint resetStatePtr;
        public uint resetStateEventsPtr;
        public uint seqDefsPtr;

        public AnimPtr(string fileName, uint animPtr, uint animRootPtr, uint objectsPtr, uint nodesPtr, uint lightsPtr, uint puffersPtr, uint dynamicSoundsPtr, uint staticSoundsPtr, uint activPrereqsPtr, uint animRefsPtr, uint resetStatePtr, uint resetStateEventsPtr, uint seqDefsPtr)
        {
            this.fileName = fileName;
            this.animPtr = animPtr;
            this.animRootPtr = animRootPtr;
            this.objectsPtr = objectsPtr;
            this.nodesPtr = nodesPtr;
            this.lightsPtr = lightsPtr;
            this.puffersPtr = puffersPtr;
            this.dynamicSoundsPtr = dynamicSoundsPtr;
            this.staticSoundsPtr = staticSoundsPtr;
            this.activPrereqsPtr = activPrereqsPtr;
            this.animRefsPtr = animRefsPtr;
            this.resetStatePtr = resetStatePtr;
            this.resetStateEventsPtr = resetStateEventsPtr;
            this.seqDefsPtr = seqDefsPtr;
        }
    }
}
