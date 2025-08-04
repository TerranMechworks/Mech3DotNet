using Mech3DotNet.Exchange;

namespace Mech3DotNet.Types.Anim
{
    public enum AnimMission
    {
        Unknown,
        MwC1V10,
        MwC1V12,
        MwC2V10,
        MwC2V12,
        MwC2V12De,
        MwC3V10,
        MwC3V12,
        MwC3V12De,
        MwC3V12DeP,
        MwC4V10,
        MwC4V12De,
        MwC4bV10,
        MwC4bV12De,
        MwT1V10,
        MwT1V12De,
        PmC1,
        PmC2,
        PmC3,
        PmC4,
        RcM01,
        RcM02,
        RcM03,
        RcM04,
        RcM05,
        RcM06,
        RcM07,
        RcM08,
        RcM09,
        RcM10,
        RcM11,
        RcM12,
        RcM13,
    }

    public static class AnimMissionConverter
    {
        public static readonly TypeConverter<AnimMission> Converter = new TypeConverter<AnimMission>(Deserialize, Serialize);

        private static void Serialize(AnimMission v, Serializer s)
        {
            uint variantIndex = v switch
            {
                AnimMission.Unknown => 0,
                AnimMission.MwC1V10 => 10110,
                AnimMission.MwC1V12 => 10112,
                AnimMission.MwC2V10 => 10210,
                AnimMission.MwC2V12 => 10212,
                AnimMission.MwC2V12De => 10232,
                AnimMission.MwC3V10 => 10310,
                AnimMission.MwC3V12 => 10312,
                AnimMission.MwC3V12De => 10332,
                AnimMission.MwC3V12DeP => 10333,
                AnimMission.MwC4V10 => 10410,
                AnimMission.MwC4V12De => 10432,
                AnimMission.MwC4bV10 => 10510,
                AnimMission.MwC4bV12De => 10732,
                AnimMission.MwT1V10 => 10610,
                AnimMission.MwT1V12De => 10632,
                AnimMission.PmC1 => 20100,
                AnimMission.PmC2 => 20200,
                AnimMission.PmC3 => 20300,
                AnimMission.PmC4 => 20400,
                AnimMission.RcM01 => 30100,
                AnimMission.RcM02 => 30200,
                AnimMission.RcM03 => 30300,
                AnimMission.RcM04 => 30400,
                AnimMission.RcM05 => 30500,
                AnimMission.RcM06 => 30600,
                AnimMission.RcM07 => 30700,
                AnimMission.RcM08 => 30800,
                AnimMission.RcM09 => 30900,
                AnimMission.RcM10 => 31000,
                AnimMission.RcM11 => 31100,
                AnimMission.RcM12 => 31200,
                AnimMission.RcM13 => 31300,
                _ => throw new System.ArgumentOutOfRangeException(),
            };
            s.SerializeUnitVariant(variantIndex);
        }

        private static AnimMission Deserialize(Deserializer d)
        {
            var variantIndex = d.DeserializeUnitVariant("AnimMission");
            return variantIndex switch
            {
                0 => AnimMission.Unknown,
                10110 => AnimMission.MwC1V10,
                10112 => AnimMission.MwC1V12,
                10210 => AnimMission.MwC2V10,
                10212 => AnimMission.MwC2V12,
                10232 => AnimMission.MwC2V12De,
                10310 => AnimMission.MwC3V10,
                10312 => AnimMission.MwC3V12,
                10332 => AnimMission.MwC3V12De,
                10333 => AnimMission.MwC3V12DeP,
                10410 => AnimMission.MwC4V10,
                10432 => AnimMission.MwC4V12De,
                10510 => AnimMission.MwC4bV10,
                10732 => AnimMission.MwC4bV12De,
                10610 => AnimMission.MwT1V10,
                10632 => AnimMission.MwT1V12De,
                20100 => AnimMission.PmC1,
                20200 => AnimMission.PmC2,
                20300 => AnimMission.PmC3,
                20400 => AnimMission.PmC4,
                30100 => AnimMission.RcM01,
                30200 => AnimMission.RcM02,
                30300 => AnimMission.RcM03,
                30400 => AnimMission.RcM04,
                30500 => AnimMission.RcM05,
                30600 => AnimMission.RcM06,
                30700 => AnimMission.RcM07,
                30800 => AnimMission.RcM08,
                30900 => AnimMission.RcM09,
                31000 => AnimMission.RcM10,
                31100 => AnimMission.RcM11,
                31200 => AnimMission.RcM12,
                31300 => AnimMission.RcM13,
                _ => throw new UnknownVariantException("AnimMission", variantIndex),
            };
        }
    }
}
