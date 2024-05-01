using FluentValidation;

namespace Application.Services.UserServices.Command.CreateUser
{
    public class CreateUserValidator:AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator() { 
            RuleFor(x=>x.UserName).NotEmpty().MinimumLength(5).MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).MaximumLength(16);
            RuleFor(x => x.FirstName).NotEmpty().NotNull();
            RuleFor(x => x.LastName).NotEmpty().NotNull();
        }
    }
}
