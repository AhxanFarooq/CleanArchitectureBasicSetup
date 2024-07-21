using Application.Common.Exceptions;
using Application.Repositories;
using Domain.Entities;
using MediatR;

namespace Application.Services.QuotationServices.Queries.GetAutoCode
{
    public class GetAutoCodeHandler : IRequestHandler<GetAutoCodeRequest, GetAutoCodeResponse>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IUnitOfWork _unitOfWork;
        public GetAutoCodeHandler(IQuotationRepository quotationRepository, IUnitOfWork unitOfWork)
        {
            _quotationRepository = quotationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<GetAutoCodeResponse> Handle(GetAutoCodeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var autoCode = await _quotationRepository.GetAutoCode( cancellationToken);
                if (string.IsNullOrEmpty(autoCode))
                {
                    return new GetAutoCodeResponse()
                    {
                        Code = GenerateCodeFirstTime()
                    };
                }
                return new GetAutoCodeResponse()
                {
                    Code = GenerateNewCode(autoCode)
                };

                

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
        public string GenerateCodeFirstTime()
        {
            return "QT-00001";
        }

        public string GenerateNewCode(string soNumber)
        {
            string fetchNo = soNumber.Substring(3);
            Int32 autoNo = Convert.ToInt32((fetchNo));
            var format = "QT-00000";
            autoNo++;
            var newCode = autoNo.ToString(format);
            return newCode;
        }
    }

}
