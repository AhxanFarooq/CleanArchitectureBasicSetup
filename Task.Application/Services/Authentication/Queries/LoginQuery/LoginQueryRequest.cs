using ErrorOr;
using MediatR;

namespace Application.Services.Authentication.Queries.LoginQuery
{
    public record LoginQueryRequest:IRequest<ErrorOr<LoginQueryResponce>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
    }
}
