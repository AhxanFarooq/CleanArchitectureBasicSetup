using Application.Services.Authentication.Command.RegisterCommand;
using Application.Services.Authentication.Queries.LoginQuery;
using AutoMapper;
using NowApi.ViewModel.Authentication;

namespace NowApi.MapperService
{
    public class AutheticationMapper:Profile
    {
        public AutheticationMapper() {
            CreateMap<LoginVm, LoginQueryRequest>();
            CreateMap<RegistrationVm, RegisterCommandRequest>();
        }
    }
}
