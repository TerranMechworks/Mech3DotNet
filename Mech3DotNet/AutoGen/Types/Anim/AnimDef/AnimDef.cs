using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.AnimDef
{
    public sealed class AnimDef
    {
        public static readonly TypeConverter<AnimDef> Converter = new TypeConverter<AnimDef>(Deserialize, Serialize);
        public string name;
        public string animName;
        public string animRootName;
        public bool hasCallbacks;
        public bool autoResetNodeStates;
        public bool localNodesOnly;
        public bool proximityDamage;
        public bool active = true;
        public bool lowPriority = false;
        public Mech3DotNet.Types.Anim.AnimDef.AnimActivation activation;
        public Mech3DotNet.Types.Anim.AnimDef.Execution execution;
        public bool? networkLog = null;
        public bool? saveLog = null;
        public float? resetTime = null;
        public float health;
        public byte activPrereqMinToSatisfy;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.ObjectRef>? objects = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.NodeRef>? nodes = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.LightRef>? lights = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.PufferRef>? puffers = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.DynamicSoundRef>? dynamicSounds = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.StaticSoundRef>? staticSounds = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.EffectRef>? effects = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq.ActivationPrerequisite>? activPrereqs = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.AnimRef>? animRefs = null;
        public Mech3DotNet.Types.Anim.AnimDef.ResetState? resetState;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.SeqDef> sequences;
        public Mech3DotNet.Types.Anim.AnimDef.AnimDefPtrs? ptrs = null;

        public AnimDef(string name, string animName, string animRootName, bool hasCallbacks, bool autoResetNodeStates, bool localNodesOnly, bool proximityDamage, bool active, bool lowPriority, Mech3DotNet.Types.Anim.AnimDef.AnimActivation activation, Mech3DotNet.Types.Anim.AnimDef.Execution execution, bool? networkLog, bool? saveLog, float? resetTime, float health, byte activPrereqMinToSatisfy, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.ObjectRef>? objects, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.NodeRef>? nodes, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.LightRef>? lights, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.PufferRef>? puffers, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.DynamicSoundRef>? dynamicSounds, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.StaticSoundRef>? staticSounds, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.EffectRef>? effects, System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq.ActivationPrerequisite>? activPrereqs, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.AnimRef>? animRefs, Mech3DotNet.Types.Anim.AnimDef.ResetState? resetState, System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.SeqDef> sequences, Mech3DotNet.Types.Anim.AnimDef.AnimDefPtrs? ptrs)
        {
            this.name = name;
            this.animName = animName;
            this.animRootName = animRootName;
            this.hasCallbacks = hasCallbacks;
            this.autoResetNodeStates = autoResetNodeStates;
            this.localNodesOnly = localNodesOnly;
            this.proximityDamage = proximityDamage;
            this.active = active;
            this.lowPriority = lowPriority;
            this.activation = activation;
            this.execution = execution;
            this.networkLog = networkLog;
            this.saveLog = saveLog;
            this.resetTime = resetTime;
            this.health = health;
            this.activPrereqMinToSatisfy = activPrereqMinToSatisfy;
            this.objects = objects;
            this.nodes = nodes;
            this.lights = lights;
            this.puffers = puffers;
            this.dynamicSounds = dynamicSounds;
            this.staticSounds = staticSounds;
            this.effects = effects;
            this.activPrereqs = activPrereqs;
            this.animRefs = animRefs;
            this.resetState = resetState;
            this.sequences = sequences;
            this.ptrs = ptrs;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<string> animName;
            public Field<string> animRootName;
            public Field<bool> hasCallbacks;
            public Field<bool> autoResetNodeStates;
            public Field<bool> localNodesOnly;
            public Field<bool> proximityDamage;
            public Field<bool> active;
            public Field<bool> lowPriority;
            public Field<Mech3DotNet.Types.Anim.AnimDef.AnimActivation> activation;
            public Field<Mech3DotNet.Types.Anim.AnimDef.Execution> execution;
            public Field<bool?> networkLog;
            public Field<bool?> saveLog;
            public Field<float?> resetTime;
            public Field<float> health;
            public Field<byte> activPrereqMinToSatisfy;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.ObjectRef>?> objects;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.NodeRef>?> nodes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.LightRef>?> lights;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.PufferRef>?> puffers;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.DynamicSoundRef>?> dynamicSounds;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.StaticSoundRef>?> staticSounds;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.EffectRef>?> effects;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq.ActivationPrerequisite>?> activPrereqs;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.AnimRef>?> animRefs;
            public Field<Mech3DotNet.Types.Anim.AnimDef.ResetState?> resetState;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.SeqDef>> sequences;
            public Field<Mech3DotNet.Types.Anim.AnimDef.AnimDefPtrs?> ptrs;
        }

        public static void Serialize(AnimDef v, Serializer s)
        {
            s.SerializeStruct(28);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("anim_name");
            ((Action<string>)s.SerializeString)(v.animName);
            s.SerializeFieldName("anim_root_name");
            ((Action<string>)s.SerializeString)(v.animRootName);
            s.SerializeFieldName("has_callbacks");
            ((Action<bool>)s.SerializeBool)(v.hasCallbacks);
            s.SerializeFieldName("auto_reset_node_states");
            ((Action<bool>)s.SerializeBool)(v.autoResetNodeStates);
            s.SerializeFieldName("local_nodes_only");
            ((Action<bool>)s.SerializeBool)(v.localNodesOnly);
            s.SerializeFieldName("proximity_damage");
            ((Action<bool>)s.SerializeBool)(v.proximityDamage);
            s.SerializeFieldName("active");
            ((Action<bool>)s.SerializeBool)(v.active);
            s.SerializeFieldName("low_priority");
            ((Action<bool>)s.SerializeBool)(v.lowPriority);
            s.SerializeFieldName("activation");
            s.Serialize(Mech3DotNet.Types.Anim.AnimDef.AnimActivationConverter.Converter)(v.activation);
            s.SerializeFieldName("execution");
            s.Serialize(Mech3DotNet.Types.Anim.AnimDef.Execution.Converter)(v.execution);
            s.SerializeFieldName("network_log");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.networkLog);
            s.SerializeFieldName("save_log");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.saveLog);
            s.SerializeFieldName("reset_time");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.resetTime);
            s.SerializeFieldName("health");
            ((Action<float>)s.SerializeF32)(v.health);
            s.SerializeFieldName("activ_prereq_min_to_satisfy");
            ((Action<byte>)s.SerializeU8)(v.activPrereqMinToSatisfy);
            s.SerializeFieldName("objects");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.ObjectRef.Converter)))(v.objects);
            s.SerializeFieldName("nodes");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.NodeRef.Converter)))(v.nodes);
            s.SerializeFieldName("lights");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.LightRef.Converter)))(v.lights);
            s.SerializeFieldName("puffers");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.PufferRef.Converter)))(v.puffers);
            s.SerializeFieldName("dynamic_sounds");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.DynamicSoundRef.Converter)))(v.dynamicSounds);
            s.SerializeFieldName("static_sounds");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.StaticSoundRef.Converter)))(v.staticSounds);
            s.SerializeFieldName("effects");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.EffectRef.Converter)))(v.effects);
            s.SerializeFieldName("activ_prereqs");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.ActivationPrereq.ActivationPrerequisite.Converter)))(v.activPrereqs);
            s.SerializeFieldName("anim_refs");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Support.AnimRef.Converter)))(v.animRefs);
            s.SerializeFieldName("reset_state");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.AnimDef.ResetState.Converter))(v.resetState);
            s.SerializeFieldName("sequences");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.AnimDef.SeqDef.Converter))(v.sequences);
            s.SerializeFieldName("ptrs");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.AnimDef.AnimDefPtrs.Converter))(v.ptrs);
        }

        public static AnimDef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                animName = new Field<string>(),
                animRootName = new Field<string>(),
                hasCallbacks = new Field<bool>(),
                autoResetNodeStates = new Field<bool>(),
                localNodesOnly = new Field<bool>(),
                proximityDamage = new Field<bool>(),
                active = new Field<bool>(true),
                lowPriority = new Field<bool>(false),
                activation = new Field<Mech3DotNet.Types.Anim.AnimDef.AnimActivation>(),
                execution = new Field<Mech3DotNet.Types.Anim.AnimDef.Execution>(),
                networkLog = new Field<bool?>(null),
                saveLog = new Field<bool?>(null),
                resetTime = new Field<float?>(null),
                health = new Field<float>(),
                activPrereqMinToSatisfy = new Field<byte>(),
                objects = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.ObjectRef>?>(null),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.NodeRef>?>(null),
                lights = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.LightRef>?>(null),
                puffers = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.PufferRef>?>(null),
                dynamicSounds = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.DynamicSoundRef>?>(null),
                staticSounds = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.StaticSoundRef>?>(null),
                effects = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.EffectRef>?>(null),
                activPrereqs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq.ActivationPrerequisite>?>(null),
                animRefs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Support.AnimRef>?>(null),
                resetState = new Field<Mech3DotNet.Types.Anim.AnimDef.ResetState?>(),
                sequences = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.AnimDef.SeqDef>>(),
                ptrs = new Field<Mech3DotNet.Types.Anim.AnimDef.AnimDefPtrs?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "anim_name":
                        fields.animName.Value = d.DeserializeString();
                        break;
                    case "anim_root_name":
                        fields.animRootName.Value = d.DeserializeString();
                        break;
                    case "has_callbacks":
                        fields.hasCallbacks.Value = d.DeserializeBool();
                        break;
                    case "auto_reset_node_states":
                        fields.autoResetNodeStates.Value = d.DeserializeBool();
                        break;
                    case "local_nodes_only":
                        fields.localNodesOnly.Value = d.DeserializeBool();
                        break;
                    case "proximity_damage":
                        fields.proximityDamage.Value = d.DeserializeBool();
                        break;
                    case "active":
                        fields.active.Value = d.DeserializeBool();
                        break;
                    case "low_priority":
                        fields.lowPriority.Value = d.DeserializeBool();
                        break;
                    case "activation":
                        fields.activation.Value = d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.AnimActivationConverter.Converter)();
                        break;
                    case "execution":
                        fields.execution.Value = d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.Execution.Converter)();
                        break;
                    case "network_log":
                        fields.networkLog.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "save_log":
                        fields.saveLog.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "reset_time":
                        fields.resetTime.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "health":
                        fields.health.Value = d.DeserializeF32();
                        break;
                    case "activ_prereq_min_to_satisfy":
                        fields.activPrereqMinToSatisfy.Value = d.DeserializeU8();
                        break;
                    case "objects":
                        fields.objects.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.ObjectRef.Converter)))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.NodeRef.Converter)))();
                        break;
                    case "lights":
                        fields.lights.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.LightRef.Converter)))();
                        break;
                    case "puffers":
                        fields.puffers.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.PufferRef.Converter)))();
                        break;
                    case "dynamic_sounds":
                        fields.dynamicSounds.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.DynamicSoundRef.Converter)))();
                        break;
                    case "static_sounds":
                        fields.staticSounds.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.StaticSoundRef.Converter)))();
                        break;
                    case "effects":
                        fields.effects.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.EffectRef.Converter)))();
                        break;
                    case "activ_prereqs":
                        fields.activPrereqs.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.ActivationPrereq.ActivationPrerequisite.Converter)))();
                        break;
                    case "anim_refs":
                        fields.animRefs.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Support.AnimRef.Converter)))();
                        break;
                    case "reset_state":
                        fields.resetState.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.ResetState.Converter))();
                        break;
                    case "sequences":
                        fields.sequences.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.SeqDef.Converter))();
                        break;
                    case "ptrs":
                        fields.ptrs.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.AnimDef.AnimDefPtrs.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("AnimDef", fieldName);
                }
            }
            return new AnimDef(

                fields.name.Unwrap("AnimDef", "name"),

                fields.animName.Unwrap("AnimDef", "animName"),

                fields.animRootName.Unwrap("AnimDef", "animRootName"),

                fields.hasCallbacks.Unwrap("AnimDef", "hasCallbacks"),

                fields.autoResetNodeStates.Unwrap("AnimDef", "autoResetNodeStates"),

                fields.localNodesOnly.Unwrap("AnimDef", "localNodesOnly"),

                fields.proximityDamage.Unwrap("AnimDef", "proximityDamage"),

                fields.active.Unwrap("AnimDef", "active"),

                fields.lowPriority.Unwrap("AnimDef", "lowPriority"),

                fields.activation.Unwrap("AnimDef", "activation"),

                fields.execution.Unwrap("AnimDef", "execution"),

                fields.networkLog.Unwrap("AnimDef", "networkLog"),

                fields.saveLog.Unwrap("AnimDef", "saveLog"),

                fields.resetTime.Unwrap("AnimDef", "resetTime"),

                fields.health.Unwrap("AnimDef", "health"),

                fields.activPrereqMinToSatisfy.Unwrap("AnimDef", "activPrereqMinToSatisfy"),

                fields.objects.Unwrap("AnimDef", "objects"),

                fields.nodes.Unwrap("AnimDef", "nodes"),

                fields.lights.Unwrap("AnimDef", "lights"),

                fields.puffers.Unwrap("AnimDef", "puffers"),

                fields.dynamicSounds.Unwrap("AnimDef", "dynamicSounds"),

                fields.staticSounds.Unwrap("AnimDef", "staticSounds"),

                fields.effects.Unwrap("AnimDef", "effects"),

                fields.activPrereqs.Unwrap("AnimDef", "activPrereqs"),

                fields.animRefs.Unwrap("AnimDef", "animRefs"),

                fields.resetState.Unwrap("AnimDef", "resetState"),

                fields.sequences.Unwrap("AnimDef", "sequences"),

                fields.ptrs.Unwrap("AnimDef", "ptrs")

            );
        }
    }
}
