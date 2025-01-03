using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Users;

namespace XStore.Application.Services.Users.Commands.StatusChangeUser
{
    public class StatusChangeUserService : IStatusChangeUserService
    {
        private readonly IDataBaseContext _context;
        public StatusChangeUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(long id, bool newStatus = false)
        {
            User user = _context.Users.Find(id);

            if (user != null)
            {
                user.IsActived = newStatus;
                _context.SaveChanges();

                string status = (user.IsActived ? "فعال" : "غیر فعال");
                string resultMessage = "شد" + status + "[" + user.FullName + "]وضعیت کاربر";

                return new Result()
                {
                    IsSuccess = true,
                    Message = resultMessage
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "عملیات با مشکل مواجه شد"
            };
        }
    }
}
