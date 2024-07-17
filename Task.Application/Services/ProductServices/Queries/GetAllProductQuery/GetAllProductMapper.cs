using Application.Services.AreaServices.Command.GetAllAreaQuery;
using Application.Services.ProductServices.Command.GetAllProductQuery;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Queries.GetAllProductQuery
{
    public class GetAllProductMapper:Profile
    {
        public GetAllProductMapper() {
            CreateMap<Product, GetAllProductResponse>();
        }
    }
}
