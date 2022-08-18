using System.Collections.Generic;
using System.Text;
using static Mech3DotNet.Reader.Query;

namespace Mech3DotNet.Reader.Structs
{
    public class MechDfn
    {
        public string chassisName = string.Empty;
        public Vec3 torsoLimits;
        public float recoilBend;
        public float recoilSlide;
        public float recoilTwist;
        public float leanAngle;
        public float leanFactor;
        public float maxTurnRate;
        public float accelRate;
        public float decelRate;
        public float crouchHeight;
        public float aimSlerpFreq;
        public float aimMinPitch;
        public float aimMaxPitch;
        public float aimMinYaw;
        public float aimMaxYaw;
        public float aimArmPitchFactor;
        public int aimIgnoreArms;
        public TorsoShake torsoShake;
        public bool chicken;
        public bool omnimech;
        public bool clan;
        public float internalMass;
        public float maxMass;
        public string weightClass = "unknown";
        public EngineRating engineMinMax;
        public MechHud hud;
        public object? camera;
        public MechConfigAnims animations;
        public MechSkin skin;
        public Dictionary<string, MechFirepoint> firepoints = new Dictionary<string, MechFirepoint>();
        public Dictionary<string, MechConfig> configurations = new Dictionary<string, MechConfig>();

        private void Repr(StringBuilder sb)
        {
            sb.Append("MechDfn<\n");
            sb.AppendFormat("  chassisName='{0}',\n", chassisName);
            sb.AppendFormat("  torsoLimits={0},\n", torsoLimits);
            sb.AppendFormat("  recoilBend={0},\n", recoilBend);
            sb.AppendFormat("  recoilSlide={0},\n", recoilSlide);
            sb.AppendFormat("  recoilTwist={0},\n", recoilTwist);
            sb.AppendFormat("  leanAngle={0},\n", leanAngle);
            sb.AppendFormat("  leanFactor={0},\n", leanFactor);
            sb.AppendFormat("  maxTurnRate={0},\n", maxTurnRate);
            sb.AppendFormat("  accelRate={0},\n", accelRate);
            sb.AppendFormat("  decelRate={0},\n", decelRate);
            sb.AppendFormat("  crouchHeight={0},\n", crouchHeight);
            sb.AppendFormat("  aimSlerpFreq={0},\n", aimSlerpFreq);
            sb.AppendFormat("  aimMinPitch={0},\n", aimMinPitch);
            sb.AppendFormat("  aimMaxPitch={0},\n", aimMaxPitch);
            sb.AppendFormat("  aimMinYaw={0},\n", aimMinYaw);
            sb.AppendFormat("  aimMaxYaw={0},\n", aimMaxYaw);
            sb.AppendFormat("  aimArmPitchFactor={0},\n", aimArmPitchFactor);
            sb.AppendFormat("  aimIgnoreArms={0},\n", aimIgnoreArms);
            sb.AppendFormat("  torsoShake={0},\n", torsoShake);
            sb.AppendFormat("  chicken={0},\n", chicken);
            sb.AppendFormat("  omnimech={0},\n", omnimech);
            sb.AppendFormat("  clan={0},\n", clan);
            sb.AppendFormat("  internalMass={0},\n", internalMass);
            sb.AppendFormat("  maxMass={0},\n", maxMass);
            sb.AppendFormat("  weightClass='{0}',\n", weightClass);
            sb.AppendFormat("  engineMinMax={0},\n", engineMinMax);
            sb.AppendFormat("  hud={0},\n", hud);
            sb.AppendFormat("  camera={0},\n", camera);
            sb.AppendFormat("  animations={0},\n", animations);
            sb.AppendFormat("  skin={0},\n", skin);

            sb.Append("  firepoints={\n");
            foreach (var firepoint in firepoints)
                sb.AppendFormat("    '{0}': {1},\n", firepoint.Key, firepoint.Value);
            sb.Append("  },\n");

            sb.Append("  configurations={\n");
            foreach (var configuration in configurations)
                sb.AppendFormat("    '{0}': {1},\n", configuration.Key, configuration.Value);
            sb.Append("  },\n");

            sb.Append('>');
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Repr(sb);
            return sb.ToString();
        }
    }

    public struct ToMechDfn : IConvertOperation<MechDfn>
    {
        private string chassisName;

        public ToMechDfn(string chassisName)
        {
            this.chassisName = chassisName;
        }

        private static void ParseBrokenComment(ref IndexWise index)
        {
            index.Next();
            ToStr.ConvertExpected(index, "torso");
            index.Next();
            ToStr.ConvertExpected(index, "limits:");
            index.Next();
            ToStr.ConvertExpected(index, "maxYaw");
            index.Next();
            ToStr.ConvertExpected(index, "minPitch");
            index.Next();
            ToStr.ConvertExpected(index, "maxPitch");
            index.Next();
            ToStr.ConvertExpected(index, "degrees");
        }

        private static float ParseBrokenStriderRecoilSlide(ReaderValue value, IEnumerable<string> path)
        {
            string broken;
            try
            {
                broken = ToStr.Convert(value, path);
            }
            catch (ConversionException)
            {
                // maybe we fixed it?
                return ToNumber.Convert(value, path);
            }
            if (broken != "1.5.0")
                throw new ConversionException("Value is not a number", path, value);
            return 1.5f;
        }

        public static MechDfn Convert(ReaderValue value, IEnumerable<string> path, string chassisName)
        {
            var index = new IndexWise(value, path);
            var mechDfn = new MechDfn()
            {
                chassisName = chassisName,
            };
            while (index.HasItems)
            {
                var key = ToStr.Convert(index.Current, index.Path);
                // do not advance index yet, since we might need index.Path to
                // throw an error
                switch (key)
                {
                    case "version":
                        {
                            index.Next();
                            var version = ToInt.Convert(index.Current, index.Path);
                            if (version != 2)
                                throw new ConversionException($"Unknown version {version}", index.Path, index.Underlying);
                            break;
                        }
                    case "torso_limits":
                        index.Next();
                        // maxYaw, minPitch, maxPitch in degrees
                        mechDfn.torsoLimits = ToVec3.Convert(index.Current, index.Path);
                        break;
                    case "//":
                        ParseBrokenComment(ref index);
                        break;
                    case "recoil_bend":
                        index.Next();
                        mechDfn.recoilBend = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "recoil_slide":
                        index.Next();
                        if (chassisName == "strider")
                            mechDfn.recoilSlide = ParseBrokenStriderRecoilSlide(index.Current, index.Path);
                        else
                            mechDfn.recoilSlide = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "recoil_twist":
                        index.Next();
                        mechDfn.recoilTwist = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "lean_angle":
                        index.Next();
                        mechDfn.leanAngle = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "lean_factor":
                        index.Next();
                        mechDfn.leanFactor = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "max_turn_rate":
                        index.Next();
                        mechDfn.maxTurnRate = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "accel_rate":
                        index.Next();
                        mechDfn.accelRate = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "decel_rate":
                        index.Next();
                        mechDfn.decelRate = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "crouch_height":
                        index.Next();
                        mechDfn.crouchHeight = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_slerp_freq":
                        index.Next();
                        mechDfn.aimSlerpFreq = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_min_pitch":
                        index.Next();
                        mechDfn.aimMinPitch = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_max_pitch":
                        index.Next();
                        mechDfn.aimMaxPitch = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_min_yaw":
                        index.Next();
                        mechDfn.aimMinYaw = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_max_yaw":
                        index.Next();
                        mechDfn.aimMaxYaw = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_arm_pitch_factor":
                        index.Next();
                        mechDfn.aimArmPitchFactor = ToNumber.Convert(index.Current, index.Path);
                        break;
                    case "aim_ignore_arms":
                        index.Next();
                        mechDfn.aimIgnoreArms = ToInt.Convert(index.Current, index.Path);
                        break;
                    case "torso_shake":
                        index.Next();
                        mechDfn.torsoShake = ToTorsoShake.Convert(index.Current, index.Path);
                        break;
                    case "chicken":
                        index.Next();
                        mechDfn.chicken = ToBool.Convert(index.Current, index.Path);
                        break;
                    case "omnimech":
                        index.Next();
                        mechDfn.omnimech = ToBool.Convert(index.Current, index.Path);
                        break;
                    case "clan":
                        index.Next();
                        mechDfn.clan = ToBool.Convert(index.Current, index.Path);
                        break;
                    case "internal_mass":
                        index.Next();
                        mechDfn.internalMass = ToFloat.Convert(index.Current, index.Path);
                        break;
                    case "max_mass":
                        index.Next();
                        mechDfn.maxMass = ToFloat.Convert(index.Current, index.Path);
                        break;
                    case "weight_class":
                        index.Next();
                        mechDfn.weightClass = ToStr.Convert(index.Current, index.Path);
                        break;
                    case "engine_minmax":
                        index.Next();
                        mechDfn.engineMinMax = ToEngineRating.Convert(index.Current, index.Path);
                        break;
                    case "hud":
                        index.Next();
                        mechDfn.hud = ToMechHud.Convert(index.Current, index.Path);
                        break;
                    case "camera":
                        index.Next();
                        mechDfn.camera = ToMechCamera.Convert(index.Current, index.Path);
                        break;
                    case "animations":
                        index.Next();
                        mechDfn.animations = ToMechConfigAnims.Convert(index.Current, index.Path, chassisName);
                        break;
                    case "skins":
                        index.Next();
                        mechDfn.skin = ToMechSkin.Convert(index.Current, index.Path, chassisName);
                        break;
                    case "firepoints":
                        {
                            index.Next();
                            var conv = Dict(new ToMechFirepoint());
                            mechDfn.firepoints = conv.ConvertTo(index.Current, index.Path);
                            break;
                        }
                    case "configurations":
                        {
                            index.Next();
                            var conv = Dict(new ToMechConfig());
                            mechDfn.configurations = conv.ConvertTo(index.Current, index.Path);
                            break;
                        }
                    default:
                        throw new ConversionException($"Unknown key '{key}'", index.Path, index.Underlying);
                }
                index.Next();
            }
            return mechDfn;
        }

        public MechDfn ConvertTo(ReaderValue value, IEnumerable<string> path)
        {
            return Convert(value, path, chassisName);
        }

        public static MechDfn operator /(Query query, ToMechDfn op)
        {
            return op.ConvertTo(query._value, query._path);
        }
    }
}
