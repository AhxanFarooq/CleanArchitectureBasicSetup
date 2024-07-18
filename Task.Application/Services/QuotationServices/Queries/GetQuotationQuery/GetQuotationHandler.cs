using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.GetQuotationQuery;
using Application.Services.QuotationServices.Command.GetQuotationQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.GetQuotationQuery
{
    public class GetQuotationHandler : IRequestHandler<GetQuotationRequest, GetQuotationResponse>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IMapper _mapper;
        public GetQuotationHandler(IQuotationRepository quotationRepository, IMapper mapper)
        {
            _quotationRepository = quotationRepository;
            _mapper = mapper;
        }
        public async Task<GetQuotationResponse> Handle(GetQuotationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _quotationRepository.GetQuotationByIdWithItem(request.Id, cancellationToken);
                return _mapper.Map<GetQuotationResponse>(record);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
