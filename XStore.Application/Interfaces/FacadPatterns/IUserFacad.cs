using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Services.Users.Commands.RegisterUser;
using XStore.Application.Services.Users.Commands.RemoveUser;
using XStore.Application.Services.Users.Commands.StatusChangeUser;
using XStore.Application.Services.Users.Queries.GetRoles;
using XStore.Application.Services.Users.Queries.GetUsers;
using XStore.Application.Services.Users.Queries.LoginUser;

namespace XStore.Application.Interfaces.FacadPatterns
{
    public interface IUserFacad
    {
        RegisterUserService registerUserService { get; }
        RemoveUserService removeUserService { get; }
        StatusChangeUserService statusChangeUserService { get; }
        GetRolesService getRolesService { get; }
        GetUsersService getUsersService { get; }
        LoginUserService loginUserService { get; }
    }
}
