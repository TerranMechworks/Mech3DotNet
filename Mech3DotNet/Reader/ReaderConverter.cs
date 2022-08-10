using System;

namespace Mech3DotNet.Reader
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public class ReaderConverter : Attribute
    {
        public Type ConverterType { get; }
        public object[]? ConverterParameters { get; }

        public ReaderConverter(Type converterType)
        {
            ConverterType = converterType;
            ConverterParameters = null;
        }

        public ReaderConverter(Type converterType, params object[] converterParameters)
        {
            ConverterType = converterType;
            ConverterParameters = converterParameters;
        }

        public IReaderConverter CreateInstance()
        {
            return (IReaderConverter)Activator.CreateInstance(this.ConverterType, this.ConverterParameters);
        }
    }
}
