using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests
{
    [TestClass]
    public class ParseDateTimeTests
    {
        [TestMethod]
        [DataRow("1999-03-24T00:24:42Z")]
        [DataRow("1999-03-24T00:24:42.1Z")]
        [DataRow("1999-03-24T00:24:42.01Z")]
        [DataRow("1999-03-24T00:24:42.001Z")]
        [DataRow("1999-03-24T00:24:42.0001Z")]
        [DataRow("1999-03-24T00:24:42.00001Z")]
        [DataRow("1999-03-24T00:24:42.000001Z")]
        // [DataRow("1999-03-24T00:24:42.0000001Z")]
        // [DataRow("1999-03-24T00:24:42.00000001Z")]
        // [DataRow("1999-03-24T00:24:42.000000001Z")]
        public void Valid(string input)
        {
            var dt = DateTime.ParseExact(input, "yyyy-MM-dd'T'HH:mm:ss.FFFFFFK", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            var output = dt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.FFFFFFK", System.Globalization.CultureInfo.InvariantCulture);
            Assert.AreEqual(input, output);
        }

        /*
        public static IEnumerable<object[]> InvalidCases()
        {
            yield return O(RI(42));
            yield return O(RF(42.1f));
            yield return O(RL());
            yield return O(RL(42));
            yield return O(RL(42.1f));
            yield return O(RL("foo", "bar"));
            yield return O(RL(RL()));
        }

        [DynamicData(nameof(InvalidCases), DynamicDataSourceType.Method)]
        public void Invalid(ReaderValue value)
        {
            var message = ConvertFailure(value, String());
            StringAssert.Contains(message, ". Path '/path'.");
        }
        */
    }
}
