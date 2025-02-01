using Application.Services.Common;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Authentication.Command.RecommendationCommand
{
    public record RecommendationCommandRequest:BaseRequest,IRequest<ErrorOr<RecommendationCommandResponce>>
    {
        public string Type { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public Guid PatientId { get; set; }
    }
}
