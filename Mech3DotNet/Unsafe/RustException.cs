using System;

namespace Mech3DotNet.Unsafe
{
    /// <summary>
    /// An error from the mech3ax library converted to an exception.
    /// </summary>
    public class RustException : Exception
    {
        internal RustException(string message) : base(message) { }
    }
}
