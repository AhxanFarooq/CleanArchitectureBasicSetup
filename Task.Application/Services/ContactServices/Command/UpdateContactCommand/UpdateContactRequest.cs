using Application.Services.AreaServices.Command.AddContactCommand;
using Application.Services.ContactServices.Command.AddContactCommand;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.UpdateContactCommand
{
    public record UpdateContactRequest : IRequest<UpdateContactResponse>
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
