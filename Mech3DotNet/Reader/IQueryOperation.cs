using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public interface IQueryOperation
    {
        ReaderValue Apply(ReaderValue value, List<string> path);
    }
}
