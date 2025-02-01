using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Recommendation.Query.GetRecommendationListQuery
{
    public record GetRecommendationListQueryResponce
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public Guid PatientId { get; set; }
    }
}
