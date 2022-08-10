using System.Text.Json;

namespace Mech3DotNet.Json.Converters
{
    public class Option<V>
    {
        private bool isSome;
        private V value;

#pragma warning disable CS8618
        public Option()
        {
#pragma warning disable CS8601
            // it doesn't matter if this is not properly initialised, as
            // unwrap will fail unless it has been set.
            value = default(V);
#pragma warning restore CS8601
            isSome = false;
        }
#pragma warning restore CS8618

        public Option(V value)
        {
            this.value = value;
            isSome = true;
        }

        public void Set(V value)
        {
            this.value = value;
            isSome = true;
        }

        public V Unwrap(string name)
        {
            if (!isSome)
            {

                System.Diagnostics.Debug.WriteLine($"Field '{name}' not set");
                throw new JsonException();
            }
            return value;
        }
    }
}
