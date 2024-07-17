using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.GetAllProductQuery
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, PaginatedResponse<GetAllProductResponse>>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResponse<GetAllProductResponse>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Product> list;
                if (string.IsNullOrEmpty(request.Search))
                {
                    list = await _productRepository.GetAll(cancellationToken);
                }
                else
                {
                    list = await _productRepository.Search(request.Search,cancellationToken);
                }
                list = list.OrderBy(x => x.Name).ToList();
                var totalRecord = list.Count;
                if (request.TotalSize > 0)
                    list = list.Skip((request.PageIndex -1 ) * request.TotalSize).Take(request.TotalSize).ToList();

                var response =  _mapper.Map<List<GetAllProductResponse>>(list);
                return new PaginatedResponse<GetAllProductResponse>(response, request.PageIndex, request.TotalSize, totalRecord);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
