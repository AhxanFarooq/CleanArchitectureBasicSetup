

using Domain.Common;

namespace Domain.Entities
{
    public class Recommendation:BaseEntity
    {
        public string Type { get; set; } 
        public DateTime DueDate { get; set; } 
        public string Status { get; set; } 
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
