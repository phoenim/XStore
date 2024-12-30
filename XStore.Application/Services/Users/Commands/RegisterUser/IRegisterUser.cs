using XStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUser
    {
        Result<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
    }

}
