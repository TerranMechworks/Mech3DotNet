using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class PufferStateConverter : StructConverter<PufferState>
    {
        protected override PufferState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var stateField = new Option<bool>();
            var translateField = new Option<bool>();
            var activeStateField = new Option<int?>(null);
            var atNodeField = new Option<AtNode?>(null);
            var localVelocityField = new Option<Vec3?>(null);
            var worldVelocityField = new Option<Vec3?>(null);
            var minRandomVelocityField = new Option<Vec3?>(null);
            var maxRandomVelocityField = new Option<Vec3?>(null);
            var worldAccelerationField = new Option<Vec3?>(null);
            var intervalField = new Option<Interval>();
            var sizeRangeField = new Option<Range?>(null);
            var lifetimeRangeField = new Option<Range?>(null);
            var startAgeRangeField = new Option<Range?>(null);
            var deviationDistanceField = new Option<float?>(null);
            var fadeRangeField = new Option<Range?>(null);
            var frictionField = new Option<float?>(null);
            var texturesField = new Option<PufferStateCycleTextures?>(null);
            var growthFactorField = new Option<float?>(null);
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'PufferState'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "state":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            stateField.Set(__value);
                            break;
                        }
                    case "translate":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            translateField.Set(__value);
                            break;
                        }
                    case "active_state":
                        {
                            int? __value = ReadFieldValue<int?>(ref __reader, __options);
                            activeStateField.Set(__value);
                            break;
                        }
                    case "at_node":
                        {
                            AtNode? __value = ReadFieldValue<AtNode?>(ref __reader, __options);
                            atNodeField.Set(__value);
                            break;
                        }
                    case "local_velocity":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            localVelocityField.Set(__value);
                            break;
                        }
                    case "world_velocity":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            worldVelocityField.Set(__value);
                            break;
                        }
                    case "min_random_velocity":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            minRandomVelocityField.Set(__value);
                            break;
                        }
                    case "max_random_velocity":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            maxRandomVelocityField.Set(__value);
                            break;
                        }
                    case "world_acceleration":
                        {
                            Vec3? __value = ReadFieldValue<Vec3?>(ref __reader, __options);
                            worldAccelerationField.Set(__value);
                            break;
                        }
                    case "interval":
                        {
                            Interval? __value = ReadFieldValue<Interval?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'interval' was null for 'PufferState'");
                                throw new JsonException();
                            }
                            intervalField.Set(__value);
                            break;
                        }
                    case "size_range":
                        {
                            Range? __value = ReadFieldValue<Range?>(ref __reader, __options);
                            sizeRangeField.Set(__value);
                            break;
                        }
                    case "lifetime_range":
                        {
                            Range? __value = ReadFieldValue<Range?>(ref __reader, __options);
                            lifetimeRangeField.Set(__value);
                            break;
                        }
                    case "start_age_range":
                        {
                            Range? __value = ReadFieldValue<Range?>(ref __reader, __options);
                            startAgeRangeField.Set(__value);
                            break;
                        }
                    case "deviation_distance":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            deviationDistanceField.Set(__value);
                            break;
                        }
                    case "fade_range":
                        {
                            Range? __value = ReadFieldValue<Range?>(ref __reader, __options);
                            fadeRangeField.Set(__value);
                            break;
                        }
                    case "friction":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            frictionField.Set(__value);
                            break;
                        }
                    case "textures":
                        {
                            PufferStateCycleTextures? __value = ReadFieldValue<PufferStateCycleTextures?>(ref __reader, __options);
                            texturesField.Set(__value);
                            break;
                        }
                    case "growth_factor":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            growthFactorField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'PufferState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var state = stateField.Unwrap("state");
            var translate = translateField.Unwrap("translate");
            var activeState = activeStateField.Unwrap("active_state");
            var atNode = atNodeField.Unwrap("at_node");
            var localVelocity = localVelocityField.Unwrap("local_velocity");
            var worldVelocity = worldVelocityField.Unwrap("world_velocity");
            var minRandomVelocity = minRandomVelocityField.Unwrap("min_random_velocity");
            var maxRandomVelocity = maxRandomVelocityField.Unwrap("max_random_velocity");
            var worldAcceleration = worldAccelerationField.Unwrap("world_acceleration");
            var interval = intervalField.Unwrap("interval");
            var sizeRange = sizeRangeField.Unwrap("size_range");
            var lifetimeRange = lifetimeRangeField.Unwrap("lifetime_range");
            var startAgeRange = startAgeRangeField.Unwrap("start_age_range");
            var deviationDistance = deviationDistanceField.Unwrap("deviation_distance");
            var fadeRange = fadeRangeField.Unwrap("fade_range");
            var friction = frictionField.Unwrap("friction");
            var textures = texturesField.Unwrap("textures");
            var growthFactor = growthFactorField.Unwrap("growth_factor");
            return new PufferState(name, state, translate, activeState, atNode, localVelocity, worldVelocity, minRandomVelocity, maxRandomVelocity, worldAcceleration, interval, sizeRange, lifetimeRange, startAgeRange, deviationDistance, fadeRange, friction, textures, growthFactor);
        }

        public override void Write(Utf8JsonWriter writer, PufferState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("state");
            JsonSerializer.Serialize(writer, value.state, options);
            writer.WritePropertyName("translate");
            JsonSerializer.Serialize(writer, value.translate, options);
            if (value.activeState != null)
            {
                writer.WritePropertyName("active_state");
                JsonSerializer.Serialize(writer, value.activeState, options);
            }
            if (value.atNode != null)
            {
                writer.WritePropertyName("at_node");
                JsonSerializer.Serialize(writer, value.atNode, options);
            }
            if (value.localVelocity != null)
            {
                writer.WritePropertyName("local_velocity");
                JsonSerializer.Serialize(writer, value.localVelocity, options);
            }
            if (value.worldVelocity != null)
            {
                writer.WritePropertyName("world_velocity");
                JsonSerializer.Serialize(writer, value.worldVelocity, options);
            }
            if (value.minRandomVelocity != null)
            {
                writer.WritePropertyName("min_random_velocity");
                JsonSerializer.Serialize(writer, value.minRandomVelocity, options);
            }
            if (value.maxRandomVelocity != null)
            {
                writer.WritePropertyName("max_random_velocity");
                JsonSerializer.Serialize(writer, value.maxRandomVelocity, options);
            }
            if (value.worldAcceleration != null)
            {
                writer.WritePropertyName("world_acceleration");
                JsonSerializer.Serialize(writer, value.worldAcceleration, options);
            }
            writer.WritePropertyName("interval");
            JsonSerializer.Serialize(writer, value.interval, options);
            if (value.sizeRange != null)
            {
                writer.WritePropertyName("size_range");
                JsonSerializer.Serialize(writer, value.sizeRange, options);
            }
            if (value.lifetimeRange != null)
            {
                writer.WritePropertyName("lifetime_range");
                JsonSerializer.Serialize(writer, value.lifetimeRange, options);
            }
            if (value.startAgeRange != null)
            {
                writer.WritePropertyName("start_age_range");
                JsonSerializer.Serialize(writer, value.startAgeRange, options);
            }
            if (value.deviationDistance != null)
            {
                writer.WritePropertyName("deviation_distance");
                JsonSerializer.Serialize(writer, value.deviationDistance, options);
            }
            if (value.fadeRange != null)
            {
                writer.WritePropertyName("fade_range");
                JsonSerializer.Serialize(writer, value.fadeRange, options);
            }
            if (value.friction != null)
            {
                writer.WritePropertyName("friction");
                JsonSerializer.Serialize(writer, value.friction, options);
            }
            if (value.textures != null)
            {
                writer.WritePropertyName("textures");
                JsonSerializer.Serialize(writer, value.textures, options);
            }
            if (value.growthFactor != null)
            {
                writer.WritePropertyName("growth_factor");
                JsonSerializer.Serialize(writer, value.growthFactor, options);
            }
            writer.WriteEndObject();
        }
    }
}
