using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.RegisterCommand
{
    public record RegisterCommandResponce
    {
        public string Message { get; set; } = string.Empty;
    }
}
