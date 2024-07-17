using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.AreaServices.Command.GetAreaQuery;
using Application.Services.ProductServices.Command.GetProductQuery;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Queries.GetProductQuery
{
    public class GetProductMapper : Profile
    {
        public GetProductMapper()
        {
            CreateMap<Product, GetProductResponse>();
        }
    }
}
