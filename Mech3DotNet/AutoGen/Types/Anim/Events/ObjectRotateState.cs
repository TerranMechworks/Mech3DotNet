using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class ObjectRotateState
    {
        public static readonly TypeConverter<ObjectRotateState> Converter = new TypeConverter<ObjectRotateState>(Deserialize, Serialize);
        public string name;
        public Mech3DotNet.Types.Common.Vec3 state;
        public Mech3DotNet.Types.Anim.Events.RotateBasis basis;

        public ObjectRotateState(string name, Mech3DotNet.Types.Common.Vec3 state, Mech3DotNet.Types.Anim.Events.RotateBasis basis)
        {
            this.name = name;
            this.state = state;
            this.basis = basis;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Common.Vec3> state;
            public Field<Mech3DotNet.Types.Anim.Events.RotateBasis> basis;
        }

        public static void Serialize(ObjectRotateState v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("state");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.state);
            s.SerializeFieldName("basis");
            s.Serialize(Mech3DotNet.Types.Anim.Events.RotateBasis.Converter)(v.basis);
        }

        public static ObjectRotateState Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                state = new Field<Mech3DotNet.Types.Common.Vec3>(),
                basis = new Field<Mech3DotNet.Types.Anim.Events.RotateBasis>(),
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
                    case "basis":
                        fields.basis.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.RotateBasis.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("ObjectRotateState", fieldName);
                }
            }
            return new ObjectRotateState(

                fields.name.Unwrap("ObjectRotateState", "name"),

                fields.state.Unwrap("ObjectRotateState", "state"),

                fields.basis.Unwrap("ObjectRotateState", "basis")

            );
        }
    }
}
