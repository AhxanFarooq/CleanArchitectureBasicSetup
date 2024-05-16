using Application.Services.AreaServices.Command.GetContactQuery;
using Application.Services.AreaServices.Command.UpdateContactCommand;
using Application.Services.ContactServices.Command.AddContactCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices.Queries.GetContactQuery
{
    public class GetContactMapper : Profile
    {
        public GetContactMapper()
        {
            CreateMap<Contact, GetContactResponse>()
            .ForMember(dest => dest.ContactDetailModels, opt => opt.MapFrom(src => src.ContactDetails))
            .ForMember(dest => dest.ContactCoversationModels, opt => opt.MapFrom(src => src.ContactCoversations));

            CreateMap<ContactDetail, ContactDetailModel>();
            CreateMap<ContactCoversation, ContactCoversationModel>();
        }
    }
}
