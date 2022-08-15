using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace Mech3DotNet.Reader
{
    public static struct PairWise
    {
        public static IEnumerable<(string key, JsonNode? value, IEnumerable<string> path)> PairWise(JsonNode? node, IEnumerable<string> path)
        {
            var array = ConversionException.Array(node, path);

            var fullCount = array.Count;
            var halfCount = fullCount / 2;
            if (halfCount * 2 != fullCount)
                throw new ConversionException($"Value has uneven count {fullCount}", path, array);

            var childPath = new List<string>(path);
            childPath.Add(""); // will be overwritten by loop index

            for (int i = 0, j = 1; i < fullCount; i += 2, j += 2)
            {
                childPath[childPath.Count - 1] = i.ToString();
                var key = ToString.Convert(array[i], childPath);
                childPath[childPath.Count - 1] = j.ToString();
                var value = array[j];
                yield return (key, value, childPath);
            }
        }
    }
}
