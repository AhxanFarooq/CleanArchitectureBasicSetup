namespace NowApi.ViewModel.Patient
{
    public class GetAllPatient
    {
        public string? Search { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
