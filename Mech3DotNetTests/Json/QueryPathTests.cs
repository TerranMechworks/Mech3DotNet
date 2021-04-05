using Mech3DotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using S = Mech3DotNet.QueryPath.Segment;

namespace Mech3DotNetTests.Json
{
    [TestClass]
    public class QueryPathTests
    {
        [TestMethod]
        public void QueryPath_EmptyString_ThrowsArgument()
        {
            Assert.ThrowsException<ArgumentException>(() => new QueryPath(""));
        }

        [TestMethod]
        public void QueryPath_NotRooted_ThrowsArgument()
        {
            Assert.ThrowsException<ArgumentException>(() => new QueryPath("Foo"));
        }

        [DataTestMethod]
        [DataRow("//")]
        [DataRow("/Foo/")]
        [DataRow("/Foo//Bar")]
        public void QueryPath_ContainsEmptySegment_ThrowsArgument(string path)
        {
            Assert.ThrowsException<ArgumentException>(() => new QueryPath(path));
        }

        public static IEnumerable<object[]> GetTestSegments()
        {
            yield return new object[] { "/" };
            yield return new object[] { "/foo", S.K("foo") };
            yield return new object[] { "/42", S.I(42) };
            yield return new object[] { "/`42", S.K("42") };
            yield return new object[] { "/foo/bar", S.K("foo"), S.K("bar") };
            yield return new object[] { "/foo/42", S.K("foo"), S.I(42) };
            yield return new object[] { "/42/bar", S.I(42), S.K("bar") };
        }

        [DynamicData(nameof(GetTestSegments), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void QueryPath_Segments_AreParsed(string queryPath, params S[] expected)
        {
            var path = new QueryPath(queryPath);
            var segments = new List<S>(path);
            var actual = segments.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
