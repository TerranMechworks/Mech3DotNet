using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Camera
    {
        public static readonly TypeConverter<Camera> Converter = new TypeConverter<Camera>(Deserialize, Serialize);
        public short worldIndex;
        public short windowIndex;
        public short focusNodeXy;
        public short focusNodeXz;
        public float clipNear;
        public float clipFar;
        public float lodMultiplier;
        public float fovHScale;
        public float fovVScale;
        public float fovHBase;
        public float fovVBase;

        public Camera(short worldIndex, short windowIndex, short focusNodeXy, short focusNodeXz, float clipNear, float clipFar, float lodMultiplier, float fovHScale, float fovVScale, float fovHBase, float fovVBase)
        {
            this.worldIndex = worldIndex;
            this.windowIndex = windowIndex;
            this.focusNodeXy = focusNodeXy;
            this.focusNodeXz = focusNodeXz;
            this.clipNear = clipNear;
            this.clipFar = clipFar;
            this.lodMultiplier = lodMultiplier;
            this.fovHScale = fovHScale;
            this.fovVScale = fovVScale;
            this.fovHBase = fovHBase;
            this.fovVBase = fovVBase;
        }

        private struct Fields
        {
            public Field<short> worldIndex;
            public Field<short> windowIndex;
            public Field<short> focusNodeXy;
            public Field<short> focusNodeXz;
            public Field<float> clipNear;
            public Field<float> clipFar;
            public Field<float> lodMultiplier;
            public Field<float> fovHScale;
            public Field<float> fovVScale;
            public Field<float> fovHBase;
            public Field<float> fovVBase;
        }

        public static void Serialize(Camera v, Serializer s)
        {
            s.SerializeStruct(11);
            s.SerializeFieldName("world_index");
            ((Action<short>)s.SerializeI16)(v.worldIndex);
            s.SerializeFieldName("window_index");
            ((Action<short>)s.SerializeI16)(v.windowIndex);
            s.SerializeFieldName("focus_node_xy");
            ((Action<short>)s.SerializeI16)(v.focusNodeXy);
            s.SerializeFieldName("focus_node_xz");
            ((Action<short>)s.SerializeI16)(v.focusNodeXz);
            s.SerializeFieldName("clip_near");
            ((Action<float>)s.SerializeF32)(v.clipNear);
            s.SerializeFieldName("clip_far");
            ((Action<float>)s.SerializeF32)(v.clipFar);
            s.SerializeFieldName("lod_multiplier");
            ((Action<float>)s.SerializeF32)(v.lodMultiplier);
            s.SerializeFieldName("fov_h_scale");
            ((Action<float>)s.SerializeF32)(v.fovHScale);
            s.SerializeFieldName("fov_v_scale");
            ((Action<float>)s.SerializeF32)(v.fovVScale);
            s.SerializeFieldName("fov_h_base");
            ((Action<float>)s.SerializeF32)(v.fovHBase);
            s.SerializeFieldName("fov_v_base");
            ((Action<float>)s.SerializeF32)(v.fovVBase);
        }

        public static Camera Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                worldIndex = new Field<short>(),
                windowIndex = new Field<short>(),
                focusNodeXy = new Field<short>(),
                focusNodeXz = new Field<short>(),
                clipNear = new Field<float>(),
                clipFar = new Field<float>(),
                lodMultiplier = new Field<float>(),
                fovHScale = new Field<float>(),
                fovVScale = new Field<float>(),
                fovHBase = new Field<float>(),
                fovVBase = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "world_index":
                        fields.worldIndex.Value = d.DeserializeI16();
                        break;
                    case "window_index":
                        fields.windowIndex.Value = d.DeserializeI16();
                        break;
                    case "focus_node_xy":
                        fields.focusNodeXy.Value = d.DeserializeI16();
                        break;
                    case "focus_node_xz":
                        fields.focusNodeXz.Value = d.DeserializeI16();
                        break;
                    case "clip_near":
                        fields.clipNear.Value = d.DeserializeF32();
                        break;
                    case "clip_far":
                        fields.clipFar.Value = d.DeserializeF32();
                        break;
                    case "lod_multiplier":
                        fields.lodMultiplier.Value = d.DeserializeF32();
                        break;
                    case "fov_h_scale":
                        fields.fovHScale.Value = d.DeserializeF32();
                        break;
                    case "fov_v_scale":
                        fields.fovVScale.Value = d.DeserializeF32();
                        break;
                    case "fov_h_base":
                        fields.fovHBase.Value = d.DeserializeF32();
                        break;
                    case "fov_v_base":
                        fields.fovVBase.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("Camera", fieldName);
                }
            }
            return new Camera(

                fields.worldIndex.Unwrap("Camera", "worldIndex"),

                fields.windowIndex.Unwrap("Camera", "windowIndex"),

                fields.focusNodeXy.Unwrap("Camera", "focusNodeXy"),

                fields.focusNodeXz.Unwrap("Camera", "focusNodeXz"),

                fields.clipNear.Unwrap("Camera", "clipNear"),

                fields.clipFar.Unwrap("Camera", "clipFar"),

                fields.lodMultiplier.Unwrap("Camera", "lodMultiplier"),

                fields.fovHScale.Unwrap("Camera", "fovHScale"),

                fields.fovVScale.Unwrap("Camera", "fovVScale"),

                fields.fovHBase.Unwrap("Camera", "fovHBase"),

                fields.fovVBase.Unwrap("Camera", "fovVBase")

            );
        }
    }
}
