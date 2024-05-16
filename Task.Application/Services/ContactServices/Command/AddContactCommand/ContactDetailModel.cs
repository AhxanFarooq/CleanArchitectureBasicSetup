using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices.Command.AddContactCommand
{
    public record ContactDetailModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Secondary_Email { get; set; }
        public string Phone { get; set; }
        public string? Secondary_Phone { get; set; }
        public string? Designation { get; set; }
        public Guid ContactId { get; set; }
    }
}
