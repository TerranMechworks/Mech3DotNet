using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Mw
{
    public sealed class Camera
    {
        public static readonly TypeConverter<Camera> Converter = new TypeConverter<Camera>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Types.Range clip;
        public Mech3DotNet.Types.Types.Range fov;
        public uint dataPtr;

        public Camera(string name, Mech3DotNet.Types.Types.Range clip, Mech3DotNet.Types.Types.Range fov, uint dataPtr)
        {
            this.name = name;
            this.clip = clip;
            this.fov = fov;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Types.Range> clip;
            public Field<Mech3DotNet.Types.Types.Range> fov;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Mech3DotNet.Types.Nodes.Mw.Camera v, Serializer s)
        {
            s.SerializeStruct("Camera", 4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("clip");
            s.Serialize(Mech3DotNet.Types.Types.Range.Converter)(v.clip);
            s.SerializeFieldName("fov");
            s.Serialize(Mech3DotNet.Types.Types.Range.Converter)(v.fov);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static Mech3DotNet.Types.Nodes.Mw.Camera Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                clip = new Field<Mech3DotNet.Types.Types.Range>(),
                fov = new Field<Mech3DotNet.Types.Types.Range>(),
                dataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Camera"))
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "clip":
                        fields.clip.Value = d.Deserialize(Mech3DotNet.Types.Types.Range.Converter)();
                        break;
                    case "fov":
                        fields.fov.Value = d.Deserialize(Mech3DotNet.Types.Types.Range.Converter)();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Camera", fieldName);
                }
            }
            return new Camera(

                fields.name.Unwrap("Camera", "name"),

                fields.clip.Unwrap("Camera", "clip"),

                fields.fov.Unwrap("Camera", "fov"),

                fields.dataPtr.Unwrap("Camera", "dataPtr")

            );
        }
    }
}
