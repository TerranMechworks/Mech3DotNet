using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
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
            var list = ConversionException.ListFixed(value, path, 3);
            var childPath = new IndexPath(path);
            var vec = new Vec3();
            vec.x = ToNumber.Convert(list[0], childPath.Path);
            childPath.Next();
            vec.y = ToNumber.Convert(list[1], childPath.Path);
            childPath.Next();
            vec.z = ToNumber.Convert(list[2], childPath.Path);
            return vec;
        }

        public Vec3 ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static Vec3 operator /(Query query, ToVec3 op)
        {
            return op.ConvertTo(query.value, query.path);
        }
    }
}
