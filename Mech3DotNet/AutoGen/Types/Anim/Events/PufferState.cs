using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class PufferState
    {
        public static readonly TypeConverter<PufferState> Converter = new TypeConverter<PufferState>(Deserialize, Serialize);
        public string name;
        public bool state;
        public bool translate;
        public int? activeState = null;
        public Mech3DotNet.Types.Anim.Events.AtNode? atNode = null;
        public Mech3DotNet.Types.Types.Vec3? localVelocity = null;
        public Mech3DotNet.Types.Types.Vec3? worldVelocity = null;
        public Mech3DotNet.Types.Types.Vec3? minRandomVelocity = null;
        public Mech3DotNet.Types.Types.Vec3? maxRandomVelocity = null;
        public Mech3DotNet.Types.Types.Vec3? worldAcceleration = null;
        public Mech3DotNet.Types.Anim.Events.Interval interval;
        public Mech3DotNet.Types.Types.Range? sizeRange = null;
        public Mech3DotNet.Types.Types.Range? lifetimeRange = null;
        public Mech3DotNet.Types.Types.Range? startAgeRange = null;
        public float? deviationDistance = null;
        public Mech3DotNet.Types.Types.Range? fadeRange = null;
        public float? friction = null;
        public Mech3DotNet.Types.Anim.Events.PufferStateCycleTextures? textures = null;
        public float? growthFactor = null;

        public PufferState(string name, bool state, bool translate, int? activeState, Mech3DotNet.Types.Anim.Events.AtNode? atNode, Mech3DotNet.Types.Types.Vec3? localVelocity, Mech3DotNet.Types.Types.Vec3? worldVelocity, Mech3DotNet.Types.Types.Vec3? minRandomVelocity, Mech3DotNet.Types.Types.Vec3? maxRandomVelocity, Mech3DotNet.Types.Types.Vec3? worldAcceleration, Mech3DotNet.Types.Anim.Events.Interval interval, Mech3DotNet.Types.Types.Range? sizeRange, Mech3DotNet.Types.Types.Range? lifetimeRange, Mech3DotNet.Types.Types.Range? startAgeRange, float? deviationDistance, Mech3DotNet.Types.Types.Range? fadeRange, float? friction, Mech3DotNet.Types.Anim.Events.PufferStateCycleTextures? textures, float? growthFactor)
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

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> state;
            public Field<bool> translate;
            public Field<int?> activeState;
            public Field<Mech3DotNet.Types.Anim.Events.AtNode?> atNode;
            public Field<Mech3DotNet.Types.Types.Vec3?> localVelocity;
            public Field<Mech3DotNet.Types.Types.Vec3?> worldVelocity;
            public Field<Mech3DotNet.Types.Types.Vec3?> minRandomVelocity;
            public Field<Mech3DotNet.Types.Types.Vec3?> maxRandomVelocity;
            public Field<Mech3DotNet.Types.Types.Vec3?> worldAcceleration;
            public Field<Mech3DotNet.Types.Anim.Events.Interval> interval;
            public Field<Mech3DotNet.Types.Types.Range?> sizeRange;
            public Field<Mech3DotNet.Types.Types.Range?> lifetimeRange;
            public Field<Mech3DotNet.Types.Types.Range?> startAgeRange;
            public Field<float?> deviationDistance;
            public Field<Mech3DotNet.Types.Types.Range?> fadeRange;
            public Field<float?> friction;
            public Field<Mech3DotNet.Types.Anim.Events.PufferStateCycleTextures?> textures;
            public Field<float?> growthFactor;
        }

        public static void Serialize(PufferState v, Serializer s)
        {
            s.SerializeStruct(19);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("state");
            ((Action<bool>)s.SerializeBool)(v.state);
            s.SerializeFieldName("translate");
            ((Action<bool>)s.SerializeBool)(v.translate);
            s.SerializeFieldName("active_state");
            s.SerializeValOption(((Action<int>)s.SerializeI32))(v.activeState);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))(v.atNode);
            s.SerializeFieldName("local_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.localVelocity);
            s.SerializeFieldName("world_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.worldVelocity);
            s.SerializeFieldName("min_random_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.minRandomVelocity);
            s.SerializeFieldName("max_random_velocity");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.maxRandomVelocity);
            s.SerializeFieldName("world_acceleration");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))(v.worldAcceleration);
            s.SerializeFieldName("interval");
            s.Serialize(Mech3DotNet.Types.Anim.Events.Interval.Converter)(v.interval);
            s.SerializeFieldName("size_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter))(v.sizeRange);
            s.SerializeFieldName("lifetime_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter))(v.lifetimeRange);
            s.SerializeFieldName("start_age_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter))(v.startAgeRange);
            s.SerializeFieldName("deviation_distance");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.deviationDistance);
            s.SerializeFieldName("fade_range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter))(v.fadeRange);
            s.SerializeFieldName("friction");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.friction);
            s.SerializeFieldName("textures");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.PufferStateCycleTextures.Converter))(v.textures);
            s.SerializeFieldName("growth_factor");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.growthFactor);
        }

        public static PufferState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                state = new Field<bool>(),
                translate = new Field<bool>(),
                activeState = new Field<int?>(null),
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode?>(null),
                localVelocity = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                worldVelocity = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                minRandomVelocity = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                maxRandomVelocity = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                worldAcceleration = new Field<Mech3DotNet.Types.Types.Vec3?>(null),
                interval = new Field<Mech3DotNet.Types.Anim.Events.Interval>(),
                sizeRange = new Field<Mech3DotNet.Types.Types.Range?>(null),
                lifetimeRange = new Field<Mech3DotNet.Types.Types.Range?>(null),
                startAgeRange = new Field<Mech3DotNet.Types.Types.Range?>(null),
                deviationDistance = new Field<float?>(null),
                fadeRange = new Field<Mech3DotNet.Types.Types.Range?>(null),
                friction = new Field<float?>(null),
                textures = new Field<Mech3DotNet.Types.Anim.Events.PufferStateCycleTextures?>(null),
                growthFactor = new Field<float?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "state":
                        fields.state.Value = d.DeserializeBool();
                        break;
                    case "translate":
                        fields.translate.Value = d.DeserializeBool();
                        break;
                    case "active_state":
                        fields.activeState.Value = d.DeserializeValOption(d.DeserializeI32)();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))();
                        break;
                    case "local_velocity":
                        fields.localVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "world_velocity":
                        fields.worldVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "min_random_velocity":
                        fields.minRandomVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "max_random_velocity":
                        fields.maxRandomVelocity.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "world_acceleration":
                        fields.worldAcceleration.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.Vec3Converter.Converter))();
                        break;
                    case "interval":
                        fields.interval.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.Interval.Converter)();
                        break;
                    case "size_range":
                        fields.sizeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter))();
                        break;
                    case "lifetime_range":
                        fields.lifetimeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter))();
                        break;
                    case "start_age_range":
                        fields.startAgeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter))();
                        break;
                    case "deviation_distance":
                        fields.deviationDistance.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "fade_range":
                        fields.fadeRange.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter))();
                        break;
                    case "friction":
                        fields.friction.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "textures":
                        fields.textures.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.PufferStateCycleTextures.Converter))();
                        break;
                    case "growth_factor":
                        fields.growthFactor.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("PufferState", fieldName);
                }
            }
            return new PufferState(

                fields.name.Unwrap("PufferState", "name"),

                fields.state.Unwrap("PufferState", "state"),

                fields.translate.Unwrap("PufferState", "translate"),

                fields.activeState.Unwrap("PufferState", "activeState"),

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

                fields.fadeRange.Unwrap("PufferState", "fadeRange"),

                fields.friction.Unwrap("PufferState", "friction"),

                fields.textures.Unwrap("PufferState", "textures"),

                fields.growthFactor.Unwrap("PufferState", "growthFactor")

            );
        }
    }
}
