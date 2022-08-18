using System.Collections.Generic;
using System.Text;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Structs
{
    public struct MechConfig
    {
        public MechConfigEngine engine;
        public List<MechConfigEquipment> equipment;
        public List<MechConfigWeapon> weapons;
        public MechConfigArmor armor;
        public string? internals;

        private void Repr(StringBuilder sb)
        {
            sb.Append("Config<\n");
            sb.AppendFormat("  engine={0},\n", engine);
            if (internals != null)
                sb.AppendFormat("  internal={0},\n", internals);
            sb.Append("  equipment=[\n");
            foreach (var eq in equipment)
                sb.AppendFormat("    {0},\n", eq);
            sb.Append("  ],\n");
            sb.Append("  weapons=[\n");
            foreach (var weapon in weapons)
                sb.AppendFormat("    {0},\n", weapon);
            sb.Append("  ],\n");
            sb.AppendFormat("  armor={0},\n", armor);
            sb.Append('>');
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Repr(sb);
            return sb.ToString();
        }
    }

    public struct ToMechConfig : IConvertOperation<MechConfig>
    {
        public static MechConfig Convert(ReaderValue value, IEnumerable<string> path)
        {
            var pairWise = new PairWise(value, path);
            var config = new MechConfig();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "engine":
                        config.engine = ToMechConfigEngine.Convert(item.value, item.path);
                        break;
                    case "armor":
                        config.armor = ToMechConfigArmor.Convert(item.value, item.path);
                        break;
                    case "equipment":
                        config.equipment = ToList<MechConfigEquipment>.Convert(item.value, item.path, new ToMechConfigEquipment());
                        break;
                    case "weapons":
                        config.weapons = ToList<MechConfigWeapon>.Convert(item.value, item.path, new ToMechConfigWeapon());
                        break;
                    case "internal":
                        config.internals = ToStr.Convert(item.value, item.path);
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return config;
        }

        public MechConfig ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechConfig operator /(Query query, ToMechConfig op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
