using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace WebApp.Helpers
{
    public static class SessionParameterHelper
    {
        public static void SetValue(this ISession session, string key, object value)
        {
            if (value == null)
                return;

            var stringValue = value is string ? value.ToString() : JsonConvert.SerializeObject(value);
            session.SetString(key, stringValue);
        }

        public static TInSession GetValue<TInSession>(this ISession session, string key)
        {
            var defaultValue = default(TInSession);
            var value = session.GetString(key);

            if (value == null)
                return defaultValue;

            try
            {
                return JsonConvert.DeserializeObject<TInSession>(value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static string GetValue(this ISession session, string key) => session.GetString(key);
    }
}
