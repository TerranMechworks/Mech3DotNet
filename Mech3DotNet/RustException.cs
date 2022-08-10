using System;

namespace Mech3DotNet
{
    public class RustException : Exception
    {
        internal RustException(string message) : base(message) { }
    }
}
