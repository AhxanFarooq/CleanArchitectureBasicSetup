using Domain.Common;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactCoversation:BaseEntity
    {
        public string Note { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}
