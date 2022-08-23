using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Mech3DotNet.Json.Converters;

namespace Mech3DotNet.Json
{
    [JsonConverter(typeof(PufferStateConverter))]
    public class PufferState
    {
        public string name;
        public bool state;
        public bool translate;
        public int? activeState = null;
        public AtNode? atNode = null;
        public Vec3? localVelocity = null;
        public Vec3? worldVelocity = null;
        public Vec3? minRandomVelocity = null;
        public Vec3? maxRandomVelocity = null;
        public Vec3? worldAcceleration = null;
        public Interval interval;
        public Range? sizeRange = null;
        public Range? lifetimeRange = null;
        public Range? startAgeRange = null;
        public float? deviationDistance = null;
        public Range? fadeRange = null;
        public float? friction = null;
        public PufferStateCycleTextures? textures = null;
        public float? growthFactor = null;

        public PufferState(string name, bool state, bool translate, int? activeState, AtNode? atNode, Vec3? localVelocity, Vec3? worldVelocity, Vec3? minRandomVelocity, Vec3? maxRandomVelocity, Vec3? worldAcceleration, Interval interval, Range? sizeRange, Range? lifetimeRange, Range? startAgeRange, float? deviationDistance, Range? fadeRange, float? friction, PufferStateCycleTextures? textures, float? growthFactor)
        {
            this.name = name;
            this.state = state;
            this.translate = translate;
            this.activeState = activeState;
            this.atNode = atNode;
            this.localVelocity = localVelocity;
            this.worldVelocity = worldVelocity;
            this.minRandomVelocity = minRandomVelocity;
            this.maxRandomVelocity = maxRandomVelocity;
            this.worldAcceleration = worldAcceleration;
            this.interval = interval;
            this.sizeRange = sizeRange;
            this.lifetimeRange = lifetimeRange;
            this.startAgeRange = startAgeRange;
            this.deviationDistance = deviationDistance;
            this.fadeRange = fadeRange;
            this.friction = friction;
            this.textures = textures;
            this.growthFactor = growthFactor;
        }
    }
}
