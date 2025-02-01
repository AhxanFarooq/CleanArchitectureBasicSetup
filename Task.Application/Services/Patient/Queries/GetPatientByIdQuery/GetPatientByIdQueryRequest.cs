using Application.Services.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Patient.Query.GetPatientByIdQuery
{
    public record GetPatientByIdQueryRequest:BaseRequest,IRequest<ErrorOr<GetPatientByIdQueryResponce>>
    {
        public Guid Id { get; set; }
    }
}
