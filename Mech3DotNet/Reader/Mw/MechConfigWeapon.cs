using System.Collections.Generic;
using System.Linq;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Mw
{
    internal static class Repr
    {
        internal static string F(List<int>? list)
        {
            if (list == null)
                return "";
            return "[" + string.Join(",", list.Select(v => v.ToString())) + "]";
        }
    }

    public struct MechConfigWeaponAmmo
    {
        public int count;
        public string? part;
        public List<int>? extra;

        public override string ToString() => $"Ammo<count={count}, part='{part}', extra={Repr.F(extra)}>";
    }

    public struct MechConfigWeapon
    {
        public string type;
        public string firepoint;
        public List<int> group;
        public MechConfigWeaponAmmo? ammo;
        public List<int>? extra;

        public override string ToString() => $"Weapon<type='{type}', firepoint='{firepoint}', group={Repr.F(group)}, ammo={ammo}, extra={Repr.F(extra)}>";
    }

    public struct ToMechConfigWeapon : IConvertOperation<MechConfigWeapon>
    {
        private static MechConfigWeaponAmmo ConvertAmmo(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 1, 5);
            var ammo = new MechConfigWeaponAmmo()
            {
                part = null,
                extra = null,
            };
            ammo.count = ToInt.Convert(index.Current, index.Path);
            index.Next();
            if (index.HasItems)
            {
                ToStr.ConvertExpected(index, "part");
                index.Next();
                ammo.part = ToStr.Convert(index.Current, index.Path);
                index.Next();
            }
            if (index.HasItems)
            {
                ToStr.ConvertExpected(index, "extra");
                index.Next();
                ammo.extra = ToList<int>.Convert(index.Current, index.Path, Int());
            }
            return ammo;
        }

        public static MechConfigWeapon Convert(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 4, 8);
            var weapon = new MechConfigWeapon()
            {
                ammo = null,
                extra = null,
            };
            weapon.type = ToStr.Convert(index.Current, index.Path);
            index.Next();
            weapon.firepoint = ToStr.Convert(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "group");
            index.Next();
            weapon.group = ToList<int>.Convert(index.Current, index.Path, Int());
            index.Next();
            if (index.HasItems)
            {
                ToStr.ConvertExpected(index, "ammo");
                index.Next();
                weapon.ammo = ConvertAmmo(index.Current, index.Path);
                index.Next();
            }
            if (index.HasItems)
            {
                ToStr.ConvertExpected(index, "extra");
                index.Next();
                weapon.extra = ToList<int>.Convert(index.Current, index.Path, Int());
                index.Next();
            }
            return weapon;
        }

        public MechConfigWeapon ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path);
        }

        public static MechConfigWeapon operator /(Query query, ToMechConfigWeapon op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
