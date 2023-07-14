namespace Mech3DotNet.Exchange
{
    /// <summary>
    /// A field of a structure being deserialized.
    ///
    /// The field's value can be set. To get the value, call <c>Unwrap</c>,
    /// which throws an exception if the value has not been set.
    /// </summary>
    public class Field<V>
    {
        private bool isSome;
        private V value;

#pragma warning disable CS8618
        public Field()
        {
#pragma warning disable CS8601
            // it doesn't matter if this is not properly initialised, as
            // unwrap will fail unless it has been set.
            value = default(V);
#pragma warning restore CS8601
            isSome = false;
        }
#pragma warning restore CS8618

        public Field(V value)
        {
            this.value = value;
            isSome = true;
        }

        public V Value
        {
            set
            {
                this.value = value;
                isSome = true;
            }
        }

        public V Unwrap(string structName, string fieldName)
        {
            if (!isSome)
                throw new MissingFieldException(structName, fieldName);
            return value;
        }
    }
}
