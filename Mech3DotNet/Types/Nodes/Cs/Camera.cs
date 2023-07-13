using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes.Cs
{
    public sealed class Camera
    {
        public static readonly TypeConverter<Camera> Converter = new TypeConverter<Camera>(Deserialize, Serialize);
        public string name;
        public int focusNodeXy;
        public uint dataPtr;

        public Camera(string name, int focusNodeXy, uint dataPtr)
        {
            this.name = name;
            this.focusNodeXy = focusNodeXy;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<int> focusNodeXy;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Camera v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("focus_node_xy");
            ((Action<int>)s.SerializeI32)(v.focusNodeXy);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static Camera Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                focusNodeXy = new Field<int>(),
                dataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
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

                fields.name.Unwrap("Camera", "name"),

                fields.focusNodeXy.Unwrap("Camera", "focusNodeXy"),

                fields.dataPtr.Unwrap("Camera", "dataPtr")

            );
        }
    }
}
