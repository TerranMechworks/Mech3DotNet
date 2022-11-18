using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class PufferStateConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.PufferState>
    {
        protected override Mech3DotNet.Json.Anim.Events.PufferState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var stateField = new Mech3DotNet.Json.Converters.Option<bool>();
            var translateField = new Mech3DotNet.Json.Converters.Option<bool>();
            var activeStateField = new Mech3DotNet.Json.Converters.Option<int?>(null);
            var atNodeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.AtNode?>(null);
            var localVelocityField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>(null);
            var worldVelocityField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>(null);
            var minRandomVelocityField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>(null);
            var maxRandomVelocityField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>(null);
            var worldAccelerationField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Vec3?>(null);
            var intervalField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.Interval>();
            var sizeRangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range?>(null);
            var lifetimeRangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range?>(null);
            var startAgeRangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range?>(null);
            var deviationDistanceField = new Mech3DotNet.Json.Converters.Option<float?>(null);
            var fadeRangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range?>(null);
            var frictionField = new Mech3DotNet.Json.Converters.Option<float?>(null);
            var texturesField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures?>(null);
            var growthFactorField = new Mech3DotNet.Json.Converters.Option<float?>(null);
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
                            Mech3DotNet.Json.Anim.Events.AtNode? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.AtNode?>(ref __reader, __options);
                            atNodeField.Set(__value);
                            break;
                        }
                    case "local_velocity":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            localVelocityField.Set(__value);
                            break;
                        }
                    case "world_velocity":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            worldVelocityField.Set(__value);
                            break;
                        }
                    case "min_random_velocity":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            minRandomVelocityField.Set(__value);
                            break;
                        }
                    case "max_random_velocity":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            maxRandomVelocityField.Set(__value);
                            break;
                        }
                    case "world_acceleration":
                        {
                            Mech3DotNet.Json.Types.Vec3? __value = ReadFieldValue<Mech3DotNet.Json.Types.Vec3?>(ref __reader, __options);
                            worldAccelerationField.Set(__value);
                            break;
                        }
                    case "interval":
                        {
                            Mech3DotNet.Json.Anim.Events.Interval? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.Interval?>(ref __reader, __options);
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
                            Mech3DotNet.Json.Types.Range? __value = ReadFieldValue<Mech3DotNet.Json.Types.Range?>(ref __reader, __options);
                            sizeRangeField.Set(__value);
                            break;
                        }
                    case "lifetime_range":
                        {
                            Mech3DotNet.Json.Types.Range? __value = ReadFieldValue<Mech3DotNet.Json.Types.Range?>(ref __reader, __options);
                            lifetimeRangeField.Set(__value);
                            break;
                        }
                    case "start_age_range":
                        {
                            Mech3DotNet.Json.Types.Range? __value = ReadFieldValue<Mech3DotNet.Json.Types.Range?>(ref __reader, __options);
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
                            Mech3DotNet.Json.Types.Range? __value = ReadFieldValue<Mech3DotNet.Json.Types.Range?>(ref __reader, __options);
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
                            Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.PufferStateCycleTextures?>(ref __reader, __options);
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
            return new Mech3DotNet.Json.Anim.Events.PufferState(name, state, translate, activeState, atNode, localVelocity, worldVelocity, minRandomVelocity, maxRandomVelocity, worldAcceleration, interval, sizeRange, lifetimeRange, startAgeRange, deviationDistance, fadeRange, friction, textures, growthFactor);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.PufferState value, JsonSerializerOptions options)
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
