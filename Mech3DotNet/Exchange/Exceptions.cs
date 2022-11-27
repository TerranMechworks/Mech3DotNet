namespace Mech3DotNet.Exchange
{
    public class ExchangeException : System.Exception
    {
        public ExchangeException(string message) : base(message) { }
    }

    public class UnknownFieldException : ExchangeException
    {
        public UnknownFieldException(string structName, string fieldName) : base($"Invalid field '{fieldName}' for '{structName}'") { }
    }

    public class MissingFieldException : ExchangeException
    {
        public MissingFieldException(string structName, string fieldName) : base($"Missing field '{fieldName}' for '{structName}'") { }
    }

    public class UnknownGenericTypeException : ExchangeException
    {
        public UnknownGenericTypeException(System.Type type) : base($"Type '{type}' cannot be converted") { }
    }

    public class UnknownVariantException : ExchangeException
    {
        public UnknownVariantException(string structName, uint variantIndex) : base($"Invalid variant {variantIndex} for '{structName}'") { }
    }

    public class InvalidVariantException : ExchangeException
    {
        public InvalidVariantException(string structName, EnumType expected, EnumType actual) : base($"Expected variant {expected}, but found {actual} for '{structName}'") { }

        public InvalidVariantException(string structName, uint variantIndex, EnumType expected, EnumType actual) : base($"Expected variant {expected}, but found {actual} for '{structName}.{variantIndex}'") { }
    }
}
