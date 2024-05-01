using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Queries.SignInUser
{
    public record SignInUserRequest(string UserName, string Password,string Device, string Browser, string IpAddress):IRequest<SignInUserResponse>;
    
}
