using Application.Services.AreaServices.Command.GetQuotationQuery;
using Application.Services.AreaServices.Command.UpdateQuotationCommand;
using Application.Services.QuotationServices.Command.AddQuotationCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Queries.GetQuotationQuery
{
    public class GetQuotationMapper : Profile
    {
        public GetQuotationMapper()
        {
            CreateMap<Quotation, GetQuotationResponse>()
            .ForMember(dest => dest.QuotationItemModels, opt => opt.MapFrom(src => src.QuotationItems));

            CreateMap<QuotationItem, QuotationItemModel>();
        }
    }
}
