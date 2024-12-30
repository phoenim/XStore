using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Users;

namespace Etar.Application.Services.Users.Commands.RegisterUser
{
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

            List<UserInRole> userInRoles = new List<UserInRole>();
            foreach (var item in request.Roles)
            {
                var role = _context.Roles.Find(item.Id);
                userInRoles.Add(new UserInRole()
                {
                    Role = role,
                    User = temp,
                    RoleId = role.Id,
                    UserId = temp.Id,
                    
                });
            }

            temp.UserInRoles = userInRoles;

            _context.Users.Add(temp);
            _context.SaveChanges();

            return new Result<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    Id = temp.Id,
                },

                IsSuccess = true,
                Message = "ثبت نام کاربر جدید با موفقیت انجام شد"
            };
        }
    }

}
