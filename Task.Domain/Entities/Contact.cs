using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contact:BaseEntity
    {
        public string CompanyTitle { get; set; }
        public string City { get; set; }
        public Guid AreaId { get; set; }
        public virtual Area? Area { get; set; }
        public Guid IndustryId { get; set; }
        public virtual Industry? Industry { get; set; }
        public string? Address { get; set; }
        public string? GoogleMapLink { get; set; }
        public string? Source { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }
        public virtual ICollection<ContactCoversation> ContactCoversations { get; set; }
    }
}
