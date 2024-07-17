using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.ProductServices.Command.AddProductCommand;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.DeleteProductCommand
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        protected readonly IProductRepository _productRepository;
        protected readonly IUnitOfWork _unitOfWork;
        public DeleteProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id, cancellationToken);
                if (product is null)
                    throw new NotFoundException("Record not found");
                _productRepository.Delete(product);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new DeleteProductResponse()
                {
                    Message = "Product has been deleted"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException( ex.Message);
            }
        }
    }
}
