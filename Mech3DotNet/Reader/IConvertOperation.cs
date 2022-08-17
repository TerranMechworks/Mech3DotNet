using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public interface IConvertOperation<T>
    {
        T ConvertTo(ReaderValue value, IEnumerable<string> path);
    }
}
