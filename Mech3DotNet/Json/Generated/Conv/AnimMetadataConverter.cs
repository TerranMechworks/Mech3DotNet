using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class AnimMetadataConverter : StructConverter<AnimMetadata>
    {
        protected override AnimMetadata ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var basePtrField = new Option<uint>();
            var worldPtrField = new Option<uint>();
            var animNamesField = new Option<List<AnimName>>();
            var animPtrsField = new Option<List<AnimPtr>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "base_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            basePtrField.Set(__value);
                            break;
                        }
                    case "world_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            worldPtrField.Set(__value);
                            break;
                        }
                    case "anim_names":
                        {
                            List<AnimName>? __value = ReadFieldValue<List<AnimName>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'anim_names' was null for 'AnimMetadata'");
                                throw new JsonException();
                            }
                            animNamesField.Set(__value);
                            break;
                        }
                    case "anim_ptrs":
                        {
                            List<AnimPtr>? __value = ReadFieldValue<List<AnimPtr>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'anim_ptrs' was null for 'AnimMetadata'");
                                throw new JsonException();
                            }
                            animPtrsField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'AnimMetadata'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var basePtr = basePtrField.Unwrap("base_ptr");
            var worldPtr = worldPtrField.Unwrap("world_ptr");
            var animNames = animNamesField.Unwrap("anim_names");
            var animPtrs = animPtrsField.Unwrap("anim_ptrs");
            return new AnimMetadata(basePtr, worldPtr, animNames, animPtrs);
        }

        public override void Write(Utf8JsonWriter writer, AnimMetadata value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("base_ptr");
            JsonSerializer.Serialize(writer, value.basePtr, options);
            writer.WritePropertyName("world_ptr");
            JsonSerializer.Serialize(writer, value.worldPtr, options);
            writer.WritePropertyName("anim_names");
            JsonSerializer.Serialize(writer, value.animNames, options);
            writer.WritePropertyName("anim_ptrs");
            JsonSerializer.Serialize(writer, value.animPtrs, options);
            writer.WriteEndObject();
        }
    }
}
