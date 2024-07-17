using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.ProductServices.Command.GetAllProductQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.GetProductQuery
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IMapper _mapper;
        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
                return _mapper.Map<GetProductResponse>(record);
            }
            catch (Exception ex)
            {
                throw new BadRequestException( ex.Message);
            }
        }
    }
}
