using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class AnimDefConverter : Mech3DotNet.Json.Converters.StructConverter<AnimDef>
    {
        protected override AnimDef ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var animNameField = new Mech3DotNet.Json.Converters.Option<NamePad>();
            var animRootField = new Mech3DotNet.Json.Converters.Option<NamePad>();
            var fileNameField = new Mech3DotNet.Json.Converters.Option<string>();
            var autoResetNodeStatesField = new Mech3DotNet.Json.Converters.Option<bool>();
            var activationField = new Mech3DotNet.Json.Converters.Option<AnimActivation>();
            var executionField = new Mech3DotNet.Json.Converters.Option<Execution>();
            var networkLogField = new Mech3DotNet.Json.Converters.Option<bool?>(null);
            var saveLogField = new Mech3DotNet.Json.Converters.Option<bool?>(null);
            var hasCallbacksField = new Mech3DotNet.Json.Converters.Option<bool>();
            var resetTimeField = new Mech3DotNet.Json.Converters.Option<float?>(null);
            var healthField = new Mech3DotNet.Json.Converters.Option<float>();
            var proximityDamageField = new Mech3DotNet.Json.Converters.Option<bool>();
            var activPrereqMinToSatisfyField = new Mech3DotNet.Json.Converters.Option<byte>();
            var objectsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePad>?>(null);
            var nodesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePtr>?>(null);
            var lightsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePtr>?>(null);
            var puffersField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePtrFlags>?>(null);
            var dynamicSoundsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePtr>?>(null);
            var staticSoundsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePad>?>(null);
            var activPrereqsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<ActivationPrereq>?>(null);
            var animRefsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NamePad>?>(null);
            var resetStateField = new Mech3DotNet.Json.Converters.Option<ResetState?>();
            var sequencesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<SeqDef>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "name":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'AnimDef'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "anim_name":
                        {
                            NamePad __value = ReadFieldValue<NamePad>(ref __reader, __options);
                            animNameField.Set(__value);
                            break;
                        }
                    case "anim_root":
                        {
                            NamePad __value = ReadFieldValue<NamePad>(ref __reader, __options);
                            animRootField.Set(__value);
                            break;
                        }
                    case "file_name":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'file_name' was null for 'AnimDef'");
                                throw new JsonException();
                            }
                            fileNameField.Set(__value);
                            break;
                        }
                    case "auto_reset_node_states":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            autoResetNodeStatesField.Set(__value);
                            break;
                        }
                    case "activation":
                        {
                            AnimActivation __value = ReadFieldValue<AnimActivation>(ref __reader, __options);
                            activationField.Set(__value);
                            break;
                        }
                    case "execution":
                        {
                            Execution? __value = ReadFieldValue<Execution?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'execution' was null for 'AnimDef'");
                                throw new JsonException();
                            }
                            executionField.Set(__value);
                            break;
                        }
                    case "network_log":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            networkLogField.Set(__value);
                            break;
                        }
                    case "save_log":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            saveLogField.Set(__value);
                            break;
                        }
                    case "has_callbacks":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            hasCallbacksField.Set(__value);
                            break;
                        }
                    case "reset_time":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            resetTimeField.Set(__value);
                            break;
                        }
                    case "health":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            healthField.Set(__value);
                            break;
                        }
                    case "proximity_damage":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            proximityDamageField.Set(__value);
                            break;
                        }
                    case "activ_prereq_min_to_satisfy":
                        {
                            byte __value = ReadFieldValue<byte>(ref __reader, __options);
                            activPrereqMinToSatisfyField.Set(__value);
                            break;
                        }
                    case "objects":
                        {
                            System.Collections.Generic.List<NamePad>? __value = ReadFieldValue<System.Collections.Generic.List<NamePad>?>(ref __reader, __options);
                            objectsField.Set(__value);
                            break;
                        }
                    case "nodes":
                        {
                            System.Collections.Generic.List<NamePtr>? __value = ReadFieldValue<System.Collections.Generic.List<NamePtr>?>(ref __reader, __options);
                            nodesField.Set(__value);
                            break;
                        }
                    case "lights":
                        {
                            System.Collections.Generic.List<NamePtr>? __value = ReadFieldValue<System.Collections.Generic.List<NamePtr>?>(ref __reader, __options);
                            lightsField.Set(__value);
                            break;
                        }
                    case "puffers":
                        {
                            System.Collections.Generic.List<NamePtrFlags>? __value = ReadFieldValue<System.Collections.Generic.List<NamePtrFlags>?>(ref __reader, __options);
                            puffersField.Set(__value);
                            break;
                        }
                    case "dynamic_sounds":
                        {
                            System.Collections.Generic.List<NamePtr>? __value = ReadFieldValue<System.Collections.Generic.List<NamePtr>?>(ref __reader, __options);
                            dynamicSoundsField.Set(__value);
                            break;
                        }
                    case "static_sounds":
                        {
                            System.Collections.Generic.List<NamePad>? __value = ReadFieldValue<System.Collections.Generic.List<NamePad>?>(ref __reader, __options);
                            staticSoundsField.Set(__value);
                            break;
                        }
                    case "activ_prereqs":
                        {
                            System.Collections.Generic.List<ActivationPrereq>? __value = ReadFieldValue<System.Collections.Generic.List<ActivationPrereq>?>(ref __reader, __options);
                            activPrereqsField.Set(__value);
                            break;
                        }
                    case "anim_refs":
                        {
                            System.Collections.Generic.List<NamePad>? __value = ReadFieldValue<System.Collections.Generic.List<NamePad>?>(ref __reader, __options);
                            animRefsField.Set(__value);
                            break;
                        }
                    case "reset_state":
                        {
                            ResetState? __value = ReadFieldValue<ResetState?>(ref __reader, __options);
                            resetStateField.Set(__value);
                            break;
                        }
                    case "sequences":
                        {
                            System.Collections.Generic.List<SeqDef>? __value = ReadFieldValue<System.Collections.Generic.List<SeqDef>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'sequences' was null for 'AnimDef'");
                                throw new JsonException();
                            }
                            sequencesField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'AnimDef'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var animName = animNameField.Unwrap("anim_name");
            var animRoot = animRootField.Unwrap("anim_root");
            var fileName = fileNameField.Unwrap("file_name");
            var autoResetNodeStates = autoResetNodeStatesField.Unwrap("auto_reset_node_states");
            var activation = activationField.Unwrap("activation");
            var execution = executionField.Unwrap("execution");
            var networkLog = networkLogField.Unwrap("network_log");
            var saveLog = saveLogField.Unwrap("save_log");
            var hasCallbacks = hasCallbacksField.Unwrap("has_callbacks");
            var resetTime = resetTimeField.Unwrap("reset_time");
            var health = healthField.Unwrap("health");
            var proximityDamage = proximityDamageField.Unwrap("proximity_damage");
            var activPrereqMinToSatisfy = activPrereqMinToSatisfyField.Unwrap("activ_prereq_min_to_satisfy");
            var objects = objectsField.Unwrap("objects");
            var nodes = nodesField.Unwrap("nodes");
            var lights = lightsField.Unwrap("lights");
            var puffers = puffersField.Unwrap("puffers");
            var dynamicSounds = dynamicSoundsField.Unwrap("dynamic_sounds");
            var staticSounds = staticSoundsField.Unwrap("static_sounds");
            var activPrereqs = activPrereqsField.Unwrap("activ_prereqs");
            var animRefs = animRefsField.Unwrap("anim_refs");
            var resetState = resetStateField.Unwrap("reset_state");
            var sequences = sequencesField.Unwrap("sequences");
            return new AnimDef(name, animName, animRoot, fileName, autoResetNodeStates, activation, execution, networkLog, saveLog, hasCallbacks, resetTime, health, proximityDamage, activPrereqMinToSatisfy, objects, nodes, lights, puffers, dynamicSounds, staticSounds, activPrereqs, animRefs, resetState, sequences);
        }

        public override void Write(Utf8JsonWriter writer, AnimDef value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("anim_name");
            JsonSerializer.Serialize(writer, value.animName, options);
            writer.WritePropertyName("anim_root");
            JsonSerializer.Serialize(writer, value.animRoot, options);
            writer.WritePropertyName("file_name");
            JsonSerializer.Serialize(writer, value.fileName, options);
            writer.WritePropertyName("auto_reset_node_states");
            JsonSerializer.Serialize(writer, value.autoResetNodeStates, options);
            writer.WritePropertyName("activation");
            JsonSerializer.Serialize(writer, value.activation, options);
            writer.WritePropertyName("execution");
            JsonSerializer.Serialize(writer, value.execution, options);
            if (value.networkLog != null)
            {
                writer.WritePropertyName("network_log");
                JsonSerializer.Serialize(writer, value.networkLog, options);
            }
            if (value.saveLog != null)
            {
                writer.WritePropertyName("save_log");
                JsonSerializer.Serialize(writer, value.saveLog, options);
            }
            writer.WritePropertyName("has_callbacks");
            JsonSerializer.Serialize(writer, value.hasCallbacks, options);
            if (value.resetTime != null)
            {
                writer.WritePropertyName("reset_time");
                JsonSerializer.Serialize(writer, value.resetTime, options);
            }
            writer.WritePropertyName("health");
            JsonSerializer.Serialize(writer, value.health, options);
            writer.WritePropertyName("proximity_damage");
            JsonSerializer.Serialize(writer, value.proximityDamage, options);
            writer.WritePropertyName("activ_prereq_min_to_satisfy");
            JsonSerializer.Serialize(writer, value.activPrereqMinToSatisfy, options);
            if (value.objects != null)
            {
                writer.WritePropertyName("objects");
                JsonSerializer.Serialize(writer, value.objects, options);
            }
            if (value.nodes != null)
            {
                writer.WritePropertyName("nodes");
                JsonSerializer.Serialize(writer, value.nodes, options);
            }
            if (value.lights != null)
            {
                writer.WritePropertyName("lights");
                JsonSerializer.Serialize(writer, value.lights, options);
            }
            if (value.puffers != null)
            {
                writer.WritePropertyName("puffers");
                JsonSerializer.Serialize(writer, value.puffers, options);
            }
            if (value.dynamicSounds != null)
            {
                writer.WritePropertyName("dynamic_sounds");
                JsonSerializer.Serialize(writer, value.dynamicSounds, options);
            }
            if (value.staticSounds != null)
            {
                writer.WritePropertyName("static_sounds");
                JsonSerializer.Serialize(writer, value.staticSounds, options);
            }
            if (value.activPrereqs != null)
            {
                writer.WritePropertyName("activ_prereqs");
                JsonSerializer.Serialize(writer, value.activPrereqs, options);
            }
            if (value.animRefs != null)
            {
                writer.WritePropertyName("anim_refs");
                JsonSerializer.Serialize(writer, value.animRefs, options);
            }
            writer.WritePropertyName("reset_state");
            JsonSerializer.Serialize(writer, value.resetState, options);
            writer.WritePropertyName("sequences");
            JsonSerializer.Serialize(writer, value.sequences, options);
            writer.WriteEndObject();
        }
    }
}
