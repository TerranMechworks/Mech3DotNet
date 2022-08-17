using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct FindByKey : IQueryOperation
    {
        private string key;

        public FindByKey(string key)
        {
            this.key = key;
        }

        public ReaderValue Apply(ReaderValue value, List<string> path)
        {
            var list = ConversionException.List(value, path);

            var found = new List<ReaderValue>();
            for (var i = 0; i < list.Count - 1; i++)
            {
                var child = list[i];
                if (child is ReaderString str && key == str.Value)
                    found.Add(list[i + 1]);
            }

            if (found.Count == 0)
                throw new NotFoundException($"Key '{key}' not found (no keys)", path);

            path.Add(key);
            return new ReaderList(found);
        }
    }
}
