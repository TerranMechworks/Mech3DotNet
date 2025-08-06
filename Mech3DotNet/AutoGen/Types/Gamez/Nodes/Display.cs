using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Display
    {
        public uint originX;
        public uint originY;
        public uint resolutionX;
        public uint resolutionY;
        public Mech3DotNet.Types.Common.Color clearColor;

        public Display(uint originX, uint originY, uint resolutionX, uint resolutionY, Mech3DotNet.Types.Common.Color clearColor)
        {
            this.originX = originX;
            this.originY = originY;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
            this.clearColor = clearColor;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<Display> Converter = new TypeConverter<Display>(Deserialize, Serialize);

        public static void Serialize(Display v, Serializer s)
        {
            s.SerializeStruct(5);
            s.SerializeFieldName("origin_x");
            ((Action<uint>)s.SerializeU32)(v.originX);
            s.SerializeFieldName("origin_y");
            ((Action<uint>)s.SerializeU32)(v.originY);
            s.SerializeFieldName("resolution_x");
            ((Action<uint>)s.SerializeU32)(v.resolutionX);
            s.SerializeFieldName("resolution_y");
            ((Action<uint>)s.SerializeU32)(v.resolutionY);
            s.SerializeFieldName("clear_color");
            s.Serialize(Mech3DotNet.Types.Common.ColorConverter.Converter)(v.clearColor);
        }

        private struct Fields
        {
            public Field<uint> originX;
            public Field<uint> originY;
            public Field<uint> resolutionX;
            public Field<uint> resolutionY;
            public Field<Mech3DotNet.Types.Common.Color> clearColor;
        }

        public static Display Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                originX = new Field<uint>(),
                originY = new Field<uint>(),
                resolutionX = new Field<uint>(),
                resolutionY = new Field<uint>(),
                clearColor = new Field<Mech3DotNet.Types.Common.Color>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "origin_x":
                        fields.originX.Value = d.DeserializeU32();
                        break;
                    case "origin_y":
                        fields.originY.Value = d.DeserializeU32();
                        break;
                    case "resolution_x":
                        fields.resolutionX.Value = d.DeserializeU32();
                        break;
                    case "resolution_y":
                        fields.resolutionY.Value = d.DeserializeU32();
                        break;
                    case "clear_color":
                        fields.clearColor.Value = d.Deserialize(Mech3DotNet.Types.Common.ColorConverter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("Display", fieldName);
                }
            }
            return new Display(

                fields.originX.Unwrap("Display", "originX"),

                fields.originY.Unwrap("Display", "originY"),

                fields.resolutionX.Unwrap("Display", "resolutionX"),

                fields.resolutionY.Unwrap("Display", "resolutionY"),

                fields.clearColor.Unwrap("Display", "clearColor")

            );
        }

        #endregion
    }
}
