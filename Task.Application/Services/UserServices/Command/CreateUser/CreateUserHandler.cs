using AutoMapper;
using MediatR;
using Application.Repositories;
using Domain.Entities;
using System.Text;

namespace Application.Services.UserServices.Command.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            //Convert Password to base 64 encoded
            // Convert the string to bytes
            byte[] stringBytes = Encoding.UTF8.GetBytes(user.Password);

            // Convert the bytes to a Base64 string
            user.Password = Convert.ToBase64String(stringBytes);
            _userRepository.Create(user);
            await _unitOfWork.SaveChanges(cancellationToken);

            return new CreateUserResponse()
            {
                Id = user.Id,
                Message = "Data has been created",

            };
        }
    }
}
