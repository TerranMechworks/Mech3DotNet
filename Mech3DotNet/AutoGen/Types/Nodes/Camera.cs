using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class Camera
    {
        public static readonly TypeConverter<Camera> Converter = new TypeConverter<Camera>(Deserialize, Serialize);
        public Mech3DotNet.Types.Range clip;
        public Mech3DotNet.Types.Range fov;
        public int focusNodeXy;
        public uint dataPtr;

        public Camera(Mech3DotNet.Types.Range clip, Mech3DotNet.Types.Range fov, int focusNodeXy, uint dataPtr)
        {
            this.clip = clip;
            this.fov = fov;
            this.focusNodeXy = focusNodeXy;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<Mech3DotNet.Types.Range> clip;
            public Field<Mech3DotNet.Types.Range> fov;
            public Field<int> focusNodeXy;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Camera v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("clip");
            s.Serialize(Mech3DotNet.Types.RangeConverter.Converter)(v.clip);
            s.SerializeFieldName("fov");
            s.Serialize(Mech3DotNet.Types.RangeConverter.Converter)(v.fov);
            s.SerializeFieldName("focus_node_xy");
            ((Action<int>)s.SerializeI32)(v.focusNodeXy);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static Camera Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                clip = new Field<Mech3DotNet.Types.Range>(),
                fov = new Field<Mech3DotNet.Types.Range>(),
                focusNodeXy = new Field<int>(),
                dataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "clip":
                        fields.clip.Value = d.Deserialize(Mech3DotNet.Types.RangeConverter.Converter)();
                        break;
                    case "fov":
                        fields.fov.Value = d.Deserialize(Mech3DotNet.Types.RangeConverter.Converter)();
                        break;
                    case "focus_node_xy":
                        fields.focusNodeXy.Value = d.DeserializeI32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Camera", fieldName);
                }
            }
            return new Camera(

                fields.clip.Unwrap("Camera", "clip"),

                fields.fov.Unwrap("Camera", "fov"),

                fields.focusNodeXy.Unwrap("Camera", "focusNodeXy"),

                fields.dataPtr.Unwrap("Camera", "dataPtr")

            );
        }
    }
}
