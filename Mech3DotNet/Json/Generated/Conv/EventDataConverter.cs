using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json;

namespace Mech3DotNet.Json.Converters
{
    public class EventDataConverter : UnionConverter<EventData>
    {
        public override EventData ReadUnitVariant(string? name)
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

        public override EventData ReadStructVariant(ref Utf8JsonReader reader, string? name, JsonSerializerOptions options)
        {
            switch (name)
            {
                case "Sound":
                    {
                        var inner = JsonSerializer.Deserialize<Sound>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Sound' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "SoundNode":
                    {
                        var inner = JsonSerializer.Deserialize<SoundNode>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'SoundNode' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "LightState":
                    {
                        var inner = JsonSerializer.Deserialize<LightState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'LightState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "LightAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<LightAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'LightAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectActiveState":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectActiveState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectActiveState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectTranslateState":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectTranslateState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectTranslateState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectScaleState":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectScaleState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectScaleState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectRotateState":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectRotateState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectRotateState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectMotion":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectMotion>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectMotion' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectMotionFromTo":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectMotionFromTo>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectMotionFromTo' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectMotionSIScript":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectMotionSiScript>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectMotionSIScript' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectOpacityState":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectOpacityState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectOpacityState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectOpacityFromTo":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectOpacityFromTo>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectOpacityFromTo' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectAddChild":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectAddChild>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectAddChild' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectCycleTexture":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectCycleTexture>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectCycleTexture' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ObjectConnector":
                    {
                        var inner = JsonSerializer.Deserialize<ObjectConnector>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ObjectConnector' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "CallObjectConnector":
                    {
                        var inner = JsonSerializer.Deserialize<CallObjectConnector>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'CallObjectConnector' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "CallSequence":
                    {
                        var inner = JsonSerializer.Deserialize<CallSequence>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'CallSequence' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "StopSequence":
                    {
                        var inner = JsonSerializer.Deserialize<StopSequence>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'StopSequence' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "CallAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<CallAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'CallAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "StopAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<StopAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'StopAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "ResetAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<ResetAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'ResetAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "InvalidateAnimation":
                    {
                        var inner = JsonSerializer.Deserialize<InvalidateAnimation>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'InvalidateAnimation' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "FogState":
                    {
                        var inner = JsonSerializer.Deserialize<FogState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'FogState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "Loop":
                    {
                        var inner = JsonSerializer.Deserialize<Loop>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Loop' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "If":
                    {
                        var inner = JsonSerializer.Deserialize<If>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'If' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "Else":
                    {
                        var inner = JsonSerializer.Deserialize<Else>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Else' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "Elif":
                    {
                        var inner = JsonSerializer.Deserialize<ElseIf>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Elif' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "Endif":
                    {
                        var inner = JsonSerializer.Deserialize<EndIf>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Endif' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "Callback":
                    {
                        var inner = JsonSerializer.Deserialize<Callback>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'Callback' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "FrameBufferEffectColorFromTo":
                    {
                        var inner = JsonSerializer.Deserialize<FrameBufferEffectColor>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'FrameBufferEffectColorFromTo' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "DetonateWeapon":
                    {
                        var inner = JsonSerializer.Deserialize<DetonateWeapon>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'DetonateWeapon' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
                    }
                case "PufferState":
                    {
                        var inner = JsonSerializer.Deserialize<PufferState>(ref reader, options);
                        if (inner is null)
                        {
                            System.Diagnostics.Debug.WriteLine("Value of 'PufferState' was null for 'EventData'");
                            throw new JsonException();
                        }
                        return new EventData(inner);
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

        public override void Write(Utf8JsonWriter writer, EventData value, JsonSerializerOptions options)
        {
            switch (value.Variant)
            {
                case EventDataVariant.Sound:
                    {
                        var inner = value.As<Sound>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Sound");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.SoundNode:
                    {
                        var inner = value.As<SoundNode>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("SoundNode");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.LightState:
                    {
                        var inner = value.As<LightState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("LightState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.LightAnimation:
                    {
                        var inner = value.As<LightAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("LightAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectActiveState:
                    {
                        var inner = value.As<ObjectActiveState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectActiveState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectTranslateState:
                    {
                        var inner = value.As<ObjectTranslateState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectTranslateState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectScaleState:
                    {
                        var inner = value.As<ObjectScaleState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectScaleState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectRotateState:
                    {
                        var inner = value.As<ObjectRotateState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectRotateState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectMotion:
                    {
                        var inner = value.As<ObjectMotion>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectMotion");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectMotionFromTo:
                    {
                        var inner = value.As<ObjectMotionFromTo>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectMotionFromTo");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectMotionSIScript:
                    {
                        var inner = value.As<ObjectMotionSiScript>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectMotionSIScript");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectOpacityState:
                    {
                        var inner = value.As<ObjectOpacityState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectOpacityState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectOpacityFromTo:
                    {
                        var inner = value.As<ObjectOpacityFromTo>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectOpacityFromTo");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectAddChild:
                    {
                        var inner = value.As<ObjectAddChild>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectAddChild");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectCycleTexture:
                    {
                        var inner = value.As<ObjectCycleTexture>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectCycleTexture");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ObjectConnector:
                    {
                        var inner = value.As<ObjectConnector>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ObjectConnector");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.CallObjectConnector:
                    {
                        var inner = value.As<CallObjectConnector>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("CallObjectConnector");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.CallSequence:
                    {
                        var inner = value.As<CallSequence>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("CallSequence");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.StopSequence:
                    {
                        var inner = value.As<StopSequence>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("StopSequence");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.CallAnimation:
                    {
                        var inner = value.As<CallAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("CallAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.StopAnimation:
                    {
                        var inner = value.As<StopAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("StopAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.ResetAnimation:
                    {
                        var inner = value.As<ResetAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("ResetAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.InvalidateAnimation:
                    {
                        var inner = value.As<InvalidateAnimation>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("InvalidateAnimation");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.FogState:
                    {
                        var inner = value.As<FogState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("FogState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.Loop:
                    {
                        var inner = value.As<Loop>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Loop");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.If:
                    {
                        var inner = value.As<If>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("If");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.Else:
                    {
                        var inner = value.As<Else>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Else");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.Elif:
                    {
                        var inner = value.As<ElseIf>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Elif");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.Endif:
                    {
                        var inner = value.As<EndIf>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Endif");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.Callback:
                    {
                        var inner = value.As<Callback>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("Callback");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.FrameBufferEffectColorFromTo:
                    {
                        var inner = value.As<FrameBufferEffectColor>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("FrameBufferEffectColorFromTo");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.DetonateWeapon:
                    {
                        var inner = value.As<DetonateWeapon>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("DetonateWeapon");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                case EventDataVariant.PufferState:
                    {
                        var inner = value.As<PufferState>();
                        writer.WriteStartObject();
                        writer.WritePropertyName("PufferState");
                        JsonSerializer.Serialize(writer, inner, options);
                        writer.WriteEndObject();
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException("Variant", $"Invalid variant '{value.Variant}' for 'EventData'");
            }
        }
    }
}
