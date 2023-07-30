using System.Collections.Generic;

namespace Mech3DotNet.Reader.Mw
{
    public struct ArmorValue
    {
        public int v0;
        public int v1;

        public override string ToString() => $"({v0}, {v1})";
    }

    public struct MechConfigArmor
    {
        public bool ferroFibrous;
        public float mass;
        public int head;
        public ArmorValue torso;
        public ArmorValue torsoLR;
        public int arms;
        public int legs;

        public override string ToString() => $"Armor<FF={ferroFibrous}, mass={mass}, head={head}, torso={torso}, torsolr={torsoLR}, arms={arms}, legs={legs}>";
    }

    public struct ToMechConfigArmor : IConvertOperation<MechConfigArmor>
    {
        private static ArmorValue ConvertAV(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            var av = new ArmorValue();
            av.v0 = ToInt.Convert(index.Current, index.Path);
            index.Next();
            av.v1 = ToInt.Convert(index.Current, index.Path);
            return av;
        }

        public static MechConfigArmor Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var armor = new MechConfigArmor();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "ferro-fibrous":
                        armor.ferroFibrous = ToBool.Convert(item.value, item.path);
                        break;
                    case "mass":
                        armor.mass = ToNumber.Convert(item.value, item.path);
                        break;
                    case "head":
                        armor.head = ToInt.Convert(item.value, item.path);
                        break;
                    case "torso":
                        armor.torso = ConvertAV(item.value, item.path);
                        break;
                    case "torsolr":
                        armor.torsoLR = ConvertAV(item.value, item.path);
                        break;
                    case "arms":
                        armor.arms = ToInt.Convert(item.value, item.path);
                        break;
                    case "legs":
                        armor.legs = ToInt.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return armor;
        }

        public MechConfigArmor ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechConfigArmor operator /(Query query, ToMechConfigArmor op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
