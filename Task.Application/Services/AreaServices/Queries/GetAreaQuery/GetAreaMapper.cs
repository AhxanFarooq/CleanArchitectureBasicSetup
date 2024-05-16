using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.AreaServices.Command.GetAreaQuery;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Queries.GetAreaQuery
{
    public class GetAreaMapper : Profile
    {
        public GetAreaMapper()
        {
            CreateMap<Area, GetAreaResponse>();
        }
    }
}
