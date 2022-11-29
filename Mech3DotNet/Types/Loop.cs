using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class Loop
    {
        public static readonly TypeConverter<Loop> Converter = new TypeConverter<Loop>(Deserialize, Serialize);
        public int start;
        public int loopCount;

        public Loop(int start, int loopCount)
        {
            this.start = start;
            this.loopCount = loopCount;
        }

        private struct Fields
        {
            public Field<int> start;
            public Field<int> loopCount;
        }

        public static void Serialize(Loop v, Serializer s)
        {
            s.SerializeStruct("Loop", 2);
            s.SerializeFieldName("start");
            ((Action<int>)s.SerializeI32)(v.start);
            s.SerializeFieldName("loop_count");
            ((Action<int>)s.SerializeI32)(v.loopCount);
        }

        public static Loop Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                start = new Field<int>(),
                loopCount = new Field<int>(),
            };
            foreach (var fieldName in d.DeserializeStruct("Loop"))
            {
                switch (fieldName)
                {
                    case "start":
                        fields.start.Value = d.DeserializeI32();
                        break;
                    case "loop_count":
                        fields.loopCount.Value = d.DeserializeI32();
                        break;
                    default:
                        throw new UnknownFieldException("Loop", fieldName);
                }
            }
            return new Loop(

                fields.start.Unwrap("Loop", "start"),

                fields.loopCount.Unwrap("Loop", "loopCount")

            );
        }
    }
}
