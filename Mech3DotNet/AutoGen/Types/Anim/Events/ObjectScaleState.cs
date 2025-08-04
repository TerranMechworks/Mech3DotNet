using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectScaleState
    {
        public static readonly TypeConverter<ObjectScaleState> Converter = new TypeConverter<ObjectScaleState>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Common.Vec3 state;

        public ObjectScaleState(string name, Mech3DotNet.Types.Common.Vec3 state)
        {
            this.name = name;
            this.state = state;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Common.Vec3> state;
        }

        public static void Serialize(ObjectScaleState v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("state");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.state);
        }

        public static ObjectScaleState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                state = new Field<Mech3DotNet.Types.Common.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "state":
                        fields.state.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectScaleState", fieldName);
                }
            }
            return new ObjectScaleState(

                fields.name.Unwrap("ObjectScaleState", "name"),

                fields.state.Unwrap("ObjectScaleState", "state")

            );
        }
    }
}
