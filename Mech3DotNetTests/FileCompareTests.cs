using Mech3DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Mech3DotNet.FileCompare;

namespace Mech3DotNetTests
{
    [TestClass]
    public class FileCompareTests
    {
        [TestMethod]
        public void LengthMismatch()
        {
            string result = null;
            using (var src = new TemporaryFile("FooBar"))
            using (var dst = new TemporaryFile("SpamEggs"))
            {
                result = CompareFiles(src, dst);
            }
            Assert.IsNotNull(result);
            StringAssert.StartsWith(result, "Length mismatch");
        }

        [TestMethod]
        public void ByteMismatch()
        {
            string result = null;
            using (var src = new TemporaryFile("FooBar"))
            using (var dst = new TemporaryFile("FooBaz"))
            {
                result = CompareFiles(src, dst);
            }
            Assert.IsNotNull(result);
            StringAssert.StartsWith(result, "Byte mismatch");
        }

        [TestMethod]
        public void NoMismatch()
        {
            string result = null;
            using (var src = new TemporaryFile("FooBar"))
            using (var dst = new TemporaryFile("FooBar"))
            {
                result = CompareFiles(src, dst);
            }
            Assert.IsNull(result);
        }
    }
}
