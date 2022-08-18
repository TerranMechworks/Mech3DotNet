using System.Collections.Generic;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Structs
{
    public struct MechConfigAnimEject
    {
        public Vec3 offset;
        public string node;

        public override string ToString() => $"Eject<ofs={offset}, node='{node}'>";
    }

    public struct MechConfigAnimCanned
    {
        // this is a bit useless, all mechs have jumpjets
        public bool jumpjets;
        // this is a bit useless, only elementals don't have NARC
        public bool narc;
        public MechConfigAnimEject? eject;

        public override string ToString() => $"Canned<jumpjets={jumpjets}, narc={narc}, eject={eject}>";
    }

    public struct MotionTranslation
    {
        public float v0;
        public float v1;
    }

    public struct MechConfigAnimMotion
    {
        public string stand;
        public string step;
        public string walk;
        public string trot;
        public string run;

        public MotionTranslation stand_trans;
        public MotionTranslation step_trans;
        public MotionTranslation walk_trans;
        public MotionTranslation trot_trans;
        public MotionTranslation run_trans;

        public override string ToString() => $"Motion<stand='{stand}', step='{step}', walk='{walk}', trot='{trot}', run='{run}'>";
    }

    public struct MechConfigAnims
    {
        public MechConfigAnimCanned canned;
        public MechConfigAnimMotion motion;

        public override string ToString() => $"Animations<canned={canned}, motion={motion}>";
    }

    public struct ToMechConfigAnims : IConvertOperation<MechConfigAnims>
    {
        private static MechConfigAnimEject ConvertEject(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 5);
            var eject = new MechConfigAnimEject();
            ToStr.ConvertExpected(index, "eject_seat");
            index.Next();
            ToStr.ConvertExpected(index, "ofs");
            index.Next();
            eject.offset = ToVec3.Convert(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "node");
            index.Next();
            eject.node = ToStr.Convert(index.Current, index.Path);
            return eject;
        }

        private static MechConfigAnimCanned ConvertCanned(ReaderValue value, IEnumerable<string> path, string? chassisName)
        {
            var pairWise = new PairWise(value, path);
            var canned = new MechConfigAnimCanned();
            foreach (var item in pairWise)
            {
                switch (item.key)
                {
                    case "eject":
                        canned.eject = ConvertEject(item.value, item.path);
                        break;
                    case "jumpjets":
                        if (chassisName == "elemental")
                        {
                            // this is weird and has no extra info, let's ignore it
                        }
                        else
                            ToStr.ConvertExpected(item.value, item.path, "jumpjets", pairWise.Underlying);
                        canned.jumpjets = true;
                        break;
                    case "narc":
                        ToStr.ConvertExpected(item.value, item.path, "narc_shroud", pairWise.Underlying);
                        canned.narc = true;
                        break;
                    default:
                        throw new ConversionException($"Unknown key '{item.key}'", path, pairWise.Underlying);
                }
            }
            return canned;
        }

        private static MotionTranslation ConvertTranslation(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 2);
            var trans = new MotionTranslation();
            trans.v0 = ToNumber.Convert(index.Current, index.Path);
            index.Next();
            trans.v1 = ToNumber.Convert(index.Current, index.Path);
            return trans;
        }

        private static (string, MotionTranslation) ConvertMotion(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 4);
            ToStr.ConvertExpected(index, "anim");
            index.Next();
            var anim = ToStr.Convert(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "trans");
            index.Next();
            var trans = ConvertTranslation(index.Current, index.Path);
            return (anim, trans);
        }

        private static MechConfigAnimMotion ConvertMotions(ReaderValue value, IEnumerable<string> path)
        {
            var index = new IndexWise(value, path, 10);
            var motion = new MechConfigAnimMotion();
            ToStr.ConvertExpected(index, "stand");
            index.Next();
            (motion.stand, motion.stand_trans) = ConvertMotion(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "step");
            index.Next();
            (motion.step, motion.stand_trans) = ConvertMotion(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "walk");
            index.Next();
            (motion.walk, motion.walk_trans) = ConvertMotion(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "trot");
            index.Next();
            (motion.trot, motion.trot_trans) = ConvertMotion(index.Current, index.Path);
            index.Next();
            ToStr.ConvertExpected(index, "run");
            index.Next();
            (motion.run, motion.run_trans) = ConvertMotion(index.Current, index.Path);
            return motion;
        }

        public static MechConfigAnims Convert(ReaderValue value, IEnumerable<string> path, string? chassisName)
        {
            var index = new IndexWise(value, path, 4);
            var anims = new MechConfigAnims();
            ToStr.ConvertExpected(index, "canned");
            index.Next();
            anims.canned = ConvertCanned(index.Current, index.Path, chassisName);
            index.Next();
            ToStr.ConvertExpected(index, "motion");
            index.Next();
            anims.motion = ConvertMotions(index.Current, index.Path);
            return anims;
        }

        public MechConfigAnims ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path, null);
        }

        public static MechConfigAnims operator /(Query query, ToMechConfigAnims op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
