using Application.Services.AreaServices.Command.DeleteAreaCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.DeleteQuotationCommand
{
    public record DeleteQuotationRequest : IRequest<DeleteQuotationResponse>
    {
        public Guid Id { get; set; }
    }
}
