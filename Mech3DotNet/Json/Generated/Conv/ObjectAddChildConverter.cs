using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class ObjectAddChildConverter : StructConverter<ObjectAddChild>
    {
        protected override ObjectAddChild ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var parentField = new Option<string>();
            var childField = new Option<string>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "parent":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'parent' was null for 'ObjectAddChild'");
                                throw new JsonException();
                            }
                            parentField.Set(__value);
                            break;
                        }
                    case "child":
                        {
                            string? __value = ReadFieldValue<string?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'child' was null for 'ObjectAddChild'");
                                throw new JsonException();
                            }
                            childField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'ObjectAddChild'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var parent = parentField.Unwrap("parent");
            var child = childField.Unwrap("child");
            return new ObjectAddChild(parent, child);
        }

        public override void Write(Utf8JsonWriter writer, ObjectAddChild value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("parent");
            JsonSerializer.Serialize(writer, value.parent, options);
            writer.WritePropertyName("child");
            JsonSerializer.Serialize(writer, value.child, options);
            writer.WriteEndObject();
        }
    }
}
