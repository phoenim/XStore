using XStore.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using XStore.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc.Rendering;
using XStore.Application.Services.Users.Commands.RegisterUser;
using XStore.Application.Services.Users.Commands.RemoveUser;
using XStore.Application.Services.Users.Commands.StatusChangeUser;
using XStore.Application.Interfaces.FacadPatterns;

namespace XStore.WebAdmin.Controllers
{
    public class UsersController : Controller
    { 

        private readonly IUserFacad _userFacad;


        public UsersController(IUserFacad userFacad)
        {
            _userFacad = userFacad;
        }

        public IActionResult Index(string searchKey, int page =1)
        {
            return View(_userFacad.getUsersService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchKey,
            }));
        }

        [HttpGet]
        public IActionResult Create ()
        {
            ViewBag.Roles = new SelectList(_userFacad.getRolesService.Execute().Roles,"Id", "Name");
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

            var result = _userFacad.registerUserService.Execute(request);
            return Json(result);
        }


        [HttpPost]
        public IActionResult Remove(long id)
        {
            var result = _userFacad.removeUserService.Execute(id);
            return Json(result);
        }

   
        public IActionResult ChangeStatus(long id, bool newStatus = false)
        {
            var result = _userFacad.statusChangeUserService.Execute(id, newStatus);
            return Json(result);
        }

    }
}
