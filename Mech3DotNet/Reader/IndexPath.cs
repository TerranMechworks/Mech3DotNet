using System;
using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct IndexPath
    {
        private List<string> path;
        private int index;

        public IEnumerable<string> Path => path;

        public IndexPath(IEnumerable<string> oldPath)
        {
            index = 0;
            path = new List<string>(oldPath);
            path.Add(index.ToString());
        }

        public void Next()
        {
            index++;
            path[path.Count - 1] = index.ToString();
        }
    }
}
