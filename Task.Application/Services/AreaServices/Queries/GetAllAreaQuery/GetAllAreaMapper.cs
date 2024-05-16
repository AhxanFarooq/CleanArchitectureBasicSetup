using Application.Services.AreaServices.Command.GetAllAreaQuery;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Queries.GetAllAreaQuery
{
    public class GetAllAreaMapper:Profile
    {
        public GetAllAreaMapper() {
            CreateMap<Area, GetAllAreaResponse>();
        }
    }
}
