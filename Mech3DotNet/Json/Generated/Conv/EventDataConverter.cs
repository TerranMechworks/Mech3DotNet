using System.Text.Json;

namespace Mech3DotNet.Json.Anim.Events.Converters
{
    public class EventDataConverter : Mech3DotNet.Json.Converters.UnionConverter<Mech3DotNet.Json.Anim.Events.EventData>
    {
        public override Mech3DotNet.Json.Anim.Events.EventData ReadUnitVariant(string? name)
        {
            switch (name)
            {
                case "Sound":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Sound' for 'EventData'");
                        throw new JsonException();
                    }
                case "SoundNode":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'SoundNode' for 'EventData'");
                        throw new JsonException();
                    }
                case "LightState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'LightState' for 'EventData'");
                        throw new JsonException();
                    }
                case "LightAnimation":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'LightAnimation' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectActiveState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectActiveState' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectTranslateState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectTranslateState' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectScaleState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectScaleState' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectRotateState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectRotateState' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectMotion":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectMotion' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectMotionFromTo":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectMotionFromTo' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectMotionSIScript":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectMotionSIScript' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectOpacityState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectOpacityState' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectOpacityFromTo":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectOpacityFromTo' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectAddChild":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectAddChild' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectCycleTexture":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectCycleTexture' for 'EventData'");
                        throw new JsonException();
                    }
                case "ObjectConnector":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ObjectConnector' for 'EventData'");
                        throw new JsonException();
                    }
                case "CallObjectConnector":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'CallObjectConnector' for 'EventData'");
                        throw new JsonException();
                    }
                case "CallSequence":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'CallSequence' for 'EventData'");
                        throw new JsonException();
                    }
                case "StopSequence":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'StopSequence' for 'EventData'");
                        throw new JsonException();
                    }
                case "CallAnimation":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'CallAnimation' for 'EventData'");
                        throw new JsonException();
                    }
                case "StopAnimation":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'StopAnimation' for 'EventData'");
                        throw new JsonException();
                    }
                case "ResetAnimation":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'ResetAnimation' for 'EventData'");
                        throw new JsonException();
                    }
                case "InvalidateAnimation":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'InvalidateAnimation' for 'EventData'");
                        throw new JsonException();
                    }
                case "FogState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'FogState' for 'EventData'");
                        throw new JsonException();
                    }
                case "Loop":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Loop' for 'EventData'");
                        throw new JsonException();
                    }
                case "If":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'If' for 'EventData'");
                        throw new JsonException();
                    }
                case "Else":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Else' for 'EventData'");
                        throw new JsonException();
                    }
                case "Elif":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Elif' for 'EventData'");
                        throw new JsonException();
                    }
                case "Endif":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Endif' for 'EventData'");
                        throw new JsonException();
                    }
                case "Callback":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'Callback' for 'EventData'");
                        throw new JsonException();
                    }
                case "FrameBufferEffectColorFromTo":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'FrameBufferEffectColorFromTo' for 'EventData'");
                        throw new JsonException();
                    }
                case "DetonateWeapon":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'DetonateWeapon' for 'EventData'");
                        throw new JsonException();
                    }
                case "PufferState":
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid unit variant 'PufferState' for 'EventData'");
                        throw new JsonException();
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'EventData'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'EventData'");
                        throw new JsonException();
                    }
            }
        }

        public override Mech3DotNet.Json.Anim.Events.EventData ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Sound":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.Sound>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Sound' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "SoundNode":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.SoundNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'SoundNode' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "LightState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.LightState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'LightState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "LightAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.LightAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'LightAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectActiveState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectActiveState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectActiveState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectTranslateState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectTranslateState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectTranslateState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectScaleState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectScaleState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectScaleState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectRotateState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectRotateState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectRotateState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectMotion":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectMotion>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectMotion' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectMotionFromTo":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectMotionFromTo>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectMotionFromTo' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectMotionSIScript":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectMotionSIScript' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectOpacityState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectOpacityState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectOpacityState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectOpacityFromTo":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectOpacityFromTo>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectOpacityFromTo' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectAddChild":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectAddChild>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectAddChild' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectCycleTexture":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectCycleTexture>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectCycleTexture' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ObjectConnector":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ObjectConnector>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectConnector' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "CallObjectConnector":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.CallObjectConnector>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'CallObjectConnector' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "CallSequence":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.CallSequence>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'CallSequence' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "StopSequence":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.StopSequence>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'StopSequence' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "CallAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.CallAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'CallAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "StopAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.StopAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'StopAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "ResetAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ResetAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ResetAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "InvalidateAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.InvalidateAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'InvalidateAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "FogState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.FogState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'FogState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "Loop":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.Loop>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Loop' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "If":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.If>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'If' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "Else":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.Else>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Else' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "Elif":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.ElseIf>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Elif' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "Endif":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.EndIf>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Endif' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "Callback":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.Callback>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Callback' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "FrameBufferEffectColorFromTo":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'FrameBufferEffectColorFromTo' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "DetonateWeapon":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.DetonateWeapon>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'DetonateWeapon' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case "PufferState":
                    {
                        var inner = JsonSerializer.Deserialize<Mech3DotNet.Json.Anim.Events.PufferState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'PufferState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new Mech3DotNet.Json.Anim.Events.EventData(inner);
                    }
                case null:
                    {
                        System.Diagnostics.Debug.WriteLine("Variant cannot be null for 'EventData'");
                        throw new JsonException();
                    }
                default:
                    {
                        System.Diagnostics.Debug.WriteLine($"Invalid variant '{name}' for 'EventData'");
                        throw new JsonException();
                    }
            }
        }

        public override void Write(Utf8JsonWriter writer, Mech3DotNet.Json.Anim.Events.EventData value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.Sound:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.Sound>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Sound");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.SoundNode:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.SoundNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("SoundNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.LightState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.LightState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("LightState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.LightAnimation:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.LightAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("LightAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectActiveState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectActiveState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectActiveState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectTranslateState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectTranslateState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectTranslateState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectScaleState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectScaleState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectScaleState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectRotateState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectRotateState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectRotateState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectMotion:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectMotion>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectMotion");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectMotionFromTo:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectMotionFromTo>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectMotionFromTo");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectMotionSIScript:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectMotionSIScript");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectOpacityState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectOpacityState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectOpacityState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectOpacityFromTo:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectOpacityFromTo>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectOpacityFromTo");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectAddChild:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectAddChild>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectAddChild");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectCycleTexture:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectCycleTexture>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectCycleTexture");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ObjectConnector:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ObjectConnector>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectConnector");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.CallObjectConnector:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.CallObjectConnector>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("CallObjectConnector");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.CallSequence:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.CallSequence>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("CallSequence");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.StopSequence:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.StopSequence>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("StopSequence");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.CallAnimation:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.CallAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("CallAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.StopAnimation:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.StopAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("StopAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.ResetAnimation:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ResetAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ResetAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.InvalidateAnimation:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.InvalidateAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("InvalidateAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.FogState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.FogState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("FogState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.Loop:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.Loop>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Loop");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.If:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.If>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("If");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.Else:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.Else>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Else");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.Elif:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.ElseIf>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Elif");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.Endif:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.EndIf>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Endif");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.Callback:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.Callback>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Callback");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.FrameBufferEffectColorFromTo:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("FrameBufferEffectColorFromTo");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.DetonateWeapon:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.DetonateWeapon>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("DetonateWeapon");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case Mech3DotNet.Json.Anim.Events.EventDataVariant.PufferState:
                    {
                        var inner = value.As<Mech3DotNet.Json.Anim.Events.PufferState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PufferState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new System.ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'EventData'");
            }
        }
    }
}
