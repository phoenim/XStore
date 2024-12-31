using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;

namespace XStore.Application.Services.Users.Commands.RemoveUser
{
    public class RemoveUserService : IRemoveUserService
    {
        private readonly IDataBaseContext _context;

        public RemoveUserService (IDataBaseContext context)
        {
            _context = context; 
        }

        public Result Execute(long id)
        {
            var user = _context.Users.Find(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();

                string resultMessage = "با موفقیت حذف شد " + user.FullName + " کاربر";

                return new Result()
                {
                    IsSuccess = true,
                    Message = resultMessage,
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
