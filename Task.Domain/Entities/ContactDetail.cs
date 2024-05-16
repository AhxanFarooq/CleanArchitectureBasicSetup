using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactDetail:BaseEntity
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Secondary_Email { get; set; }
        public string Phone { get; set; }
        public string? Secondary_Phone { get; set; }
        public string? Designation { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}
