using Application.Services.AreaServices.Command.AddQuotationCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateQuotationCommand
{
    public class UpdateQuotationMapper : Profile
    {
        public UpdateQuotationMapper()
        {
            CreateMap<UpdateQuotationRequest, Quotation>();
        }
    }
}
