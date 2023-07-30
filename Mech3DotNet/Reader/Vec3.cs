using System.Collections.Generic;

namespace Mech3DotNet.Reader
{
    public struct Vec3
    {
        public float x;
        public float y;
        public float z;

        public override string ToString() => $"Vec3<x={x}, y={y}, z={z}>";
    }

    public struct ToVec3 : IConvertOperation<Vec3>
    {
        public static Vec3 Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 3);
            var vec = new Vec3();
            vec.x = ToNumber.Convert(index.Current, index.Path);
            index.Next();
            vec.y = ToNumber.Convert(index.Current, index.Path);
            index.Next();
            vec.z = ToNumber.Convert(index.Current, index.Path);
            return vec;
        }

        public Vec3 ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Vec3 operator /(Query query, ToVec3 op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
