using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CameraFromTo
    {
        public static readonly TypeConverter<CameraFromTo> Converter = new TypeConverter<CameraFromTo>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? clipNear;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? clipFar;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? lodMultiplier;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? fovH;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? fovV;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? zoomH;
        public Mech3DotNet.Types.Anim.Events.FloatFromTo? zoomV;
        public float runTime;

        public CameraFromTo(string name, Mech3DotNet.Types.Anim.Events.FloatFromTo? clipNear, Mech3DotNet.Types.Anim.Events.FloatFromTo? clipFar, Mech3DotNet.Types.Anim.Events.FloatFromTo? lodMultiplier, Mech3DotNet.Types.Anim.Events.FloatFromTo? fovH, Mech3DotNet.Types.Anim.Events.FloatFromTo? fovV, Mech3DotNet.Types.Anim.Events.FloatFromTo? zoomH, Mech3DotNet.Types.Anim.Events.FloatFromTo? zoomV, float runTime)
        {
            this.name = name;
            this.clipNear = clipNear;
            this.clipFar = clipFar;
            this.lodMultiplier = lodMultiplier;
            this.fovH = fovH;
            this.fovV = fovV;
            this.zoomH = zoomH;
            this.zoomV = zoomV;
            this.runTime = runTime;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> clipNear;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> clipFar;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> lodMultiplier;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> fovH;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> fovV;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> zoomH;
            public Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?> zoomV;
            public Field<float> runTime;
        }

        public static void Serialize(CameraFromTo v, Serializer s)
        {
            s.SerializeStruct(9);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("clip_near");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.clipNear);
            s.SerializeFieldName("clip_far");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.clipFar);
            s.SerializeFieldName("lod_multiplier");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.lodMultiplier);
            s.SerializeFieldName("fov_h");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.fovH);
            s.SerializeFieldName("fov_v");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.fovV);
            s.SerializeFieldName("zoom_h");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.zoomH);
            s.SerializeFieldName("zoom_v");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))(v.zoomV);
            s.SerializeFieldName("run_time");
            ((Action<float>)s.SerializeF32)(v.runTime);
        }

        public static CameraFromTo Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                clipNear = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                clipFar = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                lodMultiplier = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                fovH = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                fovV = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                zoomH = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                zoomV = new Field<Mech3DotNet.Types.Anim.Events.FloatFromTo?>(),
                runTime = new Field<float>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "clip_near":
                        fields.clipNear.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "clip_far":
                        fields.clipFar.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "lod_multiplier":
                        fields.lodMultiplier.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "fov_h":
                        fields.fovH.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "fov_v":
                        fields.fovV.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "zoom_h":
                        fields.zoomH.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "zoom_v":
                        fields.zoomV.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.FloatFromTo.Converter))();
                        break;
                    case "run_time":
                        fields.runTime.Value = d.DeserializeF32();
                        break;
                    default:
                        throw new UnknownFieldException("CameraFromTo", fieldName);
                }
            }
            return new CameraFromTo(

                fields.name.Unwrap("CameraFromTo", "name"),

                fields.clipNear.Unwrap("CameraFromTo", "clipNear"),

                fields.clipFar.Unwrap("CameraFromTo", "clipFar"),

                fields.lodMultiplier.Unwrap("CameraFromTo", "lodMultiplier"),

                fields.fovH.Unwrap("CameraFromTo", "fovH"),

                fields.fovV.Unwrap("CameraFromTo", "fovV"),

                fields.zoomH.Unwrap("CameraFromTo", "zoomH"),

                fields.zoomV.Unwrap("CameraFromTo", "zoomV"),

                fields.runTime.Unwrap("CameraFromTo", "runTime")

            );
        }
    }
}
