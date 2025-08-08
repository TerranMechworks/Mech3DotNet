using System;
using System.Collections.Generic;
using Mech3DotNet.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mech3DotNetTests.Reader
{
    public static class Helpers
    {
        public static ReaderInt RI(int value) => new ReaderInt(value);
        public static ReaderFloat RF(float value) => new ReaderFloat(value);
        public static ReaderString RS(string value) => new ReaderString(value);
        public static ReaderList RL(params object[] values)
        {
            var conv = new List<ReaderValue>(values.Length);
            foreach (var value in values)
            {
                ReaderValue v = value switch
                {
                    int i => RI(i),
                    float f => RF(f),
                    string s => RS(s),
                    ReaderInt ri => ri,
                    ReaderFloat rf => rf,
                    ReaderString rs => rs,
                    ReaderList rl => rl,
                    _ => throw new ArgumentOutOfRangeException(),

                };
                conv.Add(v);
            }
            return new ReaderList(conv);
        }

        public static object[] O(params object[] values) => values;

        public static IEnumerable<string> EmptyPath() => new List<string>() { "", "path" };

        public static TConv ConvertSuccess<TConv>(ReaderValue value, IConvertOperation<TConv> op)
        {
            return op.ConvertTo(value, EmptyPath());
        }

        public static string ConvertFailure<TConv>(ReaderValue value, IConvertOperation<TConv> op)
        {
            var e = Assert.ThrowsExactly<ConversionException>(() => op.ConvertTo(value, EmptyPath()));
            return e.Message;
        }
    }
}
