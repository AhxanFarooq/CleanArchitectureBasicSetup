using MediatR;

namespace Application.Services.UserServices.Command.CreateUser
{
    public sealed record CreateUserRequest(string Email, string UserName, string Password,
        string FirstName, string LastName, string Device, string IpAddress):IRequest<CreateUserResponse>;
}
