using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    public enum EventDataVariant
    {
        Sound,
        SoundNode,
        LightState,
        LightAnimation,
        ObjectActiveState,
        ObjectTranslateState,
        ObjectScaleState,
        ObjectRotateState,
        ObjectMotion,
        ObjectMotionFromTo,
        ObjectMotionSIScript,
        ObjectOpacityState,
        ObjectOpacityFromTo,
        ObjectAddChild,
        ObjectCycleTexture,
        ObjectConnector,
        CallObjectConnector,
        CallSequence,
        StopSequence,
        CallAnimation,
        StopAnimation,
        ResetAnimation,
        InvalidateAnimation,
        FogState,
        Loop,
        If,
        Else,
        Elif,
        Endif,
        Callback,
        FrameBufferEffectColorFromTo,
        DetonateWeapon,
        PufferState,
    }

    [JsonConverter(typeof(EventDataConverter))]
    public class EventData : IDiscriminatedUnion<EventDataVariant>
    {
        public EventData(Sound value)
        {
            this.value = value;
            Variant = EventDataVariant.Sound;
        }

        public EventData(SoundNode value)
        {
            this.value = value;
            Variant = EventDataVariant.SoundNode;
        }

        public EventData(LightState value)
        {
            this.value = value;
            Variant = EventDataVariant.LightState;
        }

        public EventData(LightAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.LightAnimation;
        }

        public EventData(ObjectActiveState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectActiveState;
        }

        public EventData(ObjectTranslateState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectTranslateState;
        }

        public EventData(ObjectScaleState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectScaleState;
        }

        public EventData(ObjectRotateState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectRotateState;
        }

        public EventData(ObjectMotion value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectMotion;
        }

        public EventData(ObjectMotionFromTo value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectMotionFromTo;
        }

        public EventData(ObjectMotionSiScript value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectMotionSIScript;
        }

        public EventData(ObjectOpacityState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectOpacityState;
        }

        public EventData(ObjectOpacityFromTo value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectOpacityFromTo;
        }

        public EventData(ObjectAddChild value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectAddChild;
        }

        public EventData(ObjectCycleTexture value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectCycleTexture;
        }

        public EventData(ObjectConnector value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectConnector;
        }

        public EventData(CallObjectConnector value)
        {
            this.value = value;
            Variant = EventDataVariant.CallObjectConnector;
        }

        public EventData(CallSequence value)
        {
            this.value = value;
            Variant = EventDataVariant.CallSequence;
        }

        public EventData(StopSequence value)
        {
            this.value = value;
            Variant = EventDataVariant.StopSequence;
        }

        public EventData(CallAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.CallAnimation;
        }

        public EventData(StopAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.StopAnimation;
        }

        public EventData(ResetAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.ResetAnimation;
        }

        public EventData(InvalidateAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.InvalidateAnimation;
        }

        public EventData(FogState value)
        {
            this.value = value;
            Variant = EventDataVariant.FogState;
        }

        public EventData(Loop value)
        {
            this.value = value;
            Variant = EventDataVariant.Loop;
        }

        public EventData(If value)
        {
            this.value = value;
            Variant = EventDataVariant.If;
        }

        public EventData(Else value)
        {
            this.value = value;
            Variant = EventDataVariant.Else;
        }

        public EventData(ElseIf value)
        {
            this.value = value;
            Variant = EventDataVariant.Elif;
        }

        public EventData(EndIf value)
        {
            this.value = value;
            Variant = EventDataVariant.Endif;
        }

        public EventData(Callback value)
        {
            this.value = value;
            Variant = EventDataVariant.Callback;
        }

        public EventData(FrameBufferEffectColor value)
        {
            this.value = value;
            Variant = EventDataVariant.FrameBufferEffectColorFromTo;
        }

        public EventData(DetonateWeapon value)
        {
            this.value = value;
            Variant = EventDataVariant.DetonateWeapon;
        }

        public EventData(PufferState value)
        {
            this.value = value;
            Variant = EventDataVariant.PufferState;
        }

        protected object value;
        public EventDataVariant Variant { get; protected set; }
        public bool Is<T>() { return typeof(T).IsInstanceOfType(value); }
        public T As<T>() { return (T)value; }
        public object GetValue() { return value; }
    }
}
