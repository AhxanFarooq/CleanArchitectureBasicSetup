using Application.Common.Exceptions;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Net;
using Domain.Common.Errors;

namespace Application.Services.Authentication.Command.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, ErrorOr<RegisterCommandResponce>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration) {
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<ErrorOr<RegisterCommandResponce>> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userExist = await _userManager.FindByEmailAsync(request.Email);
                if (userExist != null)
                    return Errors.Authentication.DuplicateEmail;

                //User creation process
                ApplicationUser user = new ApplicationUser()
                {
                    Name = request.Name,
                    UserName = request.Email,
                    Email = request.Email,
                    Address = request.Address,
                    PhoneNumber = request.Phone_Number,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var createUserResult = await _userManager.CreateAsync(user, request.Password);
                if (!createUserResult.Succeeded)
                {
                    return Errors.DbError.UserCreationFailed(createUserResult.Errors == null ? "" :  createUserResult.Errors.First().Description.ToString());
                }

                //Role manager of user

                if(!await _roleManager.RoleExistsAsync(request.User_Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(request.User_Role));
                }

                await _userManager.AddToRoleAsync(user, request.User_Role);


                return new RegisterCommandResponce()
                {
                    Message = "User created successfully."
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException("Something went wrong." + ex.Message);
            }
        }
    }
}
