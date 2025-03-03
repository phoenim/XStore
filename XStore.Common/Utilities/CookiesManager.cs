using Microsoft.AspNetCore.Http;

namespace XStore.Common.Utilities
{
    public class CookiesManager
    {
        public void Add(HttpContext context, string key, string value, int days)
        {
            context.Response.Cookies.Append(key,value, getCookieOptions(context,days));
        }

        public bool Contains(HttpContext context, string key)
        {
            return context.Request.Cookies.ContainsKey(key);
        }

        public string GetValue (HttpContext context, string key)
        {
            string cookieValue;

            if(context.Request.Cookies.TryGetValue(key,out cookieValue))
            {
                return cookieValue;
            }

            return null;
        }

        public Guid GetBrowserId (HttpContext context)
        {
            var browserId = GetValue(context, "BrowserId");

            if(browserId == null)
            {
                browserId = Guid.NewGuid().ToString();
                Add(context, "BrowserId", browserId, 10);
            }

            Guid browserGuid;
            Guid.TryParse(browserId, out browserGuid);

            return browserGuid;
        }

        private CookieOptions getCookieOptions (HttpContext context, int days)
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
