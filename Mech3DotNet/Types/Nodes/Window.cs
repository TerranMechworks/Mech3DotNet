using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class Window
    {
        public static readonly TypeConverter<Window> Converter = new TypeConverter<Window>(Deserialize, Serialize);
        public uint resolutionX;
        public uint resolutionY;
        public uint dataPtr;

        public Window(uint resolutionX, uint resolutionY, uint dataPtr)
        {
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<uint> resolutionX;
            public Field<uint> resolutionY;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Window v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("resolution_x");
            ((Action<uint>)s.SerializeU32)(v.resolutionX);
            s.SerializeFieldName("resolution_y");
            ((Action<uint>)s.SerializeU32)(v.resolutionY);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static Window Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                resolutionX = new Field<uint>(),
                resolutionY = new Field<uint>(),
                dataPtr = new Field<uint>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "resolution_x":
                        fields.resolutionX.Value = d.DeserializeU32();
                        break;
                    case "resolution_y":
                        fields.resolutionY.Value = d.DeserializeU32();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Window", fieldName);
                }
            }
            return new Window(

                fields.resolutionX.Unwrap("Window", "resolutionX"),

                fields.resolutionY.Unwrap("Window", "resolutionY"),

                fields.dataPtr.Unwrap("Window", "dataPtr")

            );
        }
    }
}
