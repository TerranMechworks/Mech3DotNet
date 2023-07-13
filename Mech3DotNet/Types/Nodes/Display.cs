using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Nodes
{
    public sealed class Display
    {
        public static readonly TypeConverter<Display> Converter = new TypeConverter<Display>(Deserialize, Serialize);
        public uint resolutionX;
        public uint resolutionY;
        public Mech3DotNet.Types.Types.Color clearColor;
        public uint dataPtr;

        public Display(uint resolutionX, uint resolutionY, Mech3DotNet.Types.Types.Color clearColor, uint dataPtr)
        {
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.clearColor = clearColor;
            this.dataPtr = dataPtr;
        }

        private struct Fields
        {
            public Field<uint> resolutionX;
            public Field<uint> resolutionY;
            public Field<Mech3DotNet.Types.Types.Color> clearColor;
            public Field<uint> dataPtr;
        }

        public static void Serialize(Display v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("resolution_x");
            ((Action<uint>)s.SerializeU32)(v.resolutionX);
            s.SerializeFieldName("resolution_y");
            ((Action<uint>)s.SerializeU32)(v.resolutionY);
            s.SerializeFieldName("clear_color");
            s.Serialize(Mech3DotNet.Types.Types.ColorConverter.Converter)(v.clearColor);
            s.SerializeFieldName("data_ptr");
            ((Action<uint>)s.SerializeU32)(v.dataPtr);
        }

        public static Display Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                resolutionX = new Field<uint>(),
                resolutionY = new Field<uint>(),
                clearColor = new Field<Mech3DotNet.Types.Types.Color>(),
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
                    case "clear_color":
                        fields.clearColor.Value = d.Deserialize(Mech3DotNet.Types.Types.ColorConverter.Converter)();
                        break;
                    case "data_ptr":
                        fields.dataPtr.Value = d.DeserializeU32();
                        break;
                    default:
                        throw new UnknownFieldException("Display", fieldName);
                }
            }
            return new Display(

                fields.resolutionX.Unwrap("Display", "resolutionX"),

                fields.resolutionY.Unwrap("Display", "resolutionY"),

                fields.clearColor.Unwrap("Display", "clearColor"),

                fields.dataPtr.Unwrap("Display", "dataPtr")

            );
        }
    }
}
