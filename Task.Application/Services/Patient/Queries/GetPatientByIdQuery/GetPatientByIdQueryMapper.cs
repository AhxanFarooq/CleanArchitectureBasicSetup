

using AutoMapper;

namespace Application.Services.Patient.Query.GetPatientByIdQuery
{
    public class GetPatientByIdQueryMapper:Profile
    {
        public GetPatientByIdQueryMapper()
        {
            CreateMap<Domain.Entities.Patient, GetPatientByIdQueryResponce>();
        }
    }
}
