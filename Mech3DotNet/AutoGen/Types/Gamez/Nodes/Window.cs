using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Gamez.Nodes
{
    public sealed class Window
    {
        public static readonly TypeConverter<Window> Converter = new TypeConverter<Window>(Deserialize, Serialize);
        public int originX;
        public int originY;
        public int resolutionX;
        public int resolutionY;

        public Window(int originX, int originY, int resolutionX, int resolutionY)
        {
            this.originX = originX;
            this.originY = originY;
            this.resolutionX = resolutionX;
            this.resolutionY = resolutionY;
        }

        private struct Fields
        {
            public Field<int> originX;
            public Field<int> originY;
            public Field<int> resolutionX;
            public Field<int> resolutionY;
        }

        public static void Serialize(Window v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("origin_x");
            ((Action<int>)s.SerializeI32)(v.originX);
            s.SerializeFieldName("origin_y");
            ((Action<int>)s.SerializeI32)(v.originY);
            s.SerializeFieldName("resolution_x");
            ((Action<int>)s.SerializeI32)(v.resolutionX);
            s.SerializeFieldName("resolution_y");
            ((Action<int>)s.SerializeI32)(v.resolutionY);
        }

        public static Window Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                originX = new Field<int>(),
                originY = new Field<int>(),
                resolutionX = new Field<int>(),
                resolutionY = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "origin_x":
                        fields.originX.Value = d.DeserializeI32();
                        break;
                    case "origin_y":
                        fields.originY.Value = d.DeserializeI32();
                        break;
                    case "resolution_x":
                        fields.resolutionX.Value = d.DeserializeI32();
                        break;
                    case "resolution_y":
                        fields.resolutionY.Value = d.DeserializeI32();
                        break;
                    default:
                        throw new UnknownFieldException("Window", fieldName);
                }
            }
            return new Window(

                fields.originX.Unwrap("Window", "originX"),

                fields.originY.Unwrap("Window", "originY"),

                fields.resolutionX.Unwrap("Window", "resolutionX"),

                fields.resolutionY.Unwrap("Window", "resolutionY")

            );
        }
    }
}
