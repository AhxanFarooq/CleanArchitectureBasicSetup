using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Command.UpdateUser
{
    public class UpdateUserMapper:Profile
    {
        public UpdateUserMapper() { 
            CreateMap<UpdateUserRequest,User>().ReverseMap();
        }
    }
}
