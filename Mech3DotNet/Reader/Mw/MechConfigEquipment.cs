using System.Collections.Generic;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Mw
{
    public struct MechConfigEquipment
    {
        public string type;
        public string part;

        public override string ToString() => $"Equipment<type='{type}', part='{part}'>";
    }

    public struct ToMechConfigEquipment : IConvertOperation<MechConfigEquipment>
    {
        public static MechConfigEquipment Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            var equipment = new MechConfigEquipment();
            equipment.type = ToStr.Convert(index.Current, index.Path);
            index.Next();
            equipment.part = ToStr.Convert(index.Current, index.Path);
            return equipment;
        }

        public MechConfigEquipment ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechConfigEquipment operator /(Query query, ToMechConfigEquipment op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
