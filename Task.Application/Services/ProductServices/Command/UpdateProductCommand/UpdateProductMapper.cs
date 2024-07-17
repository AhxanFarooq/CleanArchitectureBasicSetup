
using Application.ProductServices.ProductServices.UpdateProductCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ProductServices.Command.UpdateProductCommand
{
    public class UpdateProductMapper:Profile
    {
        public UpdateProductMapper() {
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
