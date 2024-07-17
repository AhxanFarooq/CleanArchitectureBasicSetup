using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.AddProductCommand
{
    public class AddProductMapper:Profile
    {
        public AddProductMapper() {
            CreateMap<AddProductRequest, Product>();
        }
    }
}
