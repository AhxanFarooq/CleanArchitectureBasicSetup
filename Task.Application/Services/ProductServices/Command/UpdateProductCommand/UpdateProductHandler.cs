using Application.Common.Exceptions;
using Application.ProductServices.ProductServices.UpdateProductCommand;
using Application.Repositories;
using Application.Services.ProductServices.Command.AddProductCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.UpdateProductCommand
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
                if (product is null)
                    throw new NotFoundException("Record not found");

                //Validate Product already exist
                if(product.Name != request.Name)
                {
                    var isAlreadyExist = await _productRepository.VerifyAlreadyExist(request.Name, cancellationToken);
                    if (isAlreadyExist)
                        throw new AlreadyExistException(" Product is already exist.");
                }
                product.Name = request.Name;
                product.SalePrice = request.SalePrice;
                product.RetailPrice = request.RetailPrice;
                product.Description = request.Description;
                product.IsActive =   request.IsActive;

                _productRepository.Update(product);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new UpdateProductResponse()
                {
                    Message = "Product has been update"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
