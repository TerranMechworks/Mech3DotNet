using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
{
    public struct LookLimits
    {
        public int up;
        public int down;
        public int left;
        public int right;

        public override string ToString() => $"LookLimit<up={up}, down={down}, left={left}, right={right}>";
    }

    public struct ToLookLimits : IConvertOperation<LookLimits>
    {
        public static LookLimits Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 8);
            var limits = new LookLimits();
            ToStr.ConvertExpected(index, "up");
            index.Next();
            limits.up = ToInt.Convert(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "down");
            index.Next();
            limits.down = ToInt.Convert(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "left");
            index.Next();
            limits.left = ToInt.Convert(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "right");
            index.Next();
            limits.right = ToInt.Convert(index.Current, index.Path);
            return limits;
        }

        public LookLimits ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static LookLimits operator /(Query query, ToLookLimits op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
