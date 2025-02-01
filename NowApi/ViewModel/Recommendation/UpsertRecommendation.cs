using NowApi.ViewModel.Common;

namespace NowApi.ViewModel.Recommendation
{
    public class UpsertRecommendation:BaseRequest
    {
        public string Type { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public Guid PatientId { get; set; }
    }
}
