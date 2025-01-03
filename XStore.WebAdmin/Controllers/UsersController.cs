using XStore.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using XStore.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc.Rendering;
using XStore.Application.Services.Users.Commands.RegisterUser;
using XStore.Application.Services.Users.Commands.RemoveUser;
using XStore.Application.Services.Users.Commands.StatusChangeUser;

namespace XStore.WebAdmin.Controllers
{
    public class UsersController : Controller
    { 
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IStatusChangeUserService _statusChangeUserService;


        public UsersController(IGetUsersService getUsersService, 
                               IGetRolesService getRolesService,
                               IRegisterUserService registerUserService,
                               IRemoveUserService removeUserService,
                               IStatusChangeUserService statusChangeUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _statusChangeUserService = statusChangeUserService;
        }

        public IActionResult Index(string searchKey, int page =1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey,
            }));
        }

        [HttpGet]
        public IActionResult Create ()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Roles,"Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string email, string fullName, long roleId, string password, string rePassword)
        {
            RequestRegisterUserDto request = new RequestRegisterUserDto()
            {
                Email = email,
                FullName = fullName,
                Password = password,
                RePassword = rePassword,
                Roles = new List<RoleInRegisterUserDto>()
                {
                   new RoleInRegisterUserDto()
                   {
                       Id = roleId,
                   }
                }

            };

            var result = _registerUserService.Execute(request);
            return Json(result);
        }


        [HttpPost]
        public IActionResult Remove(long id)
        {
            var result = _removeUserService.Execute(id);
            return Json(result);
        }

   
        public IActionResult ChangeStatus(long id, bool newStatus = false)
        {
            var result = _statusChangeUserService.Execute(id, newStatus);
            return Json(result);
        }

    }
}
