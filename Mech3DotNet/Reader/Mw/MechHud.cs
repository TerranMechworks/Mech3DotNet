using System.Collections.Generic;

namespace Mech3DotNet.Reader.Mw
{
    public struct MechHud
    {
        public string name;
        public float v1;
        public float v2;

        public override string ToString() => $"Hud<name='{name}', v1={v1}, v2={v2}>";
    }

    public struct ToMechHud : IConvertOperation<MechHud>
    {
        private static MechHud ConvertInner(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 4);
            var hud = new MechHud();
            hud.name = ToStr.Convert(index.Current, index.Path);
            index.Next();
            var zero = ToNumber.Convert(index.Current, index.Path);
            if (zero != 0f)
                throw new ConversionException($"Expected 0f, got {zero}", index.Path, index.Current);
            index.Next();
            // this value is always 0f, except for:
            // * elemental (2.4000000953674316)
            // * madcat (1.399999976158142)
            hud.v1 = ToNumber.Convert(index.Current, index.Path);
            index.Next();
            // this value is always 0f, except for:
            // * elemental (-1f)
            // * madcat (-1f)
            hud.v2 = ToNumber.Convert(index.Current, index.Path);
            return hud;
        }

        public static MechHud Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            ToStr.ConvertExpected(index, "cage");
            index.Next();
            return ConvertInner(index.Current, index.Path);
        }

        public MechHud ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechHud operator /(Query query, ToMechHud op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
