using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class LodPmConverter : Mech3DotNet.Json.Converters.StructConverter<LodPm>
    {
        protected override LodPm ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Mech3DotNet.Json.Converters.Option<string>();
            var levelField = new Mech3DotNet.Json.Converters.Option<bool>();
            var rangeField = new Mech3DotNet.Json.Converters.Option<Range>();
            var unk64Field = new Mech3DotNet.Json.Converters.Option<float>();
            var unk72Field = new Mech3DotNet.Json.Converters.Option<float>();
            var parentField = new Mech3DotNet.Json.Converters.Option<uint>();
            var childrenField = new Mech3DotNet.Json.Converters.Option<System.Collections.Generic.List<uint>>();
            var dataPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var parentArrayPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var childrenArrayPtrField = new Mech3DotNet.Json.Converters.Option<uint>();
            var unk164Field = new Mech3DotNet.Json.Converters.Option<BoundingBox>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'LodPm'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "level":
                        {
                            bool __value = ReadFieldValue<bool>(ref __reader, __options);
                            levelField.Set(__value);
                            break;
                        }
                    case "range":
                        {
                            Range __value = ReadFieldValue<Range>(ref __reader, __options);
                            rangeField.Set(__value);
                            break;
                        }
                    case "unk64":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk64Field.Set(__value);
                            break;
                        }
                    case "unk72":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            unk72Field.Set(__value);
                            break;
                        }
                    case "parent":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentField.Set(__value);
                            break;
                        }
                    case "children":
                        {
                            System.Collections.Generic.List<uint>? __value = ReadFieldValue<System.Collections.Generic.List<uint>?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'children' was null for 'LodPm'");
                                throw new JsonException();
                            }
                            childrenField.Set(__value);
                            break;
                        }
                    case "data_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            dataPtrField.Set(__value);
                            break;
                        }
                    case "parent_array_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            parentArrayPtrField.Set(__value);
                            break;
                        }
                    case "children_array_ptr":
                        {
                            uint __value = ReadFieldValue<uint>(ref __reader, __options);
                            childrenArrayPtrField.Set(__value);
                            break;
                        }
                    case "unk164":
                        {
                            BoundingBox? __value = ReadFieldValue<BoundingBox?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'unk164' was null for 'LodPm'");
                                throw new JsonException();
                            }
                            unk164Field.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'LodPm'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var level = levelField.Unwrap("level");
            var range = rangeField.Unwrap("range");
            var unk64 = unk64Field.Unwrap("unk64");
            var unk72 = unk72Field.Unwrap("unk72");
            var parent = parentField.Unwrap("parent");
            var children = childrenField.Unwrap("children");
            var dataPtr = dataPtrField.Unwrap("data_ptr");
            var parentArrayPtr = parentArrayPtrField.Unwrap("parent_array_ptr");
            var childrenArrayPtr = childrenArrayPtrField.Unwrap("children_array_ptr");
            var unk164 = unk164Field.Unwrap("unk164");
            return new LodPm(name, level, range, unk64, unk72, parent, children, dataPtr, parentArrayPtr, childrenArrayPtr, unk164);
        }

        public override void Write(Utf8JsonWriter writer, LodPm value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            writer.WritePropertyName("level");
            JsonSerializer.Serialize(writer, value.level, options);
            writer.WritePropertyName("range");
            JsonSerializer.Serialize(writer, value.range, options);
            writer.WritePropertyName("unk64");
            JsonSerializer.Serialize(writer, value.unk64, options);
            writer.WritePropertyName("unk72");
            JsonSerializer.Serialize(writer, value.unk72, options);
            writer.WritePropertyName("parent");
            JsonSerializer.Serialize(writer, value.parent, options);
            writer.WritePropertyName("children");
            JsonSerializer.Serialize(writer, value.children, options);
            writer.WritePropertyName("data_ptr");
            JsonSerializer.Serialize(writer, value.dataPtr, options);
            writer.WritePropertyName("parent_array_ptr");
            JsonSerializer.Serialize(writer, value.parentArrayPtr, options);
            writer.WritePropertyName("children_array_ptr");
            JsonSerializer.Serialize(writer, value.childrenArrayPtr, options);
            writer.WritePropertyName("unk164");
            JsonSerializer.Serialize(writer, value.unk164, options);
            writer.WriteEndObject();
        }
    }
}
