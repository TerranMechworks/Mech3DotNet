namespace Mech3DotNet.Json.Anim
{
    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Converters.AnimDefConverter))]
    public class AnimDef
    {
        public string name;
        public Mech3DotNet.Json.Anim.NamePad animName;
        public Mech3DotNet.Json.Anim.NamePad animRoot;
        public string fileName;
        public bool autoResetNodeStates;
        public Mech3DotNet.Json.Anim.AnimActivation activation;
        public Mech3DotNet.Json.Anim.Execution execution;
        public bool? networkLog = null;
        public bool? saveLog = null;
        public bool hasCallbacks;
        public float? resetTime = null;
        public float health;
        public bool proximityDamage;
        public byte activPrereqMinToSatisfy;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePad>? objects = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtr>? nodes = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtr>? lights = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtrFlags>? puffers = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtr>? dynamicSounds = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePad>? staticSounds = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.ActivationPrereq>? activPrereqs = null;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePad>? animRefs = null;
        public Mech3DotNet.Json.Anim.ResetState? resetState;
        public System.Collections.Generic.List<Mech3DotNet.Json.Anim.SeqDef> sequences;

        public AnimDef(string name, Mech3DotNet.Json.Anim.NamePad animName, Mech3DotNet.Json.Anim.NamePad animRoot, string fileName, bool autoResetNodeStates, Mech3DotNet.Json.Anim.AnimActivation activation, Mech3DotNet.Json.Anim.Execution execution, bool? networkLog, bool? saveLog, bool hasCallbacks, float? resetTime, float health, bool proximityDamage, byte activPrereqMinToSatisfy, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePad>? objects, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtr>? nodes, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtr>? lights, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtrFlags>? puffers, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePtr>? dynamicSounds, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePad>? staticSounds, System.Collections.Generic.List<Mech3DotNet.Json.Anim.ActivationPrereq>? activPrereqs, System.Collections.Generic.List<Mech3DotNet.Json.Anim.NamePad>? animRefs, Mech3DotNet.Json.Anim.ResetState? resetState, System.Collections.Generic.List<Mech3DotNet.Json.Anim.SeqDef> sequences)
        {
            this.name = name;
            this.animName = animName;
            this.animRoot = animRoot;
            this.fileName = fileName;
            this.autoResetNodeStates = autoResetNodeStates;
            this.activation = activation;
            this.execution = execution;
            this.networkLog = networkLog;
            this.saveLog = saveLog;
            this.hasCallbacks = hasCallbacks;
            this.resetTime = resetTime;
            this.health = health;
            this.proximityDamage = proximityDamage;
            this.activPrereqMinToSatisfy = activPrereqMinToSatisfy;
            this.objects = objects;
            this.nodes = nodes;
            this.lights = lights;
            this.puffers = puffers;
            this.dynamicSounds = dynamicSounds;
            this.staticSounds = staticSounds;
            this.activPrereqs = activPrereqs;
            this.animRefs = animRefs;
            this.resetState = resetState;
            this.sequences = sequences;
        }
    }
}
