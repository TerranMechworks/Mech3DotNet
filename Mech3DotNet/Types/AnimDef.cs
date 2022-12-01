using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public sealed class AnimDef
    {
        public static readonly TypeConverter<AnimDef> Converter = new TypeConverter<AnimDef>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.NamePad animName;
        public Mech3DotNet.Types.Anim.NamePad animRoot;
        public string fileName;
        public bool autoResetNodeStates;
        public Mech3DotNet.Types.Anim.AnimActivation activation;
        public Mech3DotNet.Types.Anim.Execution execution;
        public bool? networkLog = null;
        public bool? saveLog = null;
        public bool hasCallbacks;
        public float? resetTime = null;
        public float health;
        public bool proximityDamage;
        public byte activPrereqMinToSatisfy;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>? objects = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>? nodes = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>? lights = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtrFlags>? puffers = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>? dynamicSounds = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>? staticSounds = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq>? activPrereqs = null;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>? animRefs = null;
        public Mech3DotNet.Types.Anim.ResetState? resetState;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.SeqDef> sequences;

        public AnimDef(string name, Mech3DotNet.Types.Anim.NamePad animName, Mech3DotNet.Types.Anim.NamePad animRoot, string fileName, bool autoResetNodeStates, Mech3DotNet.Types.Anim.AnimActivation activation, Mech3DotNet.Types.Anim.Execution execution, bool? networkLog, bool? saveLog, bool hasCallbacks, float? resetTime, float health, bool proximityDamage, byte activPrereqMinToSatisfy, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>? objects, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>? nodes, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>? lights, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtrFlags>? puffers, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>? dynamicSounds, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>? staticSounds, System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq>? activPrereqs, System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>? animRefs, Mech3DotNet.Types.Anim.ResetState? resetState, System.Collections.Generic.List<Mech3DotNet.Types.Anim.SeqDef> sequences)
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

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.NamePad> animName;
            public Field<Mech3DotNet.Types.Anim.NamePad> animRoot;
            public Field<string> fileName;
            public Field<bool> autoResetNodeStates;
            public Field<Mech3DotNet.Types.Anim.AnimActivation> activation;
            public Field<Mech3DotNet.Types.Anim.Execution> execution;
            public Field<bool?> networkLog;
            public Field<bool?> saveLog;
            public Field<bool> hasCallbacks;
            public Field<float?> resetTime;
            public Field<float> health;
            public Field<bool> proximityDamage;
            public Field<byte> activPrereqMinToSatisfy;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>?> objects;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>?> nodes;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>?> lights;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtrFlags>?> puffers;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>?> dynamicSounds;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>?> staticSounds;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq>?> activPrereqs;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>?> animRefs;
            public Field<Mech3DotNet.Types.Anim.ResetState?> resetState;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.SeqDef>> sequences;
        }

        public static void Serialize(AnimDef v, Serializer s)
        {
            s.SerializeStruct(24);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("anim_name");
            s.Serialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)(v.animName);
            s.SerializeFieldName("anim_root");
            s.Serialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)(v.animRoot);
            s.SerializeFieldName("file_name");
            ((Action<string>)s.SerializeString)(v.fileName);
            s.SerializeFieldName("auto_reset_node_states");
            ((Action<bool>)s.SerializeBool)(v.autoResetNodeStates);
            s.SerializeFieldName("activation");
            s.Serialize(Mech3DotNet.Types.Anim.AnimActivationConverter.Converter)(v.activation);
            s.SerializeFieldName("execution");
            s.Serialize(Mech3DotNet.Types.Anim.Execution.Converter)(v.execution);
            s.SerializeFieldName("network_log");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.networkLog);
            s.SerializeFieldName("save_log");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.saveLog);
            s.SerializeFieldName("has_callbacks");
            ((Action<bool>)s.SerializeBool)(v.hasCallbacks);
            s.SerializeFieldName("reset_time");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.resetTime);
            s.SerializeFieldName("health");
            ((Action<float>)s.SerializeF32)(v.health);
            s.SerializeFieldName("proximity_damage");
            ((Action<bool>)s.SerializeBool)(v.proximityDamage);
            s.SerializeFieldName("activ_prereq_min_to_satisfy");
            ((Action<byte>)s.SerializeU8)(v.activPrereqMinToSatisfy);
            s.SerializeFieldName("objects");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)))(v.objects);
            s.SerializeFieldName("nodes");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePtrConverter.Converter)))(v.nodes);
            s.SerializeFieldName("lights");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePtrConverter.Converter)))(v.lights);
            s.SerializeFieldName("puffers");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePtrFlagsConverter.Converter)))(v.puffers);
            s.SerializeFieldName("dynamic_sounds");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePtrConverter.Converter)))(v.dynamicSounds);
            s.SerializeFieldName("static_sounds");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)))(v.staticSounds);
            s.SerializeFieldName("activ_prereqs");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.ActivationPrereq.Converter)))(v.activPrereqs);
            s.SerializeFieldName("anim_refs");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)))(v.animRefs);
            s.SerializeFieldName("reset_state");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.ResetState.Converter))(v.resetState);
            s.SerializeFieldName("sequences");
            s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.SeqDef.Converter))(v.sequences);
        }

        public static AnimDef Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                animName = new Field<Mech3DotNet.Types.Anim.NamePad>(),
                animRoot = new Field<Mech3DotNet.Types.Anim.NamePad>(),
                fileName = new Field<string>(),
                autoResetNodeStates = new Field<bool>(),
                activation = new Field<Mech3DotNet.Types.Anim.AnimActivation>(),
                execution = new Field<Mech3DotNet.Types.Anim.Execution>(),
                networkLog = new Field<bool?>(null),
                saveLog = new Field<bool?>(null),
                hasCallbacks = new Field<bool>(),
                resetTime = new Field<float?>(null),
                health = new Field<float>(),
                proximityDamage = new Field<bool>(),
                activPrereqMinToSatisfy = new Field<byte>(),
                objects = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>?>(null),
                nodes = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>?>(null),
                lights = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>?>(null),
                puffers = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtrFlags>?>(null),
                dynamicSounds = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePtr>?>(null),
                staticSounds = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>?>(null),
                activPrereqs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.ActivationPrereq>?>(null),
                animRefs = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.NamePad>?>(null),
                resetState = new Field<Mech3DotNet.Types.Anim.ResetState?>(),
                sequences = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.SeqDef>>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "anim_name":
                        fields.animName.Value = d.Deserialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)();
                        break;
                    case "anim_root":
                        fields.animRoot.Value = d.Deserialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)();
                        break;
                    case "file_name":
                        fields.fileName.Value = d.DeserializeString();
                        break;
                    case "auto_reset_node_states":
                        fields.autoResetNodeStates.Value = d.DeserializeBool();
                        break;
                    case "activation":
                        fields.activation.Value = d.Deserialize(Mech3DotNet.Types.Anim.AnimActivationConverter.Converter)();
                        break;
                    case "execution":
                        fields.execution.Value = d.Deserialize(Mech3DotNet.Types.Anim.Execution.Converter)();
                        break;
                    case "network_log":
                        fields.networkLog.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "save_log":
                        fields.saveLog.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "has_callbacks":
                        fields.hasCallbacks.Value = d.DeserializeBool();
                        break;
                    case "reset_time":
                        fields.resetTime.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "health":
                        fields.health.Value = d.DeserializeF32();
                        break;
                    case "proximity_damage":
                        fields.proximityDamage.Value = d.DeserializeBool();
                        break;
                    case "activ_prereq_min_to_satisfy":
                        fields.activPrereqMinToSatisfy.Value = d.DeserializeU8();
                        break;
                    case "objects":
                        fields.objects.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)))();
                        break;
                    case "nodes":
                        fields.nodes.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePtrConverter.Converter)))();
                        break;
                    case "lights":
                        fields.lights.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePtrConverter.Converter)))();
                        break;
                    case "puffers":
                        fields.puffers.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePtrFlagsConverter.Converter)))();
                        break;
                    case "dynamic_sounds":
                        fields.dynamicSounds.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePtrConverter.Converter)))();
                        break;
                    case "static_sounds":
                        fields.staticSounds.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)))();
                        break;
                    case "activ_prereqs":
                        fields.activPrereqs.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.ActivationPrereq.Converter)))();
                        break;
                    case "anim_refs":
                        fields.animRefs.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.NamePadConverter.Converter)))();
                        break;
                    case "reset_state":
                        fields.resetState.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.ResetState.Converter))();
                        break;
                    case "sequences":
                        fields.sequences.Value = d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.SeqDef.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("AnimDef", fieldName);
                }
            }
            return new AnimDef(

                fields.name.Unwrap("AnimDef", "name"),

                fields.animName.Unwrap("AnimDef", "animName"),

                fields.animRoot.Unwrap("AnimDef", "animRoot"),

                fields.fileName.Unwrap("AnimDef", "fileName"),

                fields.autoResetNodeStates.Unwrap("AnimDef", "autoResetNodeStates"),

                fields.activation.Unwrap("AnimDef", "activation"),

                fields.execution.Unwrap("AnimDef", "execution"),

                fields.networkLog.Unwrap("AnimDef", "networkLog"),

                fields.saveLog.Unwrap("AnimDef", "saveLog"),

                fields.hasCallbacks.Unwrap("AnimDef", "hasCallbacks"),

                fields.resetTime.Unwrap("AnimDef", "resetTime"),

                fields.health.Unwrap("AnimDef", "health"),

                fields.proximityDamage.Unwrap("AnimDef", "proximityDamage"),

                fields.activPrereqMinToSatisfy.Unwrap("AnimDef", "activPrereqMinToSatisfy"),

                fields.objects.Unwrap("AnimDef", "objects"),

                fields.nodes.Unwrap("AnimDef", "nodes"),

                fields.lights.Unwrap("AnimDef", "lights"),

                fields.puffers.Unwrap("AnimDef", "puffers"),

                fields.dynamicSounds.Unwrap("AnimDef", "dynamicSounds"),

                fields.staticSounds.Unwrap("AnimDef", "staticSounds"),

                fields.activPrereqs.Unwrap("AnimDef", "activPrereqs"),

                fields.animRefs.Unwrap("AnimDef", "animRefs"),

                fields.resetState.Unwrap("AnimDef", "resetState"),

                fields.sequences.Unwrap("AnimDef", "sequences")

            );
        }
    }
}
