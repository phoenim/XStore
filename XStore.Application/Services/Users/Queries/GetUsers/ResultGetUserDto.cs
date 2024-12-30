using System.Collections.Generic;

namespace XStore.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUserDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int UsersCount { get; set; }
    }
}
