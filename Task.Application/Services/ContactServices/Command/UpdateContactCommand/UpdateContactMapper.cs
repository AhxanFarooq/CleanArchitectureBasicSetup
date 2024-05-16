using Application.Services.AreaServices.Command.AddContactCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateContactCommand
{
    public class UpdateContactMapper : Profile
    {
        public UpdateContactMapper()
        {
            CreateMap<UpdateContactRequest, Contact>();
        }
    }
}
