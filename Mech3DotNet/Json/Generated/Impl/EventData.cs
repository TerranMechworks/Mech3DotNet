namespace Mech3DotNet.Json.Anim.Events
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

    [System.Text.Json.Serialization.JsonConverter(typeof(Mech3DotNet.Json.Anim.Events.Converters.EventDataConverter))]
    public class EventData : Mech3DotNet.Json.Converters.IDiscriminatedUnion<EventDataVariant>
    {
        public EventData(Mech3DotNet.Json.Anim.Events.Sound value)
        {
            this.value = value;
            Variant = EventDataVariant.Sound;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.SoundNode value)
        {
            this.value = value;
            Variant = EventDataVariant.SoundNode;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.LightState value)
        {
            this.value = value;
            Variant = EventDataVariant.LightState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.LightAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.LightAnimation;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectActiveState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectActiveState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectTranslateState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectTranslateState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectScaleState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectScaleState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectRotateState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectRotateState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectMotion value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectMotion;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectMotionFromTo value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectMotionFromTo;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectMotionSiScript value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectMotionSIScript;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectOpacityState value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectOpacityState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectOpacityFromTo value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectOpacityFromTo;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectAddChild value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectAddChild;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectCycleTexture value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectCycleTexture;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ObjectConnector value)
        {
            this.value = value;
            Variant = EventDataVariant.ObjectConnector;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.CallObjectConnector value)
        {
            this.value = value;
            Variant = EventDataVariant.CallObjectConnector;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.CallSequence value)
        {
            this.value = value;
            Variant = EventDataVariant.CallSequence;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.StopSequence value)
        {
            this.value = value;
            Variant = EventDataVariant.StopSequence;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.CallAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.CallAnimation;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.StopAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.StopAnimation;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ResetAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.ResetAnimation;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.InvalidateAnimation value)
        {
            this.value = value;
            Variant = EventDataVariant.InvalidateAnimation;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.FogState value)
        {
            this.value = value;
            Variant = EventDataVariant.FogState;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.Loop value)
        {
            this.value = value;
            Variant = EventDataVariant.Loop;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.If value)
        {
            this.value = value;
            Variant = EventDataVariant.If;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.Else value)
        {
            this.value = value;
            Variant = EventDataVariant.Else;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.ElseIf value)
        {
            this.value = value;
            Variant = EventDataVariant.Elif;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.EndIf value)
        {
            this.value = value;
            Variant = EventDataVariant.Endif;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.Callback value)
        {
            this.value = value;
            Variant = EventDataVariant.Callback;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.FrameBufferEffectColor value)
        {
            this.value = value;
            Variant = EventDataVariant.FrameBufferEffectColorFromTo;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.DetonateWeapon value)
        {
            this.value = value;
            Variant = EventDataVariant.DetonateWeapon;
        }

        public EventData(Mech3DotNet.Json.Anim.Events.PufferState value)
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
