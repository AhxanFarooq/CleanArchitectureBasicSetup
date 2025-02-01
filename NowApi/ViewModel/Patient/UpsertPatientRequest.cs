using NowApi.ViewModel.Common;

namespace NowApi.ViewModel.Patient
{
    public class UpsertPatientRequest:BaseRequest
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactInfo { get; set; }
        public string Status { get; set; }
    }
}
