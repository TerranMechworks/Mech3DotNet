using System.Collections.Generic;

namespace Mech3DotNet.Reader.Structs
{
    public struct MechCameraAttach
    {
        public float dist;
        public Vec3 desiredPos;
        public LookLimits lookLimits;

        public override string ToString() => $"Camera<attach, dist={dist}, desired_pos={desiredPos}, look_limits={lookLimits}>";
    }

    public struct MechCameraTether
    {
        public float dist;
        public Vec3 deltaRot;
        public Vec3 desiredPos;
        public float distVaryFactor;
        public float distVary;

        public override string ToString() => $"Camera<tether, dist={dist}, delta_rot={deltaRot}, desired_pos={desiredPos}, dist_vary_factor={distVaryFactor}, dist_vary={distVary}>";
    }

    public struct ToMechCameraAttach : IConvertOperation<MechCameraAttach>
    {
        public static MechCameraAttach Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var camera = new MechCameraAttach();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "dist":
                        camera.dist = ToFloat.Convert(item.value, item.path);
                        break;
                    case "desired_pos":
                        camera.desiredPos = ToVec3.Convert(item.value, item.path);
                        break;
                    case "look_limits":
                        camera.lookLimits = ToLookLimits.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return camera;
        }

        public MechCameraAttach ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechCameraAttach operator /(Query query, ToMechCameraAttach op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }

    public struct ToMechCameraTether : IConvertOperation<MechCameraTether>
    {
        public static MechCameraTether Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var camera = new MechCameraTether();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "dist":
                        camera.dist = ToFloat.Convert(item.value, item.path);
                        break;
                    case "delta_rot":
                        camera.deltaRot = ToVec3.Convert(item.value, item.path);
                        break;
                    case "desired_pos":
                        camera.desiredPos = ToVec3.Convert(item.value, item.path);
                        break;
                    case "dist_vary_factor":
                        camera.distVaryFactor = ToFloat.Convert(item.value, item.path);
                        break;
                    case "dist_vary":
                        camera.distVary = ToFloat.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return camera;
        }

        public MechCameraTether ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechCameraTether operator /(Query query, ToMechCameraTether op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }

    public struct ToMechCamera : IConvertOperation<object>
    {
        public static object Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            var type = ToStr.Convert(index.Current, index.Path);
            switch (type)
            {
                case "attach":
                    // all mechs except elemental
                    index.Next();
                    return ToMechCameraAttach.Convert(index.Current, index.Path);
                case "tether":
                    // only elemental
                    index.Next();
                    return ToMechCameraTether.Convert(index.Current, index.Path);
                default:
                    throw new ConversionException($"Expected 'attach' or 'tether', got '{type}'", index.Path, index.Current);
            }
        }

        public object ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static object operator /(Query query, ToMechCamera op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
