using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Users.Commands.StatusChangeUser
{
    public interface IStatusChangeUserService
    {
        Result Execute(long id, bool newStatus);
    }
}
