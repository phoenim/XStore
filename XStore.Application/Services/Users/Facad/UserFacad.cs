using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Users.Commands.RegisterUser;
using XStore.Application.Services.Users.Commands.RemoveUser;
using XStore.Application.Services.Users.Commands.StatusChangeUser;
using XStore.Application.Services.Users.Queries.GetRoles;
using XStore.Application.Services.Users.Queries.GetUsers;
using XStore.Application.Services.Users.Queries.LoginUser;

namespace XStore.Application.Services.Users.Facad
{
    public class UserFacad : IUserFacad
    {
        private readonly IDataBaseContext _context;

        public UserFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private RegisterUserService _registerUserService;
        public RegisterUserService registerUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);
            }
        }


        private RemoveUserService _removeUserService;
        public RemoveUserService removeUserService
        {
            get
            {
                return _removeUserService = _removeUserService ?? new RemoveUserService(_context);
            }
        }


        private StatusChangeUserService _statusChangeUserService;
        public StatusChangeUserService statusChangeUserService
        {
            get
            {
                return _statusChangeUserService = _statusChangeUserService ?? new StatusChangeUserService(_context);
            }
        }


        private GetRolesService _getRolesService;
        public GetRolesService getRolesService
        {
            get
            {
                return _getRolesService = _getRolesService ?? new GetRolesService(_context);
            }
        }


        private GetUsersService _getUsersService;
        public GetUsersService getUsersService
        {
            get
            {
                return _getUsersService = _getUsersService ?? new GetUsersService(_context);
            }
        }

        public LoginUserService _loginUserService;
        public LoginUserService loginUserService
        {
            get
            {
                return _loginUserService = _loginUserService ?? new LoginUserService(_context);
            }
        }

    }
}
