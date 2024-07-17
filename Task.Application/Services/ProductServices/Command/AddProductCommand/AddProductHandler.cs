using Application.Common.Exceptions;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.AddProductCommand
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public AddProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                
                var Product = _mapper.Map<Product>(request);

                //Validate Product already exist
                var isAlreadyExist = await _productRepository.VerifyAlreadyExist(Product.Name, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistException(" Product is already exist.");
                _productRepository.Create(Product);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new AddProductResponse()
                {
                    Id = Product.Id,
                    Message = "Product has been created"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
