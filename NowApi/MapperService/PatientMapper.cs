using Application.Services.Authentication.Command.PatientCommand;
using Application.Services.Patient.Query.GetPatientListQuery;
using AutoMapper;
using NowApi.ViewModel.Patient;

namespace NowApi.MapperService
{
    public class PatientMapper:Profile
    {
        public PatientMapper() {
            CreateMap<UpsertPatientRequest, PatientCommandRequest>();
        }
    }
}
