using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimation
    {
        public string name;
        public string? operandNode;
        public short? waitForCompletion;
        public Mech3DotNet.Types.Anim.Events.CallAnimationParameters? parameters;

        public CallAnimation(string name, string? operandNode, short? waitForCompletion, Mech3DotNet.Types.Anim.Events.CallAnimationParameters? parameters)
        {
            this.name = name;
            this.operandNode = operandNode;
            this.waitForCompletion = waitForCompletion;
            this.parameters = parameters;
        }

        #region "Serialize/Deserialize logic"

        public static readonly TypeConverter<CallAnimation> Converter = new TypeConverter<CallAnimation>(Deserialize, Serialize);

        public static void Serialize(CallAnimation v, Serializer s)
        {
            s.SerializeStruct(4);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("operand_node");
            s.SerializeRefOption(((Action<string>)s.SerializeString))(v.operandNode);
            s.SerializeFieldName("wait_for_completion");
            s.SerializeValOption(((Action<short>)s.SerializeI16))(v.waitForCompletion);
            s.SerializeFieldName("parameters");
            s.SerializeRefOption(s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationParameters.Converter))(v.parameters);
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<string?> operandNode;
            public Field<short?> waitForCompletion;
            public Field<Mech3DotNet.Types.Anim.Events.CallAnimationParameters?> parameters;
        }

        public static CallAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                operandNode = new Field<string?>(),
                waitForCompletion = new Field<short?>(),
                parameters = new Field<Mech3DotNet.Types.Anim.Events.CallAnimationParameters?>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "operand_node":
                        fields.operandNode.Value = d.DeserializeRefOption(d.DeserializeString)();
                        break;
                    case "wait_for_completion":
                        fields.waitForCompletion.Value = d.DeserializeValOption(d.DeserializeI16)();
                        break;
                    case "parameters":
                        fields.parameters.Value = d.DeserializeRefOption(d.Deserialize(Mech3DotNet.Types.Anim.Events.CallAnimationParameters.Converter))();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimation", fieldName);
                }
            }
            return new CallAnimation(

                fields.name.Unwrap("CallAnimation", "name"),

                fields.operandNode.Unwrap("CallAnimation", "operandNode"),

                fields.waitForCompletion.Unwrap("CallAnimation", "waitForCompletion"),

                fields.parameters.Unwrap("CallAnimation", "parameters")

            );
        }

        #endregion
    }
}
