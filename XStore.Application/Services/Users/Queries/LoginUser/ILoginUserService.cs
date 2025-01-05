using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Users.Queries.LoginUser
{
    public interface ILoginUserService
    {
        Result<ResultLoginUserDto> Execute(RequestLoginUser request);
    }
}
