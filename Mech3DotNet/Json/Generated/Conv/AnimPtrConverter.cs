using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class AnimPtrConverter : StructConverter<AnimPtr>
    {
        protected override AnimPtr ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var fileNameField = new Option<string>();
            var animPtrField = new Option<uint>();
            var animRootPtrField = new Option<uint>();
            var objectsPtrField = new Option<uint>();
            var nodesPtrField = new Option<uint>();
            var lightsPtrField = new Option<uint>();
            var puffersPtrField = new Option<uint>();
            var dynamicSoundsPtrField = new Option<uint>();
            var staticSoundsPtrField = new Option<uint>();
            var activPrereqsPtrField = new Option<uint>();
            var animRefsPtrField = new Option<uint>();
            var resetStatePtrField = new Option<uint>();
            var seqDefsPtrField = new Option<uint>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "file_name":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'file_name' was null for 'AnimPtr'");
                                throw new JsonException();
                            }
                            fileNameField.Set(__value);
                            break;
                        }
                    case "anim_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            animPtrField.Set(__value);
                            break;
                        }
                    case "anim_root_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            animRootPtrField.Set(__value);
                            break;
                        }
                    case "objects_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            objectsPtrField.Set(__value);
                            break;
                        }
                    case "nodes_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            nodesPtrField.Set(__value);
                            break;
                        }
                    case "lights_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            lightsPtrField.Set(__value);
                            break;
                        }
                    case "puffers_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            puffersPtrField.Set(__value);
                            break;
                        }
                    case "dynamic_sounds_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            dynamicSoundsPtrField.Set(__value);
                            break;
                        }
                    case "static_sounds_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            staticSoundsPtrField.Set(__value);
                            break;
                        }
                    case "activ_prereqs_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            activPrereqsPtrField.Set(__value);
                            break;
                        }
                    case "anim_refs_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            animRefsPtrField.Set(__value);
                            break;
                        }
                    case "reset_state_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            resetStatePtrField.Set(__value);
                            break;
                        }
                    case "seq_defs_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            seqDefsPtrField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'AnimPtr'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var fileName = fileNameField.Unwrap("file_name");
            var animPtr = animPtrField.Unwrap("anim_ptr");
            var animRootPtr = animRootPtrField.Unwrap("anim_root_ptr");
            var objectsPtr = objectsPtrField.Unwrap("objects_ptr");
            var nodesPtr = nodesPtrField.Unwrap("nodes_ptr");
            var lightsPtr = lightsPtrField.Unwrap("lights_ptr");
            var puffersPtr = puffersPtrField.Unwrap("puffers_ptr");
            var dynamicSoundsPtr = dynamicSoundsPtrField.Unwrap("dynamic_sounds_ptr");
            var staticSoundsPtr = staticSoundsPtrField.Unwrap("static_sounds_ptr");
            var activPrereqsPtr = activPrereqsPtrField.Unwrap("activ_prereqs_ptr");
            var animRefsPtr = animRefsPtrField.Unwrap("anim_refs_ptr");
            var resetStatePtr = resetStatePtrField.Unwrap("reset_state_ptr");
            var seqDefsPtr = seqDefsPtrField.Unwrap("seq_defs_ptr");
            return new AnimPtr(fileName, animPtr, animRootPtr, objectsPtr, nodesPtr, lightsPtr, puffersPtr, dynamicSoundsPtr, staticSoundsPtr, activPrereqsPtr, animRefsPtr, resetStatePtr, seqDefsPtr);
        }

        public override void Write(Utf8JsonWriter writer, AnimPtr value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("file_name");
            JsonSerializer.Serialize(writer, value.fileName, options);
            writer.WritePropertyName("anim_ptr");
            JsonSerializer.Serialize(writer, value.animPtr, options);
            writer.WritePropertyName("anim_root_ptr");
            JsonSerializer.Serialize(writer, value.animRootPtr, options);
            writer.WritePropertyName("objects_ptr");
            JsonSerializer.Serialize(writer, value.objectsPtr, options);
            writer.WritePropertyName("nodes_ptr");
            JsonSerializer.Serialize(writer, value.nodesPtr, options);
            writer.WritePropertyName("lights_ptr");
            JsonSerializer.Serialize(writer, value.lightsPtr, options);
            writer.WritePropertyName("puffers_ptr");
            JsonSerializer.Serialize(writer, value.puffersPtr, options);
            writer.WritePropertyName("dynamic_sounds_ptr");
            JsonSerializer.Serialize(writer, value.dynamicSoundsPtr, options);
            writer.WritePropertyName("static_sounds_ptr");
            JsonSerializer.Serialize(writer, value.staticSoundsPtr, options);
            writer.WritePropertyName("activ_prereqs_ptr");
            JsonSerializer.Serialize(writer, value.activPrereqsPtr, options);
            writer.WritePropertyName("anim_refs_ptr");
            JsonSerializer.Serialize(writer, value.animRefsPtr, options);
            writer.WritePropertyName("reset_state_ptr");
            JsonSerializer.Serialize(writer, value.resetStatePtr, options);
            writer.WritePropertyName("seq_defs_ptr");
            JsonSerializer.Serialize(writer, value.seqDefsPtr, options);
            writer.WriteEndObject();
        }
    }
}
