using Application.Services.AreaServices.Command.AddAreaCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.AddIndustryCommand
{
    public class AddIndustryMapper : Profile
    {
        public AddIndustryMapper()
        {
            CreateMap<AddIndustryRequest, Industry>();
        }
    }
}
