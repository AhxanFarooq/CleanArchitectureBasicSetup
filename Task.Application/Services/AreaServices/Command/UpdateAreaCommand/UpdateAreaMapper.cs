using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateAreaCommand
{
    public class UpdateAreaMapper:Profile
    {
        public UpdateAreaMapper() {
            CreateMap<UpdateAreaRequest, Area>();
        }
    }
}
