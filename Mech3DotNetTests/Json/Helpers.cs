using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mech3DotNetTests.Json
{
    internal static class Helpers
    {
        internal static string Normalize(string json)
        {
            return JToken.Parse(json).ToString(Formatting.None);
        }

        internal static string Normalize(string json, JsonSerializerSettings settings)
        {
            return JToken.Parse(json).ToString(settings.Formatting);
        }

        internal static void ThrowsExceptionOfType(Type type, Action action)
        {
            typeof(Assert)
                .GetMethod("ThrowsException", new Type[] { typeof(Action) })
                .MakeGenericMethod(type)
                .Invoke(null, new object[] { action });
        }

        internal static void AssertFieldsDefault<T>(T value, params string[] excludeFields)
        {
            var type = typeof(T);
            var exclude = new List<string>(excludeFields);

            foreach (var fieldInfo in type.GetFields())
            {
                if (exclude.Contains(fieldInfo.Name))
                    continue;
                var fieldValue = fieldInfo.GetValue(value);
                var fieldDefault = GetDefault(fieldInfo.FieldType);
                Assert.AreEqual(fieldDefault, fieldValue, fieldInfo.Name);
            }
        }

        internal static object GetDefault(Type type)
        {
            var method = typeof(Helpers).GetMethod(nameof(GetDefaultGeneric), BindingFlags.Static | BindingFlags.NonPublic);
            return method.MakeGenericMethod(type).Invoke(null, null);
        }

        internal static T GetDefaultGeneric<T>()
        {
            return default(T);
        }
    }
}
