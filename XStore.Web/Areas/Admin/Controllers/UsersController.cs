using XStore.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using XStore.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace XStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    { 
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;

        public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
        }

        public IActionResult Index(string searchKey, int page =1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey,
            }));
        }

        public IActionResult Create ()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Roles,"Id", "Name");
            return View();
        }
    }
}
