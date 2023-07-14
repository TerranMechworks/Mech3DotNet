namespace Mech3DotNet.Exchange
{
    /// <summary>Mech3ax exchange format base exception.</summary>
    public class ExchangeException : System.Exception
    {
        public ExchangeException(string message) : base(message) { }
    }

    /// <summary>An unknown field was encountered when deserializing data.</summary>
    public class UnknownFieldException : ExchangeException
    {
        public UnknownFieldException(string structName, string fieldName) : base($"Invalid field '{fieldName}' for '{structName}'") { }
    }

    /// <summary>A required field was missing when deserializing data.</summary>
    public class MissingFieldException : ExchangeException
    {
        public MissingFieldException(string structName, string fieldName) : base($"Missing field '{fieldName}' for '{structName}'") { }
    }

    /// <summary>
    /// The serializer or deserializer does not know how to serialize or
    /// deserialize the specified generic type, as no converter for that type
    /// is registered.
    /// </summary>
    public class UnknownGenericTypeException : ExchangeException
    {
        public UnknownGenericTypeException(System.Type type) : base($"No converter for generic type '{type}' registered") { }
    }

    /// <summary>An unknown enum variant was encountered when deserializing data.</summary>
    public class UnknownVariantException : ExchangeException
    {
        public UnknownVariantException(string structName, uint variantIndex) : base($"Invalid variant {variantIndex} for '{structName}'") { }
    }
    /// <summary>
    /// An invalid enum variant type was encountered when deserializing data.
    ///
    /// For example, the variant expects a unit type, but a new type was found.
    /// </summary>
    public class InvalidVariantException : ExchangeException
    {
        public InvalidVariantException(string structName, EnumType expected, EnumType actual) : base($"Expected variant {expected}, but found {actual} for '{structName}'") { }

        public InvalidVariantException(string structName, uint variantIndex, EnumType expected, EnumType actual) : base($"Expected variant {expected}, but found {actual} for '{structName}.{variantIndex}'") { }
    }
}
