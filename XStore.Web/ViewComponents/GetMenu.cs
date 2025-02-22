using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;

namespace XStore.WebClient.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly IMenuFacad _menuFacad;

        public GetMenu(IMenuFacad menuFacad)
        {
            _menuFacad = menuFacad;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _menuFacad.GetCategoriesForMenuService.Execute().Data;
            return View(viewName:"GetMenu",categories);
        }
    }
}
