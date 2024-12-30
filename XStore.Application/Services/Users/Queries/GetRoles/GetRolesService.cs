using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;

namespace XStore.Application.Services.Users.Queries.GetRoles
{
    public class GetRolesService : IGetRolesService
    {
        private readonly IDataBaseContext _context;

        public GetRolesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetRoleDto Execute ()
        {
            ResultGetRoleDto result = new ResultGetRoleDto();
            result.Roles = new List<RoleDto>();

            foreach (var role in _context.Roles)
            {
                result.Roles.Add(new RoleDto()
                {
                    Id = role.Id,
                    Name = role.Name,
                });
            }

            return result;
        }
    }
}
