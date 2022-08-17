using System;
using System.Collections.Generic;
namespace Mech3DotNet.Reader
{
    public struct FindOnly : IQueryOperation
    {
        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            var list = ConversionException.List(value, path);
            if (list.Count != 1)
                throw new NotFoundException($"Single value not found (count: {list.Count})", path);
            path.Add(".only");
            return list[0];
        }
    }
}
