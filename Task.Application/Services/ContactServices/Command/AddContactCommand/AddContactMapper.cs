﻿using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddContactCommand
{
    public class AddContactMapper : Profile
    {
        public AddContactMapper()
        {
            CreateMap<AddContactRequest, Contact>();
        }
    }
}
