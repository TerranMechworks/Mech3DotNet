using System.Text.Json;

namespace Mech3DotNet.Json.Gamez.Nodes.Converters
{
    public class NodeFlagsConverter : Mech3DotNet.Json.Converters.StructConverter<Mech3DotNet.Json.Gamez.Nodes.NodeFlags>
    {
        protected override Mech3DotNet.Json.Gamez.Nodes.NodeFlags ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var altitudeSurfaceField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var intersectSurfaceField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var intersectBboxField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var landmarkField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var unk08Field = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var hasMeshField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var unk10Field = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var terrainField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var canModifyField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var clipToField = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var unk25Field = new Mech3DotNet.Json.Converters.Option<bool>(false);
            var unk28Field = new Mech3DotNet.Json.Converters.Option<bool>(false);
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "altitude_surface":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            altitudeSurfaceField.Set(__value);
                            break;
                        }
                    case "intersect_surface":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            intersectSurfaceField.Set(__value);
                            break;
                        }
                    case "intersect_bbox":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            intersectBboxField.Set(__value);
                            break;
                        }
                    case "landmark":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            landmarkField.Set(__value);
                            break;
                        }
                    case "unk08":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk08Field.Set(__value);
                            break;
                        }
                    case "has_mesh":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            hasMeshField.Set(__value);
                            break;
                        }
                    case "unk10":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk10Field.Set(__value);
                            break;
                        }
                    case "terrain":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            terrainField.Set(__value);
                            break;
                        }
                    case "can_modify":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            canModifyField.Set(__value);
                            break;
                        }
                    case "clip_to":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            clipToField.Set(__value);
                            break;
                        }
                    case "unk25":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk25Field.Set(__value);
                            break;
                        }
                    case "unk28":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            unk28Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'NodeFlags'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var altitudeSurface = altitudeSurfaceField.Unwrap("altitude_surface");
            var intersectSurface = intersectSurfaceField.Unwrap("intersect_surface");
            var intersectBbox = intersectBboxField.Unwrap("intersect_bbox");
            var landmark = landmarkField.Unwrap("landmark");
            var unk08 = unk08Field.Unwrap("unk08");
            var hasMesh = hasMeshField.Unwrap("has_mesh");
            var unk10 = unk10Field.Unwrap("unk10");
            var terrain = terrainField.Unwrap("terrain");
            var canModify = canModifyField.Unwrap("can_modify");
            var clipTo = clipToField.Unwrap("clip_to");
            var unk25 = unk25Field.Unwrap("unk25");
            var unk28 = unk28Field.Unwrap("unk28");
            return new Mech3DotNet.Json.Gamez.Nodes.NodeFlags(altitudeSurface, intersectSurface, intersectBbox, landmark, unk08, hasMesh, unk10, terrain, canModify, clipTo, unk25, unk28);
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Gamez.Nodes.NodeFlags value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value.altitudeSurface != false)
            {
                writer.WritePropertyName("altitude_surface");
                JsonSerializer.Serialize(writer, value.altitudeSurface, options);
            }
            if (value.intersectSurface != false)
            {
                writer.WritePropertyName("intersect_surface");
                JsonSerializer.Serialize(writer, value.intersectSurface, options);
            }
            if (value.intersectBbox != false)
            {
                writer.WritePropertyName("intersect_bbox");
                JsonSerializer.Serialize(writer, value.intersectBbox, options);
            }
            if (value.landmark != false)
            {
                writer.WritePropertyName("landmark");
                JsonSerializer.Serialize(writer, value.landmark, options);
            }
            if (value.unk08 != false)
            {
                writer.WritePropertyName("unk08");
                JsonSerializer.Serialize(writer, value.unk08, options);
            }
            if (value.hasMesh != false)
            {
                writer.WritePropertyName("has_mesh");
                JsonSerializer.Serialize(writer, value.hasMesh, options);
            }
            if (value.unk10 != false)
            {
                writer.WritePropertyName("unk10");
                JsonSerializer.Serialize(writer, value.unk10, options);
            }
            if (value.terrain != false)
            {
                writer.WritePropertyName("terrain");
                JsonSerializer.Serialize(writer, value.terrain, options);
            }
            if (value.canModify != false)
            {
                writer.WritePropertyName("can_modify");
                JsonSerializer.Serialize(writer, value.canModify, options);
            }
            if (value.clipTo != false)
            {
                writer.WritePropertyName("clip_to");
                JsonSerializer.Serialize(writer, value.clipTo, options);
            }
            if (value.unk25 != false)
            {
                writer.WritePropertyName("unk25");
                JsonSerializer.Serialize(writer, value.unk25, options);
            }
            if (value.unk28 != false)
            {
                writer.WritePropertyName("unk28");
                JsonSerializer.Serialize(writer, value.unk28, options);
            }
            writer.WriteEndObject();
        }
    }
}
