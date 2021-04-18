using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Shared
{
    public static class ObjectExtension
    {
        private static JsonSerializerSettings GetSerializeSetting()
        {
            var setting = new JsonSerializerSettings
            {
                MaxDepth = 30,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                DefaultValueHandling = DefaultValueHandling.Populate,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return setting;
        }


        public static string GetString(this object source, string defaulValue = "")
        {
            if (source == null) return defaulValue;
            var result = Convert.ToString(source);
            if (result.IsNullOrEmpty()) return defaulValue;
            return result;
        }

        public static string GetJson(this object source)
        {
            var setting = GetSerializeSetting();
            var result = JsonConvert.SerializeObject(source, setting);
            return result;
        }

        public static int GetInt(this object source, int defaultValue = 0)
        {
            var src = source.GetString();
            var value = defaultValue;
            var succeed = int.TryParse(src, out value);
            if (succeed == false) return defaultValue;
            return value;
        }

        public static long GetLong(this object source, long defaultValue = 0)
        {
            var src = source.GetString();
            var value = defaultValue;
            var succeed = long.TryParse(src, out value);
            if (succeed == false) return defaultValue;
            return value;
        }

        public static bool GetBoolean(this object source, bool defaultValue = false)
        {
            var src = source.GetString();
            var value = defaultValue;
            var succeed = bool.TryParse(src, out value);
            if (succeed == false) return defaultValue;
            return value;
        }

        public static double GetDouble(this object source, double defaultValue = 0.0)
        {
            var src = source.GetString();
            var value = defaultValue;
            var succeed = double.TryParse(src, out value);
            if (succeed == false) return defaultValue;
            return value;
        }

        public static DateTime GetDateTime(this object source)
        {
            var src = source.GetString();
            var value = DateTime.MinValue;

            DateTime.TryParse(src, out value);
            return value;
        }

        public static DateTime GetDateTime(this object source, DateTime defaultValue)
        {
            var src = source.GetString();
            var value = defaultValue;
            var succeed = DateTime.TryParse(src, out value);
            if (succeed) return value;
            return defaultValue;
        }

        public static Guid GetGuid(this object source)
        {
            var src = source.GetString();
            var value = Guid.Empty;
            var succeed = Guid.TryParse(src, out value);
            if (succeed) return value;
            return Guid.Empty;
        }

        public static Guid GetGuid(this object source, Guid defaultValue)
        {
            var src = source.GetString();
            var value = defaultValue;
            var succeed = Guid.TryParse(src, out value);
            if (succeed) return value;
            return defaultValue;
        }

        public static decimal GetDecimal(this object source, decimal defaultValue = 0)
        {
            var value = source.GetString();
            var succeed = decimal.TryParse(value, out decimal result);
            if (succeed) return result;
            return defaultValue;
        }
        

    }
}
