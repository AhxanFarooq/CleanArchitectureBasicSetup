using Application.Services.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.PatientCommand
{
    public record PatientCommandRequest:BaseRequest,IRequest<ErrorOr<PatientCommandResponce>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactInfo { get; set; }
        public string Status { get; set; }
    }
}
