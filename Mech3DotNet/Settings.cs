using Mech3DotNet.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;

namespace Mech3DotNet
{
    public static class Settings
    {
        public static JsonSerializerSettings Serialization = GetSerializerSettings(GetDefaultConverters());

        public delegate string JsonTransform(string json);

        public static JsonTransform PreDeserializeHook = null;
        public static JsonTransform PostSerializeHook = null;

        public static List<JsonConverter> GetDefaultConverters() => new List<JsonConverter>
        {
            new MotionPartConverter<Vec3, Vec4>(),
        };

        public static JsonSerializerSettings GetSerializerSettings(IList<JsonConverter> converters)
        {
            return new JsonSerializerSettings()
            {
                //Binder
                CheckAdditionalContent = true,
                ConstructorHandling = ConstructorHandling.Default,
                //Context
                //ContractResolver
                Converters = converters,
                Culture = CultureInfo.InvariantCulture,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                //DateFormatString
                DateParseHandling = DateParseHandling.DateTime,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DefaultValueHandling = DefaultValueHandling.Include,
                //EqualityComparer
                //Error
                Formatting = Formatting.None,
                FloatFormatHandling = FloatFormatHandling.DefaultValue,
                FloatParseHandling = FloatParseHandling.Double,
                //MaxDepth
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Error,
                NullValueHandling = NullValueHandling.Include,
                //ObjectCreationHandling
                //PreserveReferencesHandling
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                //ReferenceResolver
                //ReferenceResolverProvider
                StringEscapeHandling = StringEscapeHandling.Default,
                //TraceWriter
                //TypeNameAssemblyFormat
                //TypeNameHandling
            };
        }

        public static JsonSerializerSettings GetSerializerSettings(params JsonConverter[] converters) =>
            GetSerializerSettings(new List<JsonConverter>(converters));

        public static T DeserializeObject<T>(string json)
        {
            if (Settings.PreDeserializeHook != null)
                json = Settings.PreDeserializeHook(json);
            return JsonConvert.DeserializeObject<T>(json, Settings.Serialization);
        }

        public static string SerializeObject(object value)
        {
            var json = JsonConvert.SerializeObject(value, Settings.Serialization);
            if (Settings.PostSerializeHook != null)
                json = Settings.PostSerializeHook(json);
            return json;
        }
    }
}
