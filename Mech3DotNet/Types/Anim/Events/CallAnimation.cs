using System;
using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim.Events
{
    public sealed class CallAnimation
    {
        public static readonly TypeConverter<CallAnimation> Converter = new TypeConverter<CallAnimation>(Deserialize, Serialize);
        public string name;
        public ushort? waitForCompletion = null;
        public Mech3DotNet.Types.Anim.Events.CallAnimationParameters parameters;

        public CallAnimation(string name, ushort? waitForCompletion, Mech3DotNet.Types.Anim.Events.CallAnimationParameters parameters)
        {
            this.name = name;
            this.waitForCompletion = waitForCompletion;
            this.parameters = parameters;
        }

        private struct Fields
        {
            public Field<string> name;
            public Field<ushort?> waitForCompletion;
            public Field<Mech3DotNet.Types.Anim.Events.CallAnimationParameters> parameters;
        }

        public static void Serialize(CallAnimation v, Serializer s)
        {
            s.SerializeStruct(3);
            s.SerializeFieldName("name");
            ((Action<string>)s.SerializeString)(v.name);
            s.SerializeFieldName("wait_for_completion");
            s.SerializeValOption(((Action<ushort>)s.SerializeU16))(v.waitForCompletion);
            s.SerializeFieldName("parameters");
            s.Serialize(Mech3DotNet.Types.Anim.Events.CallAnimationParameters.Converter)(v.parameters);
        }

        public static CallAnimation Deserialize(Deserializer d)
        {
            var fields = new Fields()
            {
                name = new Field<string>(),
                waitForCompletion = new Field<ushort?>(null),
                parameters = new Field<Mech3DotNet.Types.Anim.Events.CallAnimationParameters>(),
            };
            foreach (var fieldName in d.DeserializeStruct())
            {
                switch (fieldName)
                {
                    case "name":
                        fields.name.Value = d.DeserializeString();
                        break;
                    case "wait_for_completion":
                        fields.waitForCompletion.Value = d.DeserializeValOption(d.DeserializeU16)();
                        break;
                    case "parameters":
                        fields.parameters.Value = d.Deserialize(Mech3DotNet.Types.Anim.Events.CallAnimationParameters.Converter)();
                        break;
                    default:
                        throw new UnknownFieldException("CallAnimation", fieldName);
                }
            }
            return new CallAnimation(

                fields.name.Unwrap("CallAnimation", "name"),

                fields.waitForCompletion.Unwrap("CallAnimation", "waitForCompletion"),

                fields.parameters.Unwrap("CallAnimation", "parameters")

            );
        }
    }
}
