using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.RegisterCommand
{
    public record RegisterCommandRequest:IRequest<ErrorOr<RegisterCommandResponce>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone_Number { get; set; } = string.Empty;
        public string User_Role { get; set;} = string.Empty;
    }
}
