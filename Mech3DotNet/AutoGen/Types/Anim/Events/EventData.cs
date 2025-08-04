using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class EventData
    {
        public static readonly TypeConverter<EventData> Converter = new TypeConverter<EventData>(Deserialize, Serialize);

        public enum Variants
        {
            Sound,
            SoundNode,
            Effect,
            LightState,
            LightAnimation,
            ObjectActiveState,
            ObjectTranslateState,
            ObjectScaleState,
            ObjectRotateState,
            ObjectMotion,
            ObjectMotionFromTo,
            ObjectMotionSiScript,
            ObjectOpacityState,
            ObjectOpacityFromTo,
            ObjectAddChild,
            ObjectDeleteChild,
            ObjectCycleTexture,
            ObjectConnector,
            CallObjectConnector,
            CameraState,
            CameraFromTo,
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
            Elseif,
            Endif,
            Callback,
            FbfxColorFromTo,
            FbfxCsinwaveFromTo,
            AnimVerbose,
            DetonateWeapon,
            PufferState,
        }

        private EventData(Variants variant, object value)
        {
            Variant = variant;
            Value = value;
        }
        public static EventData Sound(Mech3DotNet.Types.Anim.Events.Sound value) => new EventData(Variants.Sound, value);

        public static EventData SoundNode(Mech3DotNet.Types.Anim.Events.SoundNode value) => new EventData(Variants.SoundNode, value);

        public static EventData Effect(Mech3DotNet.Types.Anim.Events.Effect value) => new EventData(Variants.Effect, value);

        public static EventData LightState(Mech3DotNet.Types.Anim.Events.LightState value) => new EventData(Variants.LightState, value);

        public static EventData LightAnimation(Mech3DotNet.Types.Anim.Events.LightAnimation value) => new EventData(Variants.LightAnimation, value);

        public static EventData ObjectActiveState(Mech3DotNet.Types.Anim.Events.ObjectActiveState value) => new EventData(Variants.ObjectActiveState, value);

        public static EventData ObjectTranslateState(Mech3DotNet.Types.Anim.Events.ObjectTranslateState value) => new EventData(Variants.ObjectTranslateState, value);

        public static EventData ObjectScaleState(Mech3DotNet.Types.Anim.Events.ObjectScaleState value) => new EventData(Variants.ObjectScaleState, value);

        public static EventData ObjectRotateState(Mech3DotNet.Types.Anim.Events.ObjectRotateState value) => new EventData(Variants.ObjectRotateState, value);

        public static EventData ObjectMotion(Mech3DotNet.Types.Anim.Events.ObjectMotion value) => new EventData(Variants.ObjectMotion, value);

        public static EventData ObjectMotionFromTo(Mech3DotNet.Types.Anim.Events.ObjectMotionFromTo value) => new EventData(Variants.ObjectMotionFromTo, value);

        public static EventData ObjectMotionSiScript(Mech3DotNet.Types.Anim.Events.ObjectMotionSiScript value) => new EventData(Variants.ObjectMotionSiScript, value);

        public static EventData ObjectOpacityState(Mech3DotNet.Types.Anim.Events.ObjectOpacityState value) => new EventData(Variants.ObjectOpacityState, value);

        public static EventData ObjectOpacityFromTo(Mech3DotNet.Types.Anim.Events.ObjectOpacityFromTo value) => new EventData(Variants.ObjectOpacityFromTo, value);

        public static EventData ObjectAddChild(Mech3DotNet.Types.Anim.Events.ObjectAddChild value) => new EventData(Variants.ObjectAddChild, value);

        public static EventData ObjectDeleteChild(Mech3DotNet.Types.Anim.Events.ObjectDeleteChild value) => new EventData(Variants.ObjectDeleteChild, value);

        public static EventData ObjectCycleTexture(Mech3DotNet.Types.Anim.Events.ObjectCycleTexture value) => new EventData(Variants.ObjectCycleTexture, value);

        public static EventData ObjectConnector(Mech3DotNet.Types.Anim.Events.ObjectConnector value) => new EventData(Variants.ObjectConnector, value);

        public static EventData CallObjectConnector(Mech3DotNet.Types.Anim.Events.CallObjectConnector value) => new EventData(Variants.CallObjectConnector, value);

        public static EventData CameraState(Mech3DotNet.Types.Anim.Events.CameraState value) => new EventData(Variants.CameraState, value);

        public static EventData CameraFromTo(Mech3DotNet.Types.Anim.Events.CameraFromTo value) => new EventData(Variants.CameraFromTo, value);

        public static EventData CallSequence(Mech3DotNet.Types.Anim.Events.CallSequence value) => new EventData(Variants.CallSequence, value);

        public static EventData StopSequence(Mech3DotNet.Types.Anim.Events.StopSequence value) => new EventData(Variants.StopSequence, value);

        public static EventData CallAnimation(Mech3DotNet.Types.Anim.Events.CallAnimation value) => new EventData(Variants.CallAnimation, value);

        public static EventData StopAnimation(Mech3DotNet.Types.Anim.Events.StopAnimation value) => new EventData(Variants.StopAnimation, value);

        public static EventData ResetAnimation(Mech3DotNet.Types.Anim.Events.ResetAnimation value) => new EventData(Variants.ResetAnimation, value);

        public static EventData InvalidateAnimation(Mech3DotNet.Types.Anim.Events.InvalidateAnimation value) => new EventData(Variants.InvalidateAnimation, value);

        public static EventData FogState(Mech3DotNet.Types.Anim.Events.FogState value) => new EventData(Variants.FogState, value);

        public static EventData Loop(Mech3DotNet.Types.Anim.Events.Loop value) => new EventData(Variants.Loop, value);

        public static EventData If(Mech3DotNet.Types.Anim.Events.If value) => new EventData(Variants.If, value);

        public static EventData Else(Mech3DotNet.Types.Anim.Events.Else value) => new EventData(Variants.Else, value);

        public static EventData Elseif(Mech3DotNet.Types.Anim.Events.Elseif value) => new EventData(Variants.Elseif, value);

        public static EventData Endif(Mech3DotNet.Types.Anim.Events.Endif value) => new EventData(Variants.Endif, value);

        public static EventData Callback(Mech3DotNet.Types.Anim.Events.Callback value) => new EventData(Variants.Callback, value);

        public static EventData FbfxColorFromTo(Mech3DotNet.Types.Anim.Events.FbfxColorFromTo value) => new EventData(Variants.FbfxColorFromTo, value);

        public static EventData FbfxCsinwaveFromTo(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveFromTo value) => new EventData(Variants.FbfxCsinwaveFromTo, value);

        public static EventData AnimVerbose(Mech3DotNet.Types.Anim.Events.AnimVerbose value) => new EventData(Variants.AnimVerbose, value);

        public static EventData DetonateWeapon(Mech3DotNet.Types.Anim.Events.DetonateWeapon value) => new EventData(Variants.DetonateWeapon, value);

        public static EventData PufferState(Mech3DotNet.Types.Anim.Events.PufferState value) => new EventData(Variants.PufferState, value);

        public object Value { get; private set; }
        public Variants Variant { get; private set; }
        public bool IsSound() => Variant == Variants.Sound;
        public Mech3DotNet.Types.Anim.Events.Sound AsSound() => (Mech3DotNet.Types.Anim.Events.Sound)Value;
        public bool IsSoundNode() => Variant == Variants.SoundNode;
        public Mech3DotNet.Types.Anim.Events.SoundNode AsSoundNode() => (Mech3DotNet.Types.Anim.Events.SoundNode)Value;
        public bool IsEffect() => Variant == Variants.Effect;
        public Mech3DotNet.Types.Anim.Events.Effect AsEffect() => (Mech3DotNet.Types.Anim.Events.Effect)Value;
        public bool IsLightState() => Variant == Variants.LightState;
        public Mech3DotNet.Types.Anim.Events.LightState AsLightState() => (Mech3DotNet.Types.Anim.Events.LightState)Value;
        public bool IsLightAnimation() => Variant == Variants.LightAnimation;
        public Mech3DotNet.Types.Anim.Events.LightAnimation AsLightAnimation() => (Mech3DotNet.Types.Anim.Events.LightAnimation)Value;
        public bool IsObjectActiveState() => Variant == Variants.ObjectActiveState;
        public Mech3DotNet.Types.Anim.Events.ObjectActiveState AsObjectActiveState() => (Mech3DotNet.Types.Anim.Events.ObjectActiveState)Value;
        public bool IsObjectTranslateState() => Variant == Variants.ObjectTranslateState;
        public Mech3DotNet.Types.Anim.Events.ObjectTranslateState AsObjectTranslateState() => (Mech3DotNet.Types.Anim.Events.ObjectTranslateState)Value;
        public bool IsObjectScaleState() => Variant == Variants.ObjectScaleState;
        public Mech3DotNet.Types.Anim.Events.ObjectScaleState AsObjectScaleState() => (Mech3DotNet.Types.Anim.Events.ObjectScaleState)Value;
        public bool IsObjectRotateState() => Variant == Variants.ObjectRotateState;
        public Mech3DotNet.Types.Anim.Events.ObjectRotateState AsObjectRotateState() => (Mech3DotNet.Types.Anim.Events.ObjectRotateState)Value;
        public bool IsObjectMotion() => Variant == Variants.ObjectMotion;
        public Mech3DotNet.Types.Anim.Events.ObjectMotion AsObjectMotion() => (Mech3DotNet.Types.Anim.Events.ObjectMotion)Value;
        public bool IsObjectMotionFromTo() => Variant == Variants.ObjectMotionFromTo;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionFromTo AsObjectMotionFromTo() => (Mech3DotNet.Types.Anim.Events.ObjectMotionFromTo)Value;
        public bool IsObjectMotionSiScript() => Variant == Variants.ObjectMotionSiScript;
        public Mech3DotNet.Types.Anim.Events.ObjectMotionSiScript AsObjectMotionSiScript() => (Mech3DotNet.Types.Anim.Events.ObjectMotionSiScript)Value;
        public bool IsObjectOpacityState() => Variant == Variants.ObjectOpacityState;
        public Mech3DotNet.Types.Anim.Events.ObjectOpacityState AsObjectOpacityState() => (Mech3DotNet.Types.Anim.Events.ObjectOpacityState)Value;
        public bool IsObjectOpacityFromTo() => Variant == Variants.ObjectOpacityFromTo;
        public Mech3DotNet.Types.Anim.Events.ObjectOpacityFromTo AsObjectOpacityFromTo() => (Mech3DotNet.Types.Anim.Events.ObjectOpacityFromTo)Value;
        public bool IsObjectAddChild() => Variant == Variants.ObjectAddChild;
        public Mech3DotNet.Types.Anim.Events.ObjectAddChild AsObjectAddChild() => (Mech3DotNet.Types.Anim.Events.ObjectAddChild)Value;
        public bool IsObjectDeleteChild() => Variant == Variants.ObjectDeleteChild;
        public Mech3DotNet.Types.Anim.Events.ObjectDeleteChild AsObjectDeleteChild() => (Mech3DotNet.Types.Anim.Events.ObjectDeleteChild)Value;
        public bool IsObjectCycleTexture() => Variant == Variants.ObjectCycleTexture;
        public Mech3DotNet.Types.Anim.Events.ObjectCycleTexture AsObjectCycleTexture() => (Mech3DotNet.Types.Anim.Events.ObjectCycleTexture)Value;
        public bool IsObjectConnector() => Variant == Variants.ObjectConnector;
        public Mech3DotNet.Types.Anim.Events.ObjectConnector AsObjectConnector() => (Mech3DotNet.Types.Anim.Events.ObjectConnector)Value;
        public bool IsCallObjectConnector() => Variant == Variants.CallObjectConnector;
        public Mech3DotNet.Types.Anim.Events.CallObjectConnector AsCallObjectConnector() => (Mech3DotNet.Types.Anim.Events.CallObjectConnector)Value;
        public bool IsCameraState() => Variant == Variants.CameraState;
        public Mech3DotNet.Types.Anim.Events.CameraState AsCameraState() => (Mech3DotNet.Types.Anim.Events.CameraState)Value;
        public bool IsCameraFromTo() => Variant == Variants.CameraFromTo;
        public Mech3DotNet.Types.Anim.Events.CameraFromTo AsCameraFromTo() => (Mech3DotNet.Types.Anim.Events.CameraFromTo)Value;
        public bool IsCallSequence() => Variant == Variants.CallSequence;
        public Mech3DotNet.Types.Anim.Events.CallSequence AsCallSequence() => (Mech3DotNet.Types.Anim.Events.CallSequence)Value;
        public bool IsStopSequence() => Variant == Variants.StopSequence;
        public Mech3DotNet.Types.Anim.Events.StopSequence AsStopSequence() => (Mech3DotNet.Types.Anim.Events.StopSequence)Value;
        public bool IsCallAnimation() => Variant == Variants.CallAnimation;
        public Mech3DotNet.Types.Anim.Events.CallAnimation AsCallAnimation() => (Mech3DotNet.Types.Anim.Events.CallAnimation)Value;
        public bool IsStopAnimation() => Variant == Variants.StopAnimation;
        public Mech3DotNet.Types.Anim.Events.StopAnimation AsStopAnimation() => (Mech3DotNet.Types.Anim.Events.StopAnimation)Value;
        public bool IsResetAnimation() => Variant == Variants.ResetAnimation;
        public Mech3DotNet.Types.Anim.Events.ResetAnimation AsResetAnimation() => (Mech3DotNet.Types.Anim.Events.ResetAnimation)Value;
        public bool IsInvalidateAnimation() => Variant == Variants.InvalidateAnimation;
        public Mech3DotNet.Types.Anim.Events.InvalidateAnimation AsInvalidateAnimation() => (Mech3DotNet.Types.Anim.Events.InvalidateAnimation)Value;
        public bool IsFogState() => Variant == Variants.FogState;
        public Mech3DotNet.Types.Anim.Events.FogState AsFogState() => (Mech3DotNet.Types.Anim.Events.FogState)Value;
        public bool IsLoop() => Variant == Variants.Loop;
        public Mech3DotNet.Types.Anim.Events.Loop AsLoop() => (Mech3DotNet.Types.Anim.Events.Loop)Value;
        public bool IsIf() => Variant == Variants.If;
        public Mech3DotNet.Types.Anim.Events.If AsIf() => (Mech3DotNet.Types.Anim.Events.If)Value;
        public bool IsElse() => Variant == Variants.Else;
        public Mech3DotNet.Types.Anim.Events.Else AsElse() => (Mech3DotNet.Types.Anim.Events.Else)Value;
        public bool IsElseif() => Variant == Variants.Elseif;
        public Mech3DotNet.Types.Anim.Events.Elseif AsElseif() => (Mech3DotNet.Types.Anim.Events.Elseif)Value;
        public bool IsEndif() => Variant == Variants.Endif;
        public Mech3DotNet.Types.Anim.Events.Endif AsEndif() => (Mech3DotNet.Types.Anim.Events.Endif)Value;
        public bool IsCallback() => Variant == Variants.Callback;
        public Mech3DotNet.Types.Anim.Events.Callback AsCallback() => (Mech3DotNet.Types.Anim.Events.Callback)Value;
        public bool IsFbfxColorFromTo() => Variant == Variants.FbfxColorFromTo;
        public Mech3DotNet.Types.Anim.Events.FbfxColorFromTo AsFbfxColorFromTo() => (Mech3DotNet.Types.Anim.Events.FbfxColorFromTo)Value;
        public bool IsFbfxCsinwaveFromTo() => Variant == Variants.FbfxCsinwaveFromTo;
        public Mech3DotNet.Types.Anim.Events.FbfxCsinwaveFromTo AsFbfxCsinwaveFromTo() => (Mech3DotNet.Types.Anim.Events.FbfxCsinwaveFromTo)Value;
        public bool IsAnimVerbose() => Variant == Variants.AnimVerbose;
        public Mech3DotNet.Types.Anim.Events.AnimVerbose AsAnimVerbose() => (Mech3DotNet.Types.Anim.Events.AnimVerbose)Value;
        public bool IsDetonateWeapon() => Variant == Variants.DetonateWeapon;
        public Mech3DotNet.Types.Anim.Events.DetonateWeapon AsDetonateWeapon() => (Mech3DotNet.Types.Anim.Events.DetonateWeapon)Value;
        public bool IsPufferState() => Variant == Variants.PufferState;
        public Mech3DotNet.Types.Anim.Events.PufferState AsPufferState() => (Mech3DotNet.Types.Anim.Events.PufferState)Value;

        private static void Serialize(EventData v, Serializer s)
        {
            switch (v.Variant)
            {
                case Variants.Sound: // 0
                    {
                        var inner = v.AsSound();
                        s.SerializeNewTypeVariant(0);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Sound.Converter)(inner);
                        break;
                    }

                case Variants.SoundNode: // 1
                    {
                        var inner = v.AsSoundNode();
                        s.SerializeNewTypeVariant(1);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.SoundNode.Converter)(inner);
                        break;
                    }

                case Variants.Effect: // 2
                    {
                        var inner = v.AsEffect();
                        s.SerializeNewTypeVariant(2);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Effect.Converter)(inner);
                        break;
                    }

                case Variants.LightState: // 3
                    {
                        var inner = v.AsLightState();
                        s.SerializeNewTypeVariant(3);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.LightState.Converter)(inner);
                        break;
                    }

                case Variants.LightAnimation: // 4
                    {
                        var inner = v.AsLightAnimation();
                        s.SerializeNewTypeVariant(4);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.LightAnimation.Converter)(inner);
                        break;
                    }

                case Variants.ObjectActiveState: // 5
                    {
                        var inner = v.AsObjectActiveState();
                        s.SerializeNewTypeVariant(5);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectActiveState.Converter)(inner);
                        break;
                    }

                case Variants.ObjectTranslateState: // 6
                    {
                        var inner = v.AsObjectTranslateState();
                        s.SerializeNewTypeVariant(6);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectTranslateState.Converter)(inner);
                        break;
                    }

                case Variants.ObjectScaleState: // 7
                    {
                        var inner = v.AsObjectScaleState();
                        s.SerializeNewTypeVariant(7);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectScaleState.Converter)(inner);
                        break;
                    }

                case Variants.ObjectRotateState: // 8
                    {
                        var inner = v.AsObjectRotateState();
                        s.SerializeNewTypeVariant(8);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectRotateState.Converter)(inner);
                        break;
                    }

                case Variants.ObjectMotion: // 9
                    {
                        var inner = v.AsObjectMotion();
                        s.SerializeNewTypeVariant(9);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotion.Converter)(inner);
                        break;
                    }

                case Variants.ObjectMotionFromTo: // 10
                    {
                        var inner = v.AsObjectMotionFromTo();
                        s.SerializeNewTypeVariant(10);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionFromTo.Converter)(inner);
                        break;
                    }

                case Variants.ObjectMotionSiScript: // 11
                    {
                        var inner = v.AsObjectMotionSiScript();
                        s.SerializeNewTypeVariant(11);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectMotionSiScript.Converter)(inner);
                        break;
                    }

                case Variants.ObjectOpacityState: // 12
                    {
                        var inner = v.AsObjectOpacityState();
                        s.SerializeNewTypeVariant(12);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityState.Converter)(inner);
                        break;
                    }

                case Variants.ObjectOpacityFromTo: // 13
                    {
                        var inner = v.AsObjectOpacityFromTo();
                        s.SerializeNewTypeVariant(13);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityFromTo.Converter)(inner);
                        break;
                    }

                case Variants.ObjectAddChild: // 14
                    {
                        var inner = v.AsObjectAddChild();
                        s.SerializeNewTypeVariant(14);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectAddChild.Converter)(inner);
                        break;
                    }

                case Variants.ObjectDeleteChild: // 15
                    {
                        var inner = v.AsObjectDeleteChild();
                        s.SerializeNewTypeVariant(15);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectDeleteChild.Converter)(inner);
                        break;
                    }

                case Variants.ObjectCycleTexture: // 16
                    {
                        var inner = v.AsObjectCycleTexture();
                        s.SerializeNewTypeVariant(16);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectCycleTexture.Converter)(inner);
                        break;
                    }

                case Variants.ObjectConnector: // 17
                    {
                        var inner = v.AsObjectConnector();
                        s.SerializeNewTypeVariant(17);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ObjectConnector.Converter)(inner);
                        break;
                    }

                case Variants.CallObjectConnector: // 18
                    {
                        var inner = v.AsCallObjectConnector();
                        s.SerializeNewTypeVariant(18);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallObjectConnector.Converter)(inner);
                        break;
                    }

                case Variants.CameraState: // 19
                    {
                        var inner = v.AsCameraState();
                        s.SerializeNewTypeVariant(19);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CameraState.Converter)(inner);
                        break;
                    }

                case Variants.CameraFromTo: // 20
                    {
                        var inner = v.AsCameraFromTo();
                        s.SerializeNewTypeVariant(20);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CameraFromTo.Converter)(inner);
                        break;
                    }

                case Variants.CallSequence: // 21
                    {
                        var inner = v.AsCallSequence();
                        s.SerializeNewTypeVariant(21);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallSequence.Converter)(inner);
                        break;
                    }

                case Variants.StopSequence: // 22
                    {
                        var inner = v.AsStopSequence();
                        s.SerializeNewTypeVariant(22);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.StopSequence.Converter)(inner);
                        break;
                    }

                case Variants.CallAnimation: // 23
                    {
                        var inner = v.AsCallAnimation();
                        s.SerializeNewTypeVariant(23);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimation.Converter)(inner);
                        break;
                    }

                case Variants.StopAnimation: // 24
                    {
                        var inner = v.AsStopAnimation();
                        s.SerializeNewTypeVariant(24);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.StopAnimation.Converter)(inner);
                        break;
                    }

                case Variants.ResetAnimation: // 25
                    {
                        var inner = v.AsResetAnimation();
                        s.SerializeNewTypeVariant(25);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.ResetAnimation.Converter)(inner);
                        break;
                    }

                case Variants.InvalidateAnimation: // 26
                    {
                        var inner = v.AsInvalidateAnimation();
                        s.SerializeNewTypeVariant(26);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.InvalidateAnimation.Converter)(inner);
                        break;
                    }

                case Variants.FogState: // 27
                    {
                        var inner = v.AsFogState();
                        s.SerializeNewTypeVariant(27);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.FogState.Converter)(inner);
                        break;
                    }

                case Variants.Loop: // 28
                    {
                        var inner = v.AsLoop();
                        s.SerializeNewTypeVariant(28);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Loop.Converter)(inner);
                        break;
                    }

                case Variants.If: // 29
                    {
                        var inner = v.AsIf();
                        s.SerializeNewTypeVariant(29);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.If.Converter)(inner);
                        break;
                    }

                case Variants.Else: // 30
                    {
                        var inner = v.AsElse();
                        s.SerializeNewTypeVariant(30);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Else.Converter)(inner);
                        break;
                    }

                case Variants.Elseif: // 31
                    {
                        var inner = v.AsElseif();
                        s.SerializeNewTypeVariant(31);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Elseif.Converter)(inner);
                        break;
                    }

                case Variants.Endif: // 32
                    {
                        var inner = v.AsEndif();
                        s.SerializeNewTypeVariant(32);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Endif.Converter)(inner);
                        break;
                    }

                case Variants.Callback: // 33
                    {
                        var inner = v.AsCallback();
                        s.SerializeNewTypeVariant(33);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.Callback.Converter)(inner);
                        break;
                    }

                case Variants.FbfxColorFromTo: // 34
                    {
                        var inner = v.AsFbfxColorFromTo();
                        s.SerializeNewTypeVariant(34);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.FbfxColorFromTo.Converter)(inner);
                        break;
                    }

                case Variants.FbfxCsinwaveFromTo: // 35
                    {
                        var inner = v.AsFbfxCsinwaveFromTo();
                        s.SerializeNewTypeVariant(35);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveFromTo.Converter)(inner);
                        break;
                    }

                case Variants.AnimVerbose: // 36
                    {
                        var inner = v.AsAnimVerbose();
                        s.SerializeNewTypeVariant(36);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.AnimVerbose.Converter)(inner);
                        break;
                    }

                case Variants.DetonateWeapon: // 37
                    {
                        var inner = v.AsDetonateWeapon();
                        s.SerializeNewTypeVariant(37);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.DetonateWeapon.Converter)(inner);
                        break;
                    }

                case Variants.PufferState: // 38
                    {
                        var inner = v.AsPufferState();
                        s.SerializeNewTypeVariant(38);
                        s.Serialize(Mech3DotNet.Types.Anim.Events.PufferState.Converter)(inner);
                        break;
                    }

                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        private static EventData Deserialize(Deserializer d)
        {
            var (enumType, variantIndex) = d.DeserializeEnum();
            switch (variantIndex)
            {
                case 0: // Sound
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 0, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Sound.Converter)();
                        return EventData.Sound(inner);
                    }

                case 1: // SoundNode
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 1, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.SoundNode.Converter)();
                        return EventData.SoundNode(inner);
                    }

                case 2: // Effect
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 2, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Effect.Converter)();
                        return EventData.Effect(inner);
                    }

                case 3: // LightState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 3, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.LightState.Converter)();
                        return EventData.LightState(inner);
                    }

                case 4: // LightAnimation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 4, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.LightAnimation.Converter)();
                        return EventData.LightAnimation(inner);
                    }

                case 5: // ObjectActiveState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 5, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectActiveState.Converter)();
                        return EventData.ObjectActiveState(inner);
                    }

                case 6: // ObjectTranslateState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 6, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectTranslateState.Converter)();
                        return EventData.ObjectTranslateState(inner);
                    }

                case 7: // ObjectScaleState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 7, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectScaleState.Converter)();
                        return EventData.ObjectScaleState(inner);
                    }

                case 8: // ObjectRotateState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 8, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectRotateState.Converter)();
                        return EventData.ObjectRotateState(inner);
                    }

                case 9: // ObjectMotion
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 9, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotion.Converter)();
                        return EventData.ObjectMotion(inner);
                    }

                case 10: // ObjectMotionFromTo
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 10, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionFromTo.Converter)();
                        return EventData.ObjectMotionFromTo(inner);
                    }

                case 11: // ObjectMotionSiScript
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 11, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectMotionSiScript.Converter)();
                        return EventData.ObjectMotionSiScript(inner);
                    }

                case 12: // ObjectOpacityState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 12, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityState.Converter)();
                        return EventData.ObjectOpacityState(inner);
                    }

                case 13: // ObjectOpacityFromTo
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 13, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectOpacityFromTo.Converter)();
                        return EventData.ObjectOpacityFromTo(inner);
                    }

                case 14: // ObjectAddChild
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 14, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectAddChild.Converter)();
                        return EventData.ObjectAddChild(inner);
                    }

                case 15: // ObjectDeleteChild
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 15, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectDeleteChild.Converter)();
                        return EventData.ObjectDeleteChild(inner);
                    }

                case 16: // ObjectCycleTexture
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 16, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectCycleTexture.Converter)();
                        return EventData.ObjectCycleTexture(inner);
                    }

                case 17: // ObjectConnector
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 17, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ObjectConnector.Converter)();
                        return EventData.ObjectConnector(inner);
                    }

                case 18: // CallObjectConnector
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 18, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallObjectConnector.Converter)();
                        return EventData.CallObjectConnector(inner);
                    }

                case 19: // CameraState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 19, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CameraState.Converter)();
                        return EventData.CameraState(inner);
                    }

                case 20: // CameraFromTo
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 20, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CameraFromTo.Converter)();
                        return EventData.CameraFromTo(inner);
                    }

                case 21: // CallSequence
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 21, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallSequence.Converter)();
                        return EventData.CallSequence(inner);
                    }

                case 22: // StopSequence
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 22, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.StopSequence.Converter)();
                        return EventData.StopSequence(inner);
                    }

                case 23: // CallAnimation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 23, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallAnimation.Converter)();
                        return EventData.CallAnimation(inner);
                    }

                case 24: // StopAnimation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 24, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.StopAnimation.Converter)();
                        return EventData.StopAnimation(inner);
                    }

                case 25: // ResetAnimation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 25, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.ResetAnimation.Converter)();
                        return EventData.ResetAnimation(inner);
                    }

                case 26: // InvalidateAnimation
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 26, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.InvalidateAnimation.Converter)();
                        return EventData.InvalidateAnimation(inner);
                    }

                case 27: // FogState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 27, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.FogState.Converter)();
                        return EventData.FogState(inner);
                    }

                case 28: // Loop
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 28, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Loop.Converter)();
                        return EventData.Loop(inner);
                    }

                case 29: // If
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 29, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.If.Converter)();
                        return EventData.If(inner);
                    }

                case 30: // Else
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 30, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Else.Converter)();
                        return EventData.Else(inner);
                    }

                case 31: // Elseif
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 31, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Elseif.Converter)();
                        return EventData.Elseif(inner);
                    }

                case 32: // Endif
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 32, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Endif.Converter)();
                        return EventData.Endif(inner);
                    }

                case 33: // Callback
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 33, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.Callback.Converter)();
                        return EventData.Callback(inner);
                    }

                case 34: // FbfxColorFromTo
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 34, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.FbfxColorFromTo.Converter)();
                        return EventData.FbfxColorFromTo(inner);
                    }

                case 35: // FbfxCsinwaveFromTo
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 35, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.FbfxCsinwaveFromTo.Converter)();
                        return EventData.FbfxCsinwaveFromTo(inner);
                    }

                case 36: // AnimVerbose
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 36, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.AnimVerbose.Converter)();
                        return EventData.AnimVerbose(inner);
                    }

                case 37: // DetonateWeapon
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 37, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.DetonateWeapon.Converter)();
                        return EventData.DetonateWeapon(inner);
                    }

                case 38: // PufferState
                    {
                        if (enumType != EnumType.NewType)
                            throw new InvalidVariantException("EventData", 38, EnumType.NewType, enumType);
                        var inner = d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferState.Converter)();
                        return EventData.PufferState(inner);
                    }

                default:
                    throw new UnknownVariantException("EventData", variantIndex);
            }
        }
    }
}
