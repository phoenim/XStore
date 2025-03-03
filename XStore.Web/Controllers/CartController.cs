using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Common.Utilities;

namespace XStore.WebClient.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartFacad _cartFacad;
        private readonly CookiesManager _cookiesManager;

        public CartController (ICartFacad cartFacad)
        {
            _cartFacad = cartFacad;
            _cookiesManager = new CookiesManager();
        }

        public IActionResult AddToCart (long productId, bool isIncreas = false)
        {
            var res = _cartFacad.AddToCartService.Execute(productId, _cookiesManager.GetBrowserId(HttpContext));

            if (!isIncreas)
            {
                return Json(res);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Index()
        {
            var result = _cartFacad.GetCartService.Execute(_cookiesManager.GetBrowserId(HttpContext));

            return View(result.Data);
        }

        public IActionResult RemoveFromCart(long productId)
        {
            var res = _cartFacad.RemoveFromCartService.Execute(productId, _cookiesManager.GetBrowserId(HttpContext), 1);
            return RedirectToAction("Index");
        }
    }
}
