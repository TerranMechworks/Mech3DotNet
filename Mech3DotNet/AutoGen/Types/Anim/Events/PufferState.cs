using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferState
    {
        public static readonly TypeConverter<PufferState> Converter = new TypeConverter<PufferState>(Deserialize, Serialize);
        public string name;
        public uint? activeState;
        public Mech3DotNet.Types.Common.Vec3? translate;
        public string? atNode;
        public Mech3DotNet.Types.Common.Vec3? localVelocity;
        public Mech3DotNet.Types.Common.Vec3? worldVelocity;
        public Mech3DotNet.Types.Common.Vec3? minRandomVelocity;
        public Mech3DotNet.Types.Common.Vec3? maxRandomVelocity;
        public Mech3DotNet.Types.Common.Vec3? worldAcceleration;
        public Mech3DotNet.Types.Anim.Events.PufferInterval? interval;
        public Mech3DotNet.Types.Common.Range? sizeRange;
        public Mech3DotNet.Types.Common.Range? lifetimeRange;
        public Mech3DotNet.Types.Common.Range? startAgeRange;
        public float? deviationDistance;
        public Mech3DotNet.Types.Common.Range? unkRange;
        public Mech3DotNet.Types.Common.Range? fadeRange;
        public float? friction;
        public float? windFactor;
        public float? priority;
        public uint? number;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateTexture>? textures;
        public System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateColor>? colors;
        public System.Collections.Generic.List<Mech3DotNet.Types.Common.Range>? growthFactors;
        public Mech3DotNet.Types.Anim.Events.PufferIntervalGarbage? intervalGarbage = null;

        public PufferState(string name, uint? activeState, Mech3DotNet.Types.Common.Vec3? translate, string? atNode, Mech3DotNet.Types.Common.Vec3? localVelocity, Mech3DotNet.Types.Common.Vec3? worldVelocity, Mech3DotNet.Types.Common.Vec3? minRandomVelocity, Mech3DotNet.Types.Common.Vec3? maxRandomVelocity, Mech3DotNet.Types.Common.Vec3? worldAcceleration, Mech3DotNet.Types.Anim.Events.PufferInterval? interval, Mech3DotNet.Types.Common.Range? sizeRange, Mech3DotNet.Types.Common.Range? lifetimeRange, Mech3DotNet.Types.Common.Range? startAgeRange, float? deviationDistance, Mech3DotNet.Types.Common.Range? unkRange, Mech3DotNet.Types.Common.Range? fadeRange, float? friction, float? windFactor, float? priority, uint? number, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateTexture>? textures, System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateColor>? colors, System.Collections.Generic.List<Mech3DotNet.Types.Common.Range>? growthFactors, Mech3DotNet.Types.Anim.Events.PufferIntervalGarbage? intervalGarbage)
        {
            this.name = name;
            this.activeState = activeState;
            this.translate = translate;
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
            this.unkRange = unkRange;
            this.fadeRange = fadeRange;
            this.friction = friction;
            this.windFactor = windFactor;
            this.priority = priority;
            this.number = number;
            this.textures = textures;
            this.colors = colors;
            this.growthFactors = growthFactors;
            this.intervalGarbage = intervalGarbage;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<uint?> activeState;
            public Field<Mech3DotNet.Types.Common.Vec3?> translate;
            public Field<string?> atNode;
            public Field<Mech3DotNet.Types.Common.Vec3?> localVelocity;
            public Field<Mech3DotNet.Types.Common.Vec3?> worldVelocity;
            public Field<Mech3DotNet.Types.Common.Vec3?> minRandomVelocity;
            public Field<Mech3DotNet.Types.Common.Vec3?> maxRandomVelocity;
            public Field<Mech3DotNet.Types.Common.Vec3?> worldAcceleration;
            public Field<Mech3DotNet.Types.Anim.Events.PufferInterval?> interval;
            public Field<Mech3DotNet.Types.Common.Range?> sizeRange;
            public Field<Mech3DotNet.Types.Common.Range?> lifetimeRange;
            public Field<Mech3DotNet.Types.Common.Range?> startAgeRange;
            public Field<float?> deviationDistance;
            public Field<Mech3DotNet.Types.Common.Range?> unkRange;
            public Field<Mech3DotNet.Types.Common.Range?> fadeRange;
            public Field<float?> friction;
            public Field<float?> windFactor;
            public Field<float?> priority;
            public Field<uint?> number;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateTexture>?> textures;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateColor>?> colors;
            public Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Range>?> growthFactors;
            public Field<Mech3DotNet.Types.Anim.Events.PufferIntervalGarbage?> intervalGarbage;
        }

        public static void Serialize(PufferState v, Serializer s)
        {
            s.SerializeStruct(24);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("active_state");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.activeState);
            s.SerializeFieldName("translate");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.translate);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.atNode);
            s.SerializeFieldName("local_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.localVelocity);
            s.SerializeFieldName("world_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.worldVelocity);
            s.SerializeFieldName("min_random_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.minRandomVelocity);
            s.SerializeFieldName("max_random_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.maxRandomVelocity);
            s.SerializeFieldName("world_acceleration");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.worldAcceleration);
            s.SerializeFieldName("interval");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.PufferInterval.Converter))(v.interval);
            s.SerializeFieldName("size_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.sizeRange);
            s.SerializeFieldName("lifetime_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.lifetimeRange);
            s.SerializeFieldName("start_age_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.startAgeRange);
            s.SerializeFieldName("deviation_distance");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.deviationDistance);
            s.SerializeFieldName("unk_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.unkRange);
            s.SerializeFieldName("fade_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.fadeRange);
            s.SerializeFieldName("friction");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.friction);
            s.SerializeFieldName("wind_factor");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.windFactor);
            s.SerializeFieldName("priority");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.priority);
            s.SerializeFieldName("number");
            s.SerializeValOption(((Action<uint>)s.SerializeU32))(v.number);
            s.SerializeFieldName("textures");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Events.PufferStateTexture.Converter)))(v.textures);
            s.SerializeFieldName("colors");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Anim.Events.PufferStateColor.Converter)))(v.colors);
            s.SerializeFieldName("growth_factors");
            s.SerializeRefOption(s.SerializeVec(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter)))(v.growthFactors);
            s.SerializeFieldName("interval_garbage");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.PufferIntervalGarbage.Converter))(v.intervalGarbage);
        }

        public static PufferState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                activeState = new Field<uint?>(),
                translate = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                atNode = new Field<string?>(),
                localVelocity = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                worldVelocity = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                minRandomVelocity = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                maxRandomVelocity = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                worldAcceleration = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                interval = new Field<Mech3DotNet.Types.Anim.Events.PufferInterval?>(),
                sizeRange = new Field<Mech3DotNet.Types.Common.Range?>(),
                lifetimeRange = new Field<Mech3DotNet.Types.Common.Range?>(),
                startAgeRange = new Field<Mech3DotNet.Types.Common.Range?>(),
                deviationDistance = new Field<float?>(),
                unkRange = new Field<Mech3DotNet.Types.Common.Range?>(),
                fadeRange = new Field<Mech3DotNet.Types.Common.Range?>(),
                friction = new Field<float?>(),
                windFactor = new Field<float?>(),
                priority = new Field<float?>(),
                number = new Field<uint?>(),
                textures = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateTexture>?>(),
                colors = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Anim.Events.PufferStateColor>?>(),
                growthFactors = new Field<System.Collections.Generic.List<Mech3DotNet.Types.Common.Range>?>(),
                intervalGarbage = new Field<Mech3DotNet.Types.Anim.Events.PufferIntervalGarbage?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "active_state":
                        fields.activeState.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "translate":
                        fields.translate.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "local_velocity":
                        fields.localVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "world_velocity":
                        fields.worldVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "min_random_velocity":
                        fields.minRandomVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "max_random_velocity":
                        fields.maxRandomVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "world_acceleration":
                        fields.worldAcceleration.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "interval":
                        fields.interval.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferInterval.Converter))();
                        break;
                    case "size_range":
                        fields.sizeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "lifetime_range":
                        fields.lifetimeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "start_age_range":
                        fields.startAgeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "deviation_distance":
                        fields.deviationDistance.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "unk_range":
                        fields.unkRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "fade_range":
                        fields.fadeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "friction":
                        fields.friction.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "wind_factor":
                        fields.windFactor.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "priority":
                        fields.priority.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "number":
                        fields.number.Value = d.DeserializeValOption(d.DeserializeU32)();
                        break;
                    case "textures":
                        fields.textures.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferStateTexture.Converter)))();
                        break;
                    case "colors":
                        fields.colors.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferStateColor.Converter)))();
                        break;
                    case "growth_factors":
                        fields.growthFactors.Value = d.DeserializeRefOption(d.DeserializeVec(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter)))();
                        break;
                    case "interval_garbage":
                        fields.intervalGarbage.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferIntervalGarbage.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("PufferState", fieldName);
                }
            }
            return new PufferState(

                fields.name.Unwrap("PufferState", "name"),

                fields.activeState.Unwrap("PufferState", "activeState"),

                fields.translate.Unwrap("PufferState", "translate"),

                fields.atNode.Unwrap("PufferState", "atNode"),

                fields.localVelocity.Unwrap("PufferState", "localVelocity"),

                fields.worldVelocity.Unwrap("PufferState", "worldVelocity"),

                fields.minRandomVelocity.Unwrap("PufferState", "minRandomVelocity"),

                fields.maxRandomVelocity.Unwrap("PufferState", "maxRandomVelocity"),

                fields.worldAcceleration.Unwrap("PufferState", "worldAcceleration"),

                fields.interval.Unwrap("PufferState", "interval"),

                fields.sizeRange.Unwrap("PufferState", "sizeRange"),

                fields.lifetimeRange.Unwrap("PufferState", "lifetimeRange"),

                fields.startAgeRange.Unwrap("PufferState", "startAgeRange"),

                fields.deviationDistance.Unwrap("PufferState", "deviationDistance"),

                fields.unkRange.Unwrap("PufferState", "unkRange"),

                fields.fadeRange.Unwrap("PufferState", "fadeRange"),

                fields.friction.Unwrap("PufferState", "friction"),

                fields.windFactor.Unwrap("PufferState", "windFactor"),

                fields.priority.Unwrap("PufferState", "priority"),

                fields.number.Unwrap("PufferState", "number"),

                fields.textures.Unwrap("PufferState", "textures"),

                fields.colors.Unwrap("PufferState", "colors"),

                fields.growthFactors.Unwrap("PufferState", "growthFactors"),

                fields.intervalGarbage.Unwrap("PufferState", "intervalGarbage")

            );
        }
    }
}
