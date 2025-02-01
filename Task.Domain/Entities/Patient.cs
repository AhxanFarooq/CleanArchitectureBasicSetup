

using Domain.Common;

namespace Domain.Entities
{
    public class Patient:BaseEntity
    {
        public string Code { get; set; } 
        public string Name { get; set; } 
        public DateTime DateOfBirth { get; set; }
        public string ContactInfo { get; set; } 
        public string Status { get; set; } 
        public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();
    }
}
