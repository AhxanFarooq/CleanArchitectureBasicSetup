﻿using Application.Services.ContactServices.Command.AddContactCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.GetContactQuery
{
    public record GetContactResponse
    {
        public Guid Id { get; set; }
        public string CompanyTitle { get; set; }
        public string City { get; set; }
        public Guid AreaId { get; set; }
        public Guid IndustryId { get; set; }
        public string? Address { get; set; }
        public string? GoogleMapLink { get; set; }
        public string? Source { get; set; }
        public virtual ICollection<ContactDetailModel> ContactDetailModels { get; set; }
        public virtual ICollection<ContactCoversationModel> ContactCoversationModels { get; set; }
    }
}
