using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Command.UpdateUser
{
    public record UpdateUserRequest(Guid Id, string FirstName, string LastName, string Device, string IpAddress, string browser, decimal? balance):IRequest<UpdateUserResponse>;
}
