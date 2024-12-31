using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Application.Services.Users.Commands.RegisterUser.Page
{
    public class RequestRegisterUserPageDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string RePassword { get; set; }

        public long RoleId { get; set; }
    }
}
