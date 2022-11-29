using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class LightState
    {
        public static readonly TypeConverter<LightState> Converter = new TypeConverter<LightState>(Deserialize, Serialize);
        public string name;
        public bool activeState;
        public bool? directional = null;
        public bool? saturated = null;
        public bool? subdivide = null;
        public bool? static_ = null;
        public Mech3DotNet.Types.Anim.Events.AtNode? atNode = null;
        public Mech3DotNet.Types.Types.Range? range = null;
        public Mech3DotNet.Types.Types.Color? color = null;
        public float? ambient = null;
        public float? diffuse = null;

        public LightState(string name, bool activeState, bool? directional, bool? saturated, bool? subdivide, bool? static_, Mech3DotNet.Types.Anim.Events.AtNode? atNode, Mech3DotNet.Types.Types.Range? range, Mech3DotNet.Types.Types.Color? color, float? ambient, float? diffuse)
        {
            this.name = name;
            this.activeState = activeState;
            this.directional = directional;
            this.saturated = saturated;
            this.subdivide = subdivide;
            this.static_ = static_;
            this.atNode = atNode;
            this.range = range;
            this.color = color;
            this.ambient = ambient;
            this.diffuse = diffuse;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> activeState;
            public Field<bool?> directional;
            public Field<bool?> saturated;
            public Field<bool?> subdivide;
            public Field<bool?> static_;
            public Field<Mech3DotNet.Types.Anim.Events.AtNode?> atNode;
            public Field<Mech3DotNet.Types.Types.Range?> range;
            public Field<Mech3DotNet.Types.Types.Color?> color;
            public Field<float?> ambient;
            public Field<float?> diffuse;
        }

        public static void Serialize(LightState v, Serializer s)
        {
            s.SerializeStruct(11);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("active_state");
            ((Action<bool>)s.SerializeBool)(v.activeState);
            s.SerializeFieldName("directional");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.directional);
            s.SerializeFieldName("saturated");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.saturated);
            s.SerializeFieldName("subdivide");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.subdivide);
            s.SerializeFieldName("static_");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.static_);
            s.SerializeFieldName("at_node");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))(v.atNode);
            s.SerializeFieldName("range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.RangeConverter.Converter))(v.range);
            s.SerializeFieldName("color");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter))(v.color);
            s.SerializeFieldName("ambient");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.ambient);
            s.SerializeFieldName("diffuse");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.diffuse);
        }

        public static LightState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                activeState = new Field<bool>(),
                directional = new Field<bool?>(null),
                saturated = new Field<bool?>(null),
                subdivide = new Field<bool?>(null),
                static_ = new Field<bool?>(null),
                atNode = new Field<Mech3DotNet.Types.Anim.Events.AtNode?>(null),
                range = new Field<Mech3DotNet.Types.Types.Range?>(null),
                color = new Field<Mech3DotNet.Types.Types.Color?>(null),
                ambient = new Field<float?>(null),
                diffuse = new Field<float?>(null),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "active_state":
                        fields.activeState.Value = d.DeserializeBool();
                        break;
                    case "directional":
                        fields.directional.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "saturated":
                        fields.saturated.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "subdivide":
                        fields.subdivide.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "static_":
                        fields.static_.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "at_node":
                        fields.atNode.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.AtNode.Converter))();
                        break;
                    case "range":
                        fields.range.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.RangeConverter.Converter))();
                        break;
                    case "color":
                        fields.color.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter))();
                        break;
                    case "ambient":
                        fields.ambient.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "diffuse":
                        fields.diffuse.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("LightState", fieldName);
                }
            }
            return new LightState(

                fields.name.Unwrap("LightState", "name"),

                fields.activeState.Unwrap("LightState", "activeState"),

                fields.directional.Unwrap("LightState", "directional"),

                fields.saturated.Unwrap("LightState", "saturated"),

                fields.subdivide.Unwrap("LightState", "subdivide"),

                fields.static_.Unwrap("LightState", "static_"),

                fields.atNode.Unwrap("LightState", "atNode"),

                fields.range.Unwrap("LightState", "range"),

                fields.color.Unwrap("LightState", "color"),

                fields.ambient.Unwrap("LightState", "ambient"),

                fields.diffuse.Unwrap("LightState", "diffuse")

            );
        }
    }
}
