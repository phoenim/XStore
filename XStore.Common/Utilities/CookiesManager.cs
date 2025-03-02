using Microsoft.AspNetCore.Http;

namespace XStore.Common.Utilities
{
    public class CookiesManager
    {
        public static void Add(HttpContext context, string key, string value, int days)
        {
            context.Response.Cookies.Append(key,value, getCookieOptions(context,days));
        }

        public static bool Contains(HttpContext context, string key)
        {
            return context.Request.Cookies.ContainsKey(key);
        }

        public static string GetValue (HttpContext context, string key)
        {
            string cookieValue;

            if(context.Request.Cookies.TryGetValue(key,out cookieValue))
            {
                return cookieValue;
            }

            return null;
        }

        private static CookieOptions getCookieOptions (HttpContext context, int days)
        {
            return new CookieOptions()
            {
                HttpOnly = true,
                Path = context.Request.PathBase.HasValue ? context.Request.PathBase.ToString() : "/",
                Secure = context.Request.IsHttps,
                Expires = DateTime.Now.AddDays(days)
            };
        }
    }
}
