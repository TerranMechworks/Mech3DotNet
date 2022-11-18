using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class LightStateConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Anim.Events.LightState>
    {
        protected override Mech3DotNet.Json.Anim.Events.LightState ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var activeStateField = new Mech3DotNet.Json.Converters.Option<bool>();
            var directionalField = new Mech3DotNet.Json.Converters.Option<bool?>(null);
            var saturatedField = new Mech3DotNet.Json.Converters.Option<bool?>(null);
            var subdivideField = new Mech3DotNet.Json.Converters.Option<bool?>(null);
            var static_Field = new Mech3DotNet.Json.Converters.Option<bool?>(null);
            var atNodeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Anim.Events.AtNode?>(null);
            var rangeField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Range?>(null);
            var colorField = new Mech3DotNet.Json.Converters.Option<Mech3DotNet.Json.Types.Color?>(null);
            var ambientField = new Mech3DotNet.Json.Converters.Option<float?>(null);
            var diffuseField = new Mech3DotNet.Json.Converters.Option<float?>(null);
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'LightState'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "active_state":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            activeStateField.Set(__value);
                            break;
                        }
                    case "directional":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            directionalField.Set(__value);
                            break;
                        }
                    case "saturated":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            saturatedField.Set(__value);
                            break;
                        }
                    case "subdivide":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            subdivideField.Set(__value);
                            break;
                        }
                    case "static_":
                        {
                            bool? __value = ReadFieldValue<bool?>(ref __reader, __options);
                            static_Field.Set(__value);
                            break;
                        }
                    case "at_node":
                        {
                            Mech3DotNet.Json.Anim.Events.AtNode? __value = ReadFieldValue<Mech3DotNet.Json.Anim.Events.AtNode?>(ref __reader, __options);
                            atNodeField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Mech3DotNet.Json.Types.Range? __value = ReadFieldValue<Mech3DotNet.Json.Types.Range?>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "color":
                        {
                            Mech3DotNet.Json.Types.Color? __value = ReadFieldValue<Mech3DotNet.Json.Types.Color?>(ref __reader, __options);
                            colorField.Set(__value);
                            break;
                        }
                    case "ambient":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            ambientField.Set(__value);
                            break;
                        }
                    case "diffuse":
                        {
                            float? __value = ReadFieldValue<float?>(ref __reader, __options);
                            diffuseField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'LightState'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var activeState = activeStateField.Unwrap("active_state");
            var directional = directionalField.Unwrap("directional");
            var saturated = saturatedField.Unwrap("saturated");
            var subdivide = subdivideField.Unwrap("subdivide");
            var static_ = static_Field.Unwrap("static_");
            var atNode = atNodeField.Unwrap("at_node");
            var range = rangeField.Unwrap("range");
            var color = colorField.Unwrap("color");
            var ambient = ambientField.Unwrap("ambient");
            var diffuse = diffuseField.Unwrap("diffuse");
            return new Mech3DotNet.Json.Anim.Events.LightState(name, activeState, directional, saturated, subdivide, static_, atNode, range, color, ambient, diffuse);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.LightState value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("active_state");
            JsonSerializer.Serialize(writer, value.activeState, options);
            if (value.directional != null)
            {
                writer.WritePropertyName("directional");
                JsonSerializer.Serialize(writer, value.directional, options);
            }
            if (value.saturated != null)
            {
                writer.WritePropertyName("saturated");
                JsonSerializer.Serialize(writer, value.saturated, options);
            }
            if (value.subdivide != null)
            {
                writer.WritePropertyName("subdivide");
                JsonSerializer.Serialize(writer, value.subdivide, options);
            }
            if (value.static_ != null)
            {
                writer.WritePropertyName("static_");
                JsonSerializer.Serialize(writer, value.static_, options);
            }
            if (value.atNode != null)
            {
                writer.WritePropertyName("at_node");
                JsonSerializer.Serialize(writer, value.atNode, options);
            }
            if (value.range != null)
            {
                writer.WritePropertyName("range");
                JsonSerializer.Serialize(writer, value.range, options);
            }
            if (value.color != null)
            {
                writer.WritePropertyName("color");
                JsonSerializer.Serialize(writer, value.color, options);
            }
            if (value.ambient != null)
            {
                writer.WritePropertyName("ambient");
                JsonSerializer.Serialize(writer, value.ambient, options);
            }
            if (value.diffuse != null)
            {
                writer.WritePropertyName("diffuse");
                JsonSerializer.Serialize(writer, value.diffuse, options);
            }
            writer.WriteEndObject();
        }
    }
}
