

using AutoMapper;

namespace Application.Services.Patient.Query.GetPatientListQuery
{
    public class GetPatientListQueryMapper:Profile
    {
        public GetPatientListQueryMapper()
        {
            CreateMap<Domain.Entities.Patient, GetPatientListQueryResponce>();
        }
    }
}
