using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common;
using XStore.Common.Dto;

namespace XStore.Application.Services.Users.Queries.LoginUser
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IDataBaseContext _context;

        public LoginUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResultLoginUserDto> Execute(RequestLoginUser request)
        {
            var user = _context.Users.Include(p => p.UserInRoles)
                    .ThenInclude(p => p.Role)
                    .FirstOrDefault(u => u.Email.Equals(request.Email));

            if (user == null)
            {
                return new Result<ResultLoginUserDto>()
                {
                    Data = new ResultLoginUserDto() { },
                    IsSuccess = false,
                    Message = "حسابی با این ایمیل یافت نشد",

                };
            }

            if (!user.IsActived)
            {
                return new Result<ResultLoginUserDto> 
                {
                    Data = new ResultLoginUserDto() { },
                    IsSuccess=false,
                    Message = "این حساب کاربری غیر فعال است"
                };
            }

            PasswordHasher hasher = new PasswordHasher();
            if (!hasher.VerifyPassword(user.password, request.Password))
            {
                return new Result<ResultLoginUserDto>()
                {
                    Data = new ResultLoginUserDto() { },
                    IsSuccess = false,
                    Message = "رمز عبور اشتباه است"
                };
            }

            var roles = "";
            foreach (var item in user.UserInRoles)
            {
                roles += $"{item.Role.Name}";
            }

            return new Result<ResultLoginUserDto>()
            {
                Data = new ResultLoginUserDto()
                {
                    Id = user.Id,
                    Name = user.FullName,
                    Roles = roles
                },

                IsSuccess = true,
                Message = "ورود موفقیت آمیز بود"
            };
        }
    }
}
