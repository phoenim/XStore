using XStore.Application.Interfaces.FacadPatterns;
using Microsoft.AspNetCore.Mvc;

namespace XStore.WebClient.ViewComponents
{
    public class SearchProduct : ViewComponent
    {
        private readonly IProductFacad _productFacad;

        public SearchProduct (IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IViewComponentResult Invoke ()
        {
            return View(viewName:"SearchProduct");
        }
    }
}
