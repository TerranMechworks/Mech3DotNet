using System.Collections.Generic;
using System.Text;

namespace Mech3DotNet.Reader.Structs
{
    public struct MechSkin
    {
        public List<string> primary;
        public Dictionary<string, string> primaryMapping;
        // public string variantB;
        // public string variantC;
        // public string variantD;
        // public string variantE;
        // public string variantF;
        // public string variantG;
        // public string variantH;
        public List<string?> damage;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("Skin<primary=[\n");
            foreach (var prim in primary)
                sb.AppendFormat("  '{0}',\n", prim);
            sb.Append("], primaryMapping={\n");
            foreach (var kv in primaryMapping)
                sb.AppendFormat("  '{0}': '{1}',\n", kv.Key, kv.Value);
            sb.Append("}, damage=[");
            foreach (var dmg in damage)
            {
                if (dmg == null)
                    sb.Append("0 ");
                else
                    sb.AppendFormat("'{0}' ", dmg);
            }
            sb.Append("]>");
            return sb.ToString();
        }
    }

    public struct ToMechSkin : IConvertOperation<MechSkin>
    {
        private static (string, string) ConvertMapping(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            var key = ToStr.Convert(index.Current, index.Path);
            index.Next();
            var val = ToStr.Convert(index.Current, index.Path);
            return (key, val);
        }

        private static (List<string>, Dictionary<string, string>) ConvertPrimary(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path);
            var primary = new List<string>();
            var primaryMapping = new Dictionary<string, string>();
            while (index.HasItems)
            {
                if (index.Current is ReaderString texture)
                {
                    primary.Add(texture);
                    index.Next();
                }
                else
                {
                    var (key, val) = ConvertMapping(index.Current, index.Path);
                    primaryMapping.Add(key, val);
                    index.Next();
                }
            }
            return (primary, primaryMapping);
        }

        private static List<string?> ConvertDamage(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path);
            var damage = new List<string?>(index.Count);
            while (index.HasItems)
            {
                if (index.Current is ReaderInt zero)
                {
                    if (zero != 0)
                        throw new ConversionException($"Expected 0, got {zero}", index.Path, index.Current);
                    damage.Add(null);
                    index.Next();
                }
                else
                    break;
            }
            while (index.HasItems)
            {
                damage.Add(ToStr.Convert(index.Current, index.Path));
                index.Next();
            }
            return damage;
        }

        public static MechSkin Convert(ReaderValue value, IEnumerable<string> path, string? chassisName)
        {
            var index = new IndexWise(value, path, 18);
            var skin = new MechSkin();
            ToStr.ConvertExpected(index, "MSG_SKIN_PRIMARY");
            index.Next();
            var mapping = ConvertPrimary(index.Current, index.Path);
            skin.primary = mapping.Item1;
            skin.primaryMapping = mapping.Item2;
            index.Next();
            ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTB");
            index.Next();
            // skin.variantB = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_b");
            index.Next();
            ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTC");
            index.Next();
            // skin.variantC = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_c");
            index.Next();
            ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTD");
            index.Next();
            // skin.variantD = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_d");
            index.Next();
            if (chassisName == "firefly")
                ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTD");
            else
                ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTE");
            index.Next();
            // skin.variantE = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_e");
            index.Next();
            ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTF");
            index.Next();
            // skin.variantF = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_f");
            index.Next();
            ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTG");
            index.Next();
            // skin.variantG = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_g");
            index.Next();
            ToStr.ConvertExpected(index, "MSG_SKIN_VARIANTH");
            index.Next();
            // skin.variantH = ToStr.Convert(index.Current, index.Path);
            ToStr.ConvertExpected(index, "_h");
            index.Next();
            ToStr.ConvertExpected(index, "damage");
            index.Next();
            skin.damage = ConvertDamage(index.Current, index.Path);
            index.Next();
            return skin;
        }

        public MechSkin ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path, null);
        }

        public static MechSkin operator /(Query query, ToMechSkin op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
