using XStore.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using XStore.Common;

namespace XStore.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;

        public GetUsersService (IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUserDto Execute (RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();

            if(!String.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;
            var usersList = users.ToPaged(request.Page, 30, out rowsCount).Select(p => new GetUsersDto
            {
                Email = p.Email,
                Name = p.FullName,
                Id = p.Id,
                IsActive = p.IsActived,
            }).ToList();

            return new ResultGetUserDto
            {
                Users = usersList,
                UsersCount = rowsCount,
            };
        }
    }
}
