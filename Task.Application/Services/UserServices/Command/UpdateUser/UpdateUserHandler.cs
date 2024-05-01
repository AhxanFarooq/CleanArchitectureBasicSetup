using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.UserServices.Command.CreateUser;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Command.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Device = request.Device;
            user.Browser = request.browser;
            user.IpAddress = request.IpAddress;
            user.Balance = request.balance;
            user.IsOldUser = true;
            _userRepository.Update(user);
            await _unitOfWork.SaveChanges(cancellationToken);

            return new UpdateUserResponse()
            {
                IsUpdate = true,
                Message = "Data has been update",

            };
        }
    }
}
