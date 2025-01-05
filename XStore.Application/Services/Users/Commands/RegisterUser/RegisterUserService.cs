using XStore.Application.Interfaces.Context;
using XStore.Common;
using XStore.Common.Dto;
using XStore.Domain.Entities.Users;

namespace XStore.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResultRegisterUserDto> Execute (RequestRegisterUserDto request)
        {
            try
            {
                if(String.IsNullOrWhiteSpace(request.Email) ||
                   String.IsNullOrWhiteSpace(request.FullName) ||
                   String.IsNullOrWhiteSpace(request.Password) ||
                   String.IsNullOrWhiteSpace(request.RePassword))
                {
                    return new Result<ResultRegisterUserDto>()
                    {
                        IsSuccess = false,
                        Message = "مقادیر به درستی وارد نشده اند."
                    };
                }
                else
                {
                    if (request.Password.Equals(request.RePassword))
                    {
                        PasswordHasher passwordHasher = new PasswordHasher();
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
                        temp.password = passwordHasher.HashPassword(request.Password);
                        temp.IsActived = true;

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

                    else
                    {
                        return new Result<ResultRegisterUserDto>()
                        {
                            IsSuccess = false,
                            Message = "تکرار رمز عبور اشتباه است."
                        };
                    }
                }
                
            }
            catch (Exception ex)
            {
                return new Result<ResultRegisterUserDto>()
                {
                    IsSuccess = false,
                    Message = "عملیات ثبت نام با مشکل مواجه شد"
                };
            }


        }
    }

}
