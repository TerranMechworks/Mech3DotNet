using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class LightState
    {
        public static readonly TypeConverter<LightState> Converter = new TypeConverter<LightState>(Deserialize, Serialize);
        public string name;
        public bool activeState;
        public Mech3DotNet.Types.Anim.Events.LightType type;
        public Mech3DotNet.Types.Anim.Events.Translate? translate;
        public bool? directional;
        public bool? saturated;
        public bool? subdivide;
        public bool? lightmap;
        public bool? static_;
        public bool? bicolored;
        public Mech3DotNet.Types.Common.Vec3? orientation;
        public Mech3DotNet.Types.Common.Range? range;
        public Mech3DotNet.Types.Common.Color? color;
        public Mech3DotNet.Types.Common.Color? ambientColor;
        public float? ambient;
        public float? diffuse;

        public LightState(string name, bool activeState, Mech3DotNet.Types.Anim.Events.LightType type, Mech3DotNet.Types.Anim.Events.Translate? translate, bool? directional, bool? saturated, bool? subdivide, bool? lightmap, bool? static_, bool? bicolored, Mech3DotNet.Types.Common.Vec3? orientation, Mech3DotNet.Types.Common.Range? range, Mech3DotNet.Types.Common.Color? color, Mech3DotNet.Types.Common.Color? ambientColor, float? ambient, float? diffuse)
        {
            this.name = name;
            this.activeState = activeState;
            this.type = type;
            this.translate = translate;
            this.directional = directional;
            this.saturated = saturated;
            this.subdivide = subdivide;
            this.lightmap = lightmap;
            this.static_ = static_;
            this.bicolored = bicolored;
            this.orientation = orientation;
            this.range = range;
            this.color = color;
            this.ambientColor = ambientColor;
            this.ambient = ambient;
            this.diffuse = diffuse;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<bool> activeState;
            public Field<Mech3DotNet.Types.Anim.Events.LightType> type;
            public Field<Mech3DotNet.Types.Anim.Events.Translate?> translate;
            public Field<bool?> directional;
            public Field<bool?> saturated;
            public Field<bool?> subdivide;
            public Field<bool?> lightmap;
            public Field<bool?> static_;
            public Field<bool?> bicolored;
            public Field<Mech3DotNet.Types.Common.Vec3?> orientation;
            public Field<Mech3DotNet.Types.Common.Range?> range;
            public Field<Mech3DotNet.Types.Common.Color?> color;
            public Field<Mech3DotNet.Types.Common.Color?> ambientColor;
            public Field<float?> ambient;
            public Field<float?> diffuse;
        }

        public static void Serialize(LightState v, Serializer s)
        {
            s.SerializeStruct(16);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("active_state");
            ((Action<bool>)s.SerializeBool)(v.activeState);
            s.SerializeFieldName("type_");
            s.Serialize(Mech3DotNet.Types.Anim.Events.LightTypeConverter.Converter)(v.type);
            s.SerializeFieldName("translate");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.Translate.Converter))(v.translate);
            s.SerializeFieldName("directional");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.directional);
            s.SerializeFieldName("saturated");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.saturated);
            s.SerializeFieldName("subdivide");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.subdivide);
            s.SerializeFieldName("lightmap");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.lightmap);
            s.SerializeFieldName("static_");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.static_);
            s.SerializeFieldName("bicolored");
            s.SerializeValOption(((Action<bool>)s.SerializeBool))(v.bicolored);
            s.SerializeFieldName("orientation");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))(v.orientation);
            s.SerializeFieldName("range");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.RangeConverter.Converter))(v.range);
            s.SerializeFieldName("color");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter))(v.color);
            s.SerializeFieldName("ambient_color");
            s.SerializeValOption(s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter))(v.ambientColor);
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
                type = new Field<Mech3DotNet.Types.Anim.Events.LightType>(),
                translate = new Field<Mech3DotNet.Types.Anim.Events.Translate?>(),
                directional = new Field<bool?>(),
                saturated = new Field<bool?>(),
                subdivide = new Field<bool?>(),
                lightmap = new Field<bool?>(),
                static_ = new Field<bool?>(),
                bicolored = new Field<bool?>(),
                orientation = new Field<Mech3DotNet.Types.Common.Vec3?>(),
                range = new Field<Mech3DotNet.Types.Common.Range?>(),
                color = new Field<Mech3DotNet.Types.Common.Color?>(),
                ambientColor = new Field<Mech3DotNet.Types.Common.Color?>(),
                ambient = new Field<float?>(),
                diffuse = new Field<float?>(),
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
                    case "type_":
                        fields.type.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.LightTypeConverter.Converter)();
                        break;
                    case "translate":
                        fields.translate.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.Translate.Converter))();
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
                    case "lightmap":
                        fields.lightmap.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "static_":
                        fields.static_.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "bicolored":
                        fields.bicolored.Value = d.DeserializeValOption(d.DeserializeBool)();
                        break;
                    case "orientation":
                        fields.orientation.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter))();
                        break;
                    case "range":
                        fields.range.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.RangeConverter.Converter))();
                        break;
                    case "color":
                        fields.color.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter))();
                        break;
                    case "ambient_color":
                        fields.ambientColor.Value = d.DeserializeValOption(d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter))();
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

                fields.type.Unwrap("LightState", "type"),

                fields.translate.Unwrap("LightState", "translate"),

                fields.directional.Unwrap("LightState", "directional"),

                fields.saturated.Unwrap("LightState", "saturated"),

                fields.subdivide.Unwrap("LightState", "subdivide"),

                fields.lightmap.Unwrap("LightState", "lightmap"),

                fields.static_.Unwrap("LightState", "static_"),

                fields.bicolored.Unwrap("LightState", "bicolored"),

                fields.orientation.Unwrap("LightState", "orientation"),

                fields.range.Unwrap("LightState", "range"),

                fields.color.Unwrap("LightState", "color"),

                fields.ambientColor.Unwrap("LightState", "ambientColor"),

                fields.ambient.Unwrap("LightState", "ambient"),

                fields.diffuse.Unwrap("LightState", "diffuse")

            );
        }
    }
}
