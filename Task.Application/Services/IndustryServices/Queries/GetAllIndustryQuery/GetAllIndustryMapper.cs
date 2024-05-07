using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.IndustryServices.Command.GetAllIndustryQuery;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Queries.GetAllIndustryQuery
{
    public class GetAllIndustryMapper : Profile
    {
        public GetAllIndustryMapper()
        {
            CreateMap<Industry, GetAllIndustryResponse>();
        }
    }
}
