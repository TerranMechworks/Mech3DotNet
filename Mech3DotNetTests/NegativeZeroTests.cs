using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Mech3DotNetTests
{
    /// <summary>
    /// Some .NET versions do not handle negative zero differently from positive
    /// zero. This is annoying, since it prevents roundtripping floating point
    /// values. In e.g. .NET Core 3.0+,
    /// <see href="https://devblogs.microsoft.com/dotnet/floating-point-parsing-and-formatting-improvements-in-net-core-3-0/">
    /// the bad negative zero parsing is fixed</see>. If these tests fail, then
    /// this problem is fixed.
    /// 
    /// There's no way to work around this in Json.NET. There are two floating
    /// point parse settings, 
    /// <see cref="Newtonsoft.Json.FloatParseHandling.Double"/> and
    /// <see cref="Newtonsoft.Json.FloatParseHandling.Decimal"/>. It isn't
    /// possible to patch the fundamentally broken <see cref="double.Parse(string)"/>
    /// to parse negative zero properly. <see cref="decimal.Parse(string)"/> does
    /// handle negative zeros! There are three problems with this. The lesser
    /// are that there is no unique representation for negative zero, and by
    /// default, negative zero and positive zero are considered equal. This
    /// makes bit comparisons tricky. But worse, decimal doesn't cover the same
    /// range as float (values in MechWarrior 3 are generally floats/singles).
    /// So that doesn't work either.
    /// 
    /// Finally, you might think you could write your own
    /// <see cref="Newtonsoft.Json.JsonConverter"/>. This is also not possible.
    /// You'd have to get the parser to read the float token as a string
    /// instead of parsing it before calling the converter. I haven't found a
    /// way to force this though.
    /// </summary>
    [TestClass]
    public class NegativeZeroTests
    {
        private static uint FloatToUInt32Bits(float value) =>
            BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);

        private static ulong DoubleToUInt64Bits(double value) =>
            BitConverter.ToUInt64(BitConverter.GetBytes(value), 0);

        private const float FLOAT_POS_ZERO = 0.0f;
        private const float FLOAT_NEG_ZERO = -0.0f;
        private static readonly uint FLOAT_POS_ZERO_BITS = FloatToUInt32Bits(FLOAT_POS_ZERO);
        private static readonly uint FLOAT_NEG_ZERO_BITS = FloatToUInt32Bits(FLOAT_NEG_ZERO);

        private const double DOUBLE_POS_ZERO = 0.0;
        private const double DOUBLE_NEG_ZERO = -0.0;
        private static readonly ulong DOUBLE_POS_ZERO_BITS = DoubleToUInt64Bits(DOUBLE_POS_ZERO);
        private static readonly ulong DOUBLE_NEG_ZERO_BITS = DoubleToUInt64Bits(DOUBLE_NEG_ZERO);

        [TestMethod]
        public void Float_NegativeZeroParse_IsBroken()
        {
            var value = FloatToUInt32Bits(float.Parse("-0.0", CultureInfo.InvariantCulture));
            Assert.AreNotEqual(FLOAT_NEG_ZERO_BITS, value);
            Assert.AreEqual(FLOAT_POS_ZERO_BITS, value);
        }

        [TestMethod]
        public void Double_NegativeZeroParse_IsBroken()
        {
            var value = DoubleToUInt64Bits(double.Parse("-0.0", CultureInfo.InvariantCulture));
            Assert.AreNotEqual(DOUBLE_NEG_ZERO_BITS, value);
            Assert.AreEqual(DOUBLE_POS_ZERO_BITS, value);
        }

        [TestMethod]
        public void Float_NegativeZeroToString_IsBroken()
        {
            var positive = FLOAT_POS_ZERO.ToString("G9", CultureInfo.InvariantCulture);
            Assert.AreEqual("0", positive);
            var negative = FLOAT_NEG_ZERO.ToString("G9", CultureInfo.InvariantCulture);
            Assert.AreEqual(positive, negative);
            Assert.AreNotEqual("-0", negative);
        }

        [TestMethod]
        public void Double_NegativeZeroToString_IsBroken()
        {
            var positive = DOUBLE_POS_ZERO.ToString("R", CultureInfo.InvariantCulture);
            Assert.AreEqual("0", positive);
            var negative = DOUBLE_NEG_ZERO.ToString("R", CultureInfo.InvariantCulture);
            Assert.AreEqual(positive, negative);
            Assert.AreNotEqual("-0", negative);
        }
    }
}
