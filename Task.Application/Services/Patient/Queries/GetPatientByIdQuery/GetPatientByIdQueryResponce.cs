using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Patient.Query.GetPatientByIdQuery
{
    public record GetPatientByIdQueryResponce
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactInfo { get; set; }
        public string Status { get; set; }
    }
}
