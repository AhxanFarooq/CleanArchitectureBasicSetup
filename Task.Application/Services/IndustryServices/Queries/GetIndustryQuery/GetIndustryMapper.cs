using Application.Services.AreaServices.Command.GetAreaQuery;
using Application.Services.IndustryServices.Command.GetIndustryQuery;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Queries.GetIndustryQuery
{
    public class GetIndustryMapper : Profile
    {
        public GetIndustryMapper()
        {
            CreateMap<Industry, GetIndustryResponse>();
        }
    }
}
