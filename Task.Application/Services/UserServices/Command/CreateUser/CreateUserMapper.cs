using AutoMapper;
using Domain.Entities;

namespace Application.Services.UserServices.Command.CreateUser
{
    public class CreateUserMapper:Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequest, User>().ReverseMap();
        }
    }
}
