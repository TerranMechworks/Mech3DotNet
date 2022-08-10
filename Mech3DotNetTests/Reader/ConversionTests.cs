using System;
using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Mech3DotNetTests.Reader
{
    [TestClass]
    public class ConversionTests
    {
        IEnumerable<string> EmptyPath()
        {
            return new List<string>() { "", "path" };
        }

        T ConvertSuccess<T>(string json, IReaderConverter<T> converter, ReaderDeserializer deserializer)
        {
            var token = JToken.Parse(json);
            return converter.ConvertTo(deserializer, token, EmptyPath());
        }

        string ConvertFailure(string json, IReaderConverter converter, ReaderDeserializer deserializer)
        {
            var token = JToken.Parse(json);
            var e = Assert.ThrowsException<InvalidTypeException>(() => converter.Convert(deserializer, token, EmptyPath()));
            return e.Message;
        }

        [DataTestMethod]
        [DataRow("'foo'")]
        [DataRow("['foo']")]
        public void ToString_Valid_ReturnsString(string json)
        {
            var actual = ConvertSuccess(json, new ToString(), null);
            Assert.AreEqual("foo", actual);
        }

        [DataTestMethod]
        [DataRow("42")]
        [DataRow("42.1")]
        [DataRow("null")]
        [DataRow("[42]")]
        [DataRow("[42.1]")]
        [DataRow("[null]")]
        [DataRow("{}")]
        public void ToString_Invalid_Throws(string json)
        {
            var message = ConvertFailure(json, new ToString(), null);
            StringAssert.EndsWith(message, ". Path '/path'.");
        }

        [DataTestMethod]
        [DataRow("42")]
        [DataRow("[42]")]
        public void ToInt_Valid_ReturnsInt(string json)
        {
            var actual = ConvertSuccess(json, new ToInt(), null);
            Assert.AreEqual(42, actual);
        }

        [DataTestMethod]
        [DataRow("'foo'")]
        [DataRow("42.1")]
        [DataRow("null")]
        [DataRow("['foo']")]
        [DataRow("[42.1]")]
        [DataRow("[null]")]
        [DataRow("{}")]
        public void ToInt_Invalid_Throws(string json)
        {
            var message = ConvertFailure(json, new ToInt(), null);
            StringAssert.EndsWith(message, ". Path '/path'.");
        }

        [DataTestMethod]
        [DataRow("42.0")]
        [DataRow("[42.0]")]
        [DataRow("42")]
        [DataRow("[42]")]
        public void ToFloat_Valid_ReturnsFloat(string json)
        {
            var actual = ConvertSuccess(json, new ToFloat(), null);
            Assert.AreEqual(42.0f, actual);
        }

        [DataTestMethod]
        [DataRow("'foo'")]
        [DataRow("null")]
        [DataRow("['foo']")]
        [DataRow("[null]")]
        [DataRow("{}")]
        public void ToFloat_Invalid_Throws(string json)
        {
            var message = ConvertFailure(json, new ToFloat(), null);
            StringAssert.EndsWith(message, ". Path '/path'.");
        }

        [DataTestMethod]
        [DataRow("42.0")]
        [DataRow("[42.0]")]
        public void ToFloatStrict_Valid_ReturnsFloat(string json)
        {
            var actual = ConvertSuccess(json, new ToFloatStrict(), null);
            Assert.AreEqual(42.0f, actual);
        }

        [DataTestMethod]
        [DataRow("'foo'")]
        [DataRow("null")]
        [DataRow("['foo']")]
        [DataRow("[null]")]
        [DataRow("{}")]
        [DataRow("42")]
        [DataRow("[42]")]
        public void ToFloatStrict_Invalid_Throws(string json)
        {
            var message = ConvertFailure(json, new ToFloatStrict(), null);
            StringAssert.EndsWith(message, ". Path '/path'.");
        }

        [DataTestMethod]
        [DataRow("['foo', 'bar']")]
        [DataRow("['foo', ['bar']]")]
        [DataRow("[['foo'], 'bar']")]
        [DataRow("[['foo'], ['bar']]")]
        public void ToListOfString_Valid_ReturnsListOfString(string json)
        {
            var actual = ConvertSuccess(json, new ToList<string>(), new ReaderDeserializer());
            CollectionAssert.AreEqual(new List<string> { "foo", "bar" }, actual);
        }

        [TestMethod]
        public void ToListOfString_Invalid_Throws()
        {
            var json = @"['foo', 42]";
            var message = ConvertFailure(json, new ToList<string>(), new ReaderDeserializer());
            StringAssert.EndsWith(message, ". Path '/path/1'.");
        }

        [DataTestMethod]
        [DataRow("[1, 2]")]
        [DataRow("[1, [2]]")]
        [DataRow("[[1], 2]")]
        [DataRow("[[1], [2]]")]
        public void ToListOfInt_Convert_ReturnsListOfInt(string json)
        {
            var actual = ConvertSuccess(json, new ToList<int>(), new ReaderDeserializer());
            CollectionAssert.AreEqual(new List<int>() { 1, 2 }, actual);
        }

        [TestMethod]
        public void ToListOfInt_Invalid_Throws()
        {
            var json = @"[42, 'foo']";
            var message = ConvertFailure(json, new ToList<int>(), new ReaderDeserializer());
            StringAssert.EndsWith(message, ". Path '/path/1'.");
        }

        [DataTestMethod]
        [DataRow("[1.0, 2.0]")]
        [DataRow("[1.0, [2.0]]")]
        [DataRow("[[1.0], 2.0]")]
        [DataRow("[[1.0], [2.0]]")]
        public void ToListOfFloat_Convert_ReturnsListOfFloat(string json)
        {
            var actual = ConvertSuccess(json, new ToList<float>(), new ReaderDeserializer());
            CollectionAssert.AreEqual(new List<float>() { 1.0f, 2.0f }, actual);
        }

        [TestMethod]
        public void ToListOfFloat_Invalid_Throws()
        {
            var json = @"[1.0, 'foo']";
            var message = ConvertFailure(json, new ToList<float>(), new ReaderDeserializer());
            StringAssert.EndsWith(message, ". Path '/path/1'.");
        }

        class TestClassWithString
        {
            public string foo = default;
            public TestClassWithString() { }
        }

        [TestMethod]
        public void ToClass_ClassWithString_ReturnsClass()
        {
            var token = JToken.Parse(@"['foo', ['bar']]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClassWithString>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            Assert.AreEqual("bar", actual.foo);
        }

        class TestClassWithInt
        {
            public int foo = default;
            public TestClassWithInt() { }
        }

        [TestMethod]
        public void ToClass_ClassWithInt_ReturnsClass()
        {
            var token = JToken.Parse(@"['foo', [42]]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClassWithInt>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            Assert.AreEqual(42, actual.foo);
        }

        class TestClassWithFloat
        {
            public float foo = default;
            public TestClassWithFloat() { }
        }

        [TestMethod]
        public void ToClass_ClassWithFloat_ReturnsClass()
        {
            var token = JToken.Parse(@"['foo', [42.1]]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClassWithFloat>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            Assert.AreEqual(42.1f, actual.foo);
        }

        class TestClass
        {
            public string name;
            public int index;

            public TestClass() { }

            public override bool Equals(object obj)
            {
                return obj is TestClass other &&
                    name == other.name &&
                    index == other.index;
            }

            public override int GetHashCode()
            {
                int hashCode = 1502939027;
                hashCode = hashCode * -1521134295 + name.GetHashCode();
                hashCode = hashCode * -1521134295 + index.GetHashCode();
                return hashCode;
            }
        }

        [TestMethod]
        public void ToClassStrict_Valid_ReturnsClass()
        {
            var token = JToken.Parse(@"['name', ['foo'], 'index', [42]]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClass>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            var expected = new TestClass() { name = "foo", index = 42 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToClassStrict_UnknownKey_Throws()
        {
            var token = JToken.Parse(@"['name', ['foo'], 'index', [42], 'spam', ['eggs']]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClass>();
            var e = Assert.ThrowsException<UnknownFieldException>(() => toClass.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path/4'.");
        }

        [TestMethod]
        public void ToClassStrict_UnfinishedKey_Throws()
        {
            var token = JToken.Parse(@"['name', ['foo'], 'index', [42], 'spam']");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClass>();
            var e = Assert.ThrowsException<ConversionException>(() => toClass.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path/4'.");
        }

        [TestMethod]
        public void ToClassStrict_MissingKey_Throws()
        {
            var token = JToken.Parse(@"['name', ['foo']]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassStrict<TestClass>();
            var e = Assert.ThrowsException<RequiredFieldsException>(() => toClass.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path'.");
        }

        [TestMethod]
        public void ToClassLenient_Valid_ReturnsClass()
        {
            var token = JToken.Parse(@"['name', ['foo'], 'index', [42]]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassLenient<TestClass>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            var expected = new TestClass() { name = "foo", index = 42 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToClassLenient_UnfinishedKey_ReturnsClass()
        {
            var token = JToken.Parse(@"['name', ['foo'], 'index', [42], 'spam']");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassLenient<TestClass>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            var expected = new TestClass() { name = "foo", index = 42 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToClassLenient_UnknownKey_ReturnsClass()
        {
            var token = JToken.Parse(@"['name', ['foo'], 'index', [42], 'spam', ['eggs']]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassLenient<TestClass>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            var expected = new TestClass() { name = "foo", index = 42 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToClassLenient_MissingKey1_ReturnsClass()
        {
            var token = JToken.Parse(@"['name', ['foo']]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassLenient<TestClass>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            var expected = new TestClass() { name = "foo", index = 0 };
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToClassLenient_MissingKey2_ReturnsClass()
        {
            var token = JToken.Parse(@"['index', [42]]");
            var deserializer = new ReaderDeserializer();
            var toClass = new ToClassLenient<TestClass>();
            var actual = toClass.ConvertTo(deserializer, token, EmptyPath());
            var expected = new TestClass() { name = null, index = 42 };
            Assert.AreEqual(expected, actual);
        }

        struct TestStructWithString
        {
            public string foo;
            public TestStructWithString(string foo)
            {
                this.foo = foo;
            }
        }

        [TestMethod]
        public void ToStruct_StructWithString_ReturnsStruct()
        {
            var token = JToken.Parse(@"['bar']");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithString>(typeof(string));
            var actual = toStruct.ConvertTo(deserializer, token, EmptyPath());
            Assert.AreEqual("bar", actual.foo);
        }

        struct TestStructWithInt
        {
            public int foo;
            public TestStructWithInt(int foo)
            {
                this.foo = foo;
            }
        }

        [TestMethod]
        public void ToStruct_StructWithInt_ReturnsStruct()
        {
            var token = JToken.Parse(@"[42]");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithInt>(typeof(int));
            var actual = toStruct.ConvertTo(deserializer, token, EmptyPath());
            Assert.AreEqual(42, actual.foo);
        }

        struct TestStructWithFloat
        {
            public float foo;
            public TestStructWithFloat(float foo)
            {
                this.foo = foo;
            }
        }

        [TestMethod]
        public void ToStruct_StructWithFloat_ReturnsStruct()
        {
            var token = JToken.Parse(@"[42.1]");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithFloat>(typeof(float));
            var actual = toStruct.ConvertTo(deserializer, token, EmptyPath());
            Assert.AreEqual(42.1f, actual.foo);
        }

        [TestMethod]
        public void ToStruct_NotAnArray_Throws()
        {
            var token = JToken.Parse(@"42");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithInt>(typeof(int));
            var e = Assert.ThrowsException<InvalidTypeException>(() => toStruct.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path'.");
        }

        [TestMethod]
        public void ToStruct_TooFewFields_Throws()
        {
            var token = JToken.Parse(@"[]");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithInt>(typeof(int));
            var e = Assert.ThrowsException<ConversionException>(() => toStruct.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path'.");
        }

        [TestMethod]
        public void ToStruct_TooManyFields_Throws()
        {
            var token = JToken.Parse(@"[42, 43]");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithInt>(typeof(int));
            var e = Assert.ThrowsException<ConversionException>(() => toStruct.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path'.");
        }

        [TestMethod]
        public void ToStruct_InvalidFields_ThrowsWithFieldPath()
        {
            var token = JToken.Parse(@"['foo']");
            var deserializer = new ReaderDeserializer();
            var toStruct = new ToStruct<TestStructWithInt>(typeof(int));
            var e = Assert.ThrowsException<InvalidTypeException>(() => toStruct.ConvertTo(deserializer, token, EmptyPath()));
            StringAssert.EndsWith(e.Message, ". Path '/path/0'.");
        }
    }
}
