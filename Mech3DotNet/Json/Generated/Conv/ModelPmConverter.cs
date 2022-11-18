using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ModelPmConverter : Mech3DotNet.Json.Converters.StructConverter<ModelPm>
    {
        protected override ModelPm ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nodesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<NodePm>>();
            var meshesField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<MeshNg>>();
            var meshPtrsField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<int>>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "nodes":
                        {
                            System.Collections.Generic.List<NodePm>? __value = ReadFieldValue<System.Collections.Generic.List<NodePm>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'nodes' was null for 'ModelPm'");
                                throw new JsonException();
                            }
                            nodesField.Set(__value);
                            break;
                        }
                    case "meshes":
                        {
                            System.Collections.Generic.List<MeshNg>? __value = ReadFieldValue<System.Collections.Generic.List<MeshNg>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'meshes' was null for 'ModelPm'");
                                throw new JsonException();
                            }
                            meshesField.Set(__value);
                            break;
                        }
                    case "mesh_ptrs":
                        {
                            System.Collections.Generic.List<int>? __value = ReadFieldValue<System.Collections.Generic.List<int>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'mesh_ptrs' was null for 'ModelPm'");
                                throw new JsonException();
                            }
                            meshPtrsField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ModelPm'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var nodes = nodesField.Unwrap("nodes");
            var meshes = meshesField.Unwrap("meshes");
            var meshPtrs = meshPtrsField.Unwrap("mesh_ptrs");
            return new ModelPm(nodes, meshes, meshPtrs);
        }

        public override void Write(Utf8JsonWriter writer, ModelPm value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("nodes");
            JsonSerializer.Serialize(writer, value.nodes, options);
            writer.WritePropertyName("meshes");
            JsonSerializer.Serialize(writer, value.meshes, options);
            writer.WritePropertyName("mesh_ptrs");
            JsonSerializer.Serialize(writer, value.meshPtrs, options);
            writer.WriteEndObject();
        }
    }
}
