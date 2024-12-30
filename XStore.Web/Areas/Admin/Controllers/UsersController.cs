using XStore.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace XStore.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;

        public UsersController(IGetUsersService getUsersService)
        {
            _getUsersService = getUsersService;
        }

        [Area("Admin")]
        public IActionResult Index(string searchKey, int page =1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey,
            }));
        }
    }
}
