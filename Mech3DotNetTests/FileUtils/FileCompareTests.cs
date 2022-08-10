using Mech3DotNet.FileUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests.FileUtils
{
    [TestClass]
    public class FileCompareTests
    {
        [TestMethod]
        public void LengthMismatch()
        {
            string? result = null;
            using (var src = new TemporaryFile("FooBar"))
            using (var dst = new TemporaryFile("SpamEggs"))
            {
                result = FileCompare.CompareFiles(src, dst);
            }
            Assert.IsNotNull(result);
            StringAssert.StartsWith(result, "Length mismatch");
        }

        [TestMethod]
        public void ByteMismatch()
        {
            string? result = null;
            using (var src = new TemporaryFile("FooBar"))
            using (var dst = new TemporaryFile("FooBaz"))
            {
                result = FileCompare.CompareFiles(src, dst);
            }
            Assert.IsNotNull(result);
            StringAssert.StartsWith(result, "Byte mismatch");
        }

        [TestMethod]
        public void NoMismatch()
        {
            string? result = null;
            using (var src = new TemporaryFile("FooBar"))
            using (var dst = new TemporaryFile("FooBar"))
            {
                result = FileCompare.CompareFiles(src, dst);
            }
            Assert.IsNull(result);
        }
    }
}
