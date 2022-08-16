using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class MatrixConverter : StructConverter<Matrix>
    {
        protected override Matrix ReadStruct(ref Utf8JsonReader __reader, JsonSerializerOptions __options)
        {
            var aField = new Option<float>();
            var bField = new Option<float>();
            var cField = new Option<float>();
            var dField = new Option<float>();
            var eField = new Option<float>();
            var fField = new Option<float>();
            var gField = new Option<float>();
            var hField = new Option<float>();
            var iField = new Option<float>();
            string? __fieldName = null;
            while (ReadFieldName(ref __reader, out __fieldName))
            {
                switch (__fieldName)
                {
                    case "a":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            aField.Set(__value);
                            break;
                        }
                    case "b":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            bField.Set(__value);
                            break;
                        }
                    case "c":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            cField.Set(__value);
                            break;
                        }
                    case "d":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            dField.Set(__value);
                            break;
                        }
                    case "e":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            eField.Set(__value);
                            break;
                        }
                    case "f":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            fField.Set(__value);
                            break;
                        }
                    case "g":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            gField.Set(__value);
                            break;
                        }
                    case "h":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            hField.Set(__value);
                            break;
                        }
                    case "i":
                        {
                            float __value = ReadFieldValue<float>(ref __reader, __options);
                            iField.Set(__value);
                            break;
                        }
                    default:
                        {
                            System.Diagnostics.Debug.WriteLine($"Invalid field '{__fieldName}' for 'Matrix'");
                            throw new JsonException();
                        }
                }
            }
            // pray there are no naming collisions
            var a = aField.Unwrap("a");
            var b = bField.Unwrap("b");
            var c = cField.Unwrap("c");
            var d = dField.Unwrap("d");
            var e = eField.Unwrap("e");
            var f = fField.Unwrap("f");
            var g = gField.Unwrap("g");
            var h = hField.Unwrap("h");
            var i = iField.Unwrap("i");
            return new Matrix(a, b, c, d, e, f, g, h, i);
        }

        public override void Write(Utf8JsonWriter writer, Matrix value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("a");
            JsonSerializer.Serialize(writer, value.a, options);
            writer.WritePropertyName("b");
            JsonSerializer.Serialize(writer, value.b, options);
            writer.WritePropertyName("c");
            JsonSerializer.Serialize(writer, value.c, options);
            writer.WritePropertyName("d");
            JsonSerializer.Serialize(writer, value.d, options);
            writer.WritePropertyName("e");
            JsonSerializer.Serialize(writer, value.e, options);
            writer.WritePropertyName("f");
            JsonSerializer.Serialize(writer, value.f, options);
            writer.WritePropertyName("g");
            JsonSerializer.Serialize(writer, value.g, options);
            writer.WritePropertyName("h");
            JsonSerializer.Serialize(writer, value.h, options);
            writer.WritePropertyName("i");
            JsonSerializer.Serialize(writer, value.i, options);
            writer.WriteEndObject();
        }
    }
}