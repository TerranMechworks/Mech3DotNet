using System;

namespace Mech3DotNet.Unsafe
{
    public class RustException : Exception
    {
        internal RustException(string message) : base(message) { }
    }
}
