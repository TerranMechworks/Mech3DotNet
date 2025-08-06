using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CameraState
    {
        public string name;
        public float? clipNear;
        public float? clipFar;
        public float? lodMultiplier;
        public float? fovH;
        public float? fovV;
        public float? zoomH;
        public float? zoomV;

        public CameraState(string name, float? clipNear, float? clipFar, float? lodMultiplier, float? fovH, float? fovV, float? zoomH, float? zoomV)
        {
            this.name = name;
            this.clipNear = clipNear;
            this.clipFar = clipFar;
            this.lodMultiplier = lodMultiplier;
            this.fovH = fovH;
            this.fovV = fovV;
            this.zoomH = zoomH;
            this.zoomV = zoomV;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<CameraState> Converter = new TypeConverter<CameraState>(Deserialize, Serialize);

        public static void Serialize(CameraState v, Serializer s)
        {
            s.SerializeStruct(8);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("clip_near");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.clipNear);
            s.SerializeFieldName("clip_far");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.clipFar);
            s.SerializeFieldName("lod_multiplier");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.lodMultiplier);
            s.SerializeFieldName("fov_h");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.fovH);
            s.SerializeFieldName("fov_v");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.fovV);
            s.SerializeFieldName("zoom_h");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.zoomH);
            s.SerializeFieldName("zoom_v");
            s.SerializeValOption(((Action<float>)s.SerializeF32))(v.zoomV);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<float?> clipNear;
            public Field<float?> clipFar;
            public Field<float?> lodMultiplier;
            public Field<float?> fovH;
            public Field<float?> fovV;
            public Field<float?> zoomH;
            public Field<float?> zoomV;
        }

        public static CameraState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                clipNear = new Field<float?>(),
                clipFar = new Field<float?>(),
                lodMultiplier = new Field<float?>(),
                fovH = new Field<float?>(),
                fovV = new Field<float?>(),
                zoomH = new Field<float?>(),
                zoomV = new Field<float?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "clip_near":
                        fields.clipNear.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "clip_far":
                        fields.clipFar.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "lod_multiplier":
                        fields.lodMultiplier.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "fov_h":
                        fields.fovH.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "fov_v":
                        fields.fovV.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "zoom_h":
                        fields.zoomH.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    case "zoom_v":
                        fields.zoomV.Value = d.DeserializeValOption(d.DeserializeF32)();
                        break;
                    default:
                        throw new UnknownFieldException("CameraState", fieldName);
                }
            }
            return new CameraState(

                fields.name.Unwrap("CameraState", "name"),

                fields.clipNear.Unwrap("CameraState", "clipNear"),

                fields.clipFar.Unwrap("CameraState", "clipFar"),

                fields.lodMultiplier.Unwrap("CameraState", "lodMultiplier"),

                fields.fovH.Unwrap("CameraState", "fovH"),

                fields.fovV.Unwrap("CameraState", "fovV"),

                fields.zoomH.Unwrap("CameraState", "zoomH"),

                fields.zoomV.Unwrap("CameraState", "zoomV")

            );
        }

        #endregion
    }
}
