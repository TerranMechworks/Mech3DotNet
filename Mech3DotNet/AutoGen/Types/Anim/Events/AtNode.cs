using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class AtNode
    {
        public string name;
        public Mech3DotNet.Types.Common.Vec3 pos;

        public AtNode(string name, Mech3DotNet.Types.Common.Vec3 pos)
        {
            this.name = name;
            this.pos = pos;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<AtNode> Converter = new TypeConverter<AtNode>(Deserialize, Serialize);

        public static void Serialize(AtNode v, Serializer s)
        {
            s.SerializeStruct(2);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("pos");
            s.Serialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)(v.pos);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<Mech3DotNet.Types.Common.Vec3> pos;
        }

        public static AtNode Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                pos = new Field<Mech3DotNet.Types.Common.Vec3>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "pos":
                        fields.pos.Value = d.Deserialize(Mech3DotNet.Types.Common.Vec3Converter.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("AtNode", fieldName);
                }
            }
            return new AtNode(

                fields.name.Unwrap("AtNode", "name"),

                fields.pos.Unwrap("AtNode", "pos")

            );
        }

        #endregion
    }
}
