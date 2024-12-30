using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUser
    {
        Result<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

    public class RegisterUser : IRegisterUser
    {
        private readonly IDataBaseContext _context;

        public RegisterUser (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResultRegisterUserDto> Execute (RequestRegisterUserDto request)
        {
            User temp = new User()
            {
                Email = request.Email,
                FullName = request.FullName,
            };

            return null;
        }
    }

    public class ResultRegisterUserDto
    {
        public long Id { get; set; }
    }

    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RoleInRegisterUserDto> Roles { get; set; }
    }

    public class RoleInRegisterUserDto
    {
        public long Id {  set; get; }
    }

}
