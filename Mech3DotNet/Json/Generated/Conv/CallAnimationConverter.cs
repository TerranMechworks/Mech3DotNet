using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class CallAnimationConverter : StructConverter<CallAnimation>
    {
        protected override CallAnimation ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var nameField = new Option<string>();
            var waitForCompletionField = new Option<ushort?>(null);
            var parametersField = new Option<CallAnimationParameters>();
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
                                System.Diagnostics.Debug.WriteLine("Value of 'name' was null for 'CallAnimation'");
                                throw new JsonException();
                            }
                            nameField.Set(__value);
                            break;
                        }
                    case "wait_for_completion":
                        {
                            ushort? __value = ReadFieldValue<ushort?>(ref __reader, __options);
                            waitForCompletionField.Set(__value);
                            break;
                        }
                    case "parameters":
                        {
                            CallAnimationParameters? __value = ReadFieldValue<CallAnimationParameters?>(ref __reader, __options);
                            if (__value is null)
                            {
                                System.Diagnostics.Debug.WriteLine("Value of 'parameters' was null for 'CallAnimation'");
                                throw new JsonException();
                            }
                            parametersField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'CallAnimation'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var name = nameField.Unwrap("name");
            var waitForCompletion = waitForCompletionField.Unwrap("wait_for_completion");
            var parameters = parametersField.Unwrap("parameters");
            return new CallAnimation(name, waitForCompletion, parameters);
        }

        public override void Write(Utf8JsonWriter writer, CallAnimation value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("name");
            JsonSerializer.Serialize(writer, value.name, options);
            if (value.waitForCompletion != null)
            {
                writer.WritePropertyName("wait_for_completion");
                JsonSerializer.Serialize(writer, value.waitForCompletion, options);
            }
            writer.WritePropertyName("parameters");
            JsonSerializer.Serialize(writer, value.parameters, options);
            writer.WriteEndObject();
        }
    }
}
