using AutoMapper;
using Domain.Entities;

namespace Application.Services.IndustryServices.Command.UpdateIndustryCommand
{
    public class UpdateIndustryMapper : Profile
    {
        public UpdateIndustryMapper()
        {
            CreateMap<UpdateIndustryRequest, Industry>();
        }
    }
}
