using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Domain.Entities.Users;

namespace XStore.Application.Services.Users.Queries.GetRoles
{
    public class ResultGetRoleDto
    {
        public List<RoleDto> Roles { get; set; }
    }
}
