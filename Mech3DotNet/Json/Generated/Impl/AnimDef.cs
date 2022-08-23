using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(AnimDefConverter))]
    public class AnimDef
    {
        public string name;
        public NamePad animName;
        public NamePad animRoot;
        public string fileName;
        public bool autoResetNodeStates;
        public AnimActivation activation;
        public Execution execution;
        public bool? networkLog = null;
        public bool? saveLog = null;
        public bool hasCallbacks;
        public float? resetTime = null;
        public float health;
        public bool proximityDamage;
        public byte activPrereqMinToSatisfy;
        public List<NamePad>? objects = null;
        public List<NamePtr>? nodes = null;
        public List<NamePtr>? lights = null;
        public List<NamePtrFlags>? puffers = null;
        public List<NamePtr>? dynamicSounds = null;
        public List<NamePad>? staticSounds = null;
        public List<ActivationPrereq>? activPrereqs = null;
        public List<NamePad>? animRefs = null;
        public SeqDef? resetSequence;
        public List<SeqDef> sequences;

        public AnimDef(string name, NamePad animName, NamePad animRoot, string fileName, bool autoResetNodeStates, AnimActivation activation, Execution execution, bool? networkLog, bool? saveLog, bool hasCallbacks, float? resetTime, float health, bool proximityDamage, byte activPrereqMinToSatisfy, List<NamePad>? objects, List<NamePtr>? nodes, List<NamePtr>? lights, List<NamePtrFlags>? puffers, List<NamePtr>? dynamicSounds, List<NamePad>? staticSounds, List<ActivationPrereq>? activPrereqs, List<NamePad>? animRefs, SeqDef? resetSequence, List<SeqDef> sequences)
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
            this.resetSequence = resetSequence;
            this.sequences = sequences;
        }
    }
}
