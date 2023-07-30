using System.Collections.Generic;
using System.Text;

namespace Mech3DotNet.Reader.Mw
{
    public struct IONetNode
    {
        public Vec3 position;
        public int value;

        public override string ToString() => $"Node<position={position}, value={value}>";
    }

    public struct IONet
    {
        public string name;
        public Dictionary<string, IONetNode> nodes;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("IONet<name='{0}', nodes={\n", name);
            foreach (var node in nodes)
                sb.AppendFormat("  '{0}': {1},\n", node.Key, node.Value);
            sb.Append("}]");
            return sb.ToString();
        }
    }

    public struct ToIONetNode : IConvertOperation<IONetNode>
    {
        public static IONetNode Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 3);
            var node = new IONetNode();
            var type = ToInt.Convert(index.Current, index.Path);
            if (type != 108)
                throw new ConversionException($"Expected 12, but got {type}", index.Path, index.Underlying);
            index.Next();
            node.position = ToVec3.Convert(index.Current, index.Path);
            index.Next();
            node.value = ToInt.Convert(index.Current, index.Path);
            return node;
        }

        public IONetNode ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static IONetNode operator /(Query query, ToIONetNode op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }

    public struct ToIONet : IConvertOperation<IONet>
    {
        public static IONet Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path);
            var net = new IONet()
            {
                nodes = new Dictionary<string, IONetNode>(),
            };
            ToStr.ConvertExpected(index, "version");
            index.Next();
            var version = ToInt.Convert(index.Current, index.Path);
            if (version != 108)
                throw new ConversionException($"Expected 108, but got {version}", index.Path, index.Underlying);
            index.Next();
            ToStr.ConvertExpected(index, "name");
            index.Next();
            net.name = ToStr.Convert(index.Current, index.Path);
            index.Next();
            while (index.HasItems)
            {
                var nodeName = ToStr.Convert(index.Current, index.Path);
                index.Next();
                var node = ToIONetNode.Convert(index.Current, index.Path);
                index.Next();
                net.nodes.Add(nodeName, node);
            }
            return net;
        }

        public IONet ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static IONet operator /(Query query, ToIONet op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
