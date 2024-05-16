using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices.Command.AddContactCommand
{
    public record ContactCoversationModel
    {
        public Guid Id { get; set; }
        public string Note { get; set; }
        public Guid ContactId { get; set; }
    }
}
