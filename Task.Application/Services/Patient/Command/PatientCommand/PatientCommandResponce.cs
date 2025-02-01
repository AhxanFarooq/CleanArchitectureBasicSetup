using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.PatientCommand
{
    public record PatientCommandResponce
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
