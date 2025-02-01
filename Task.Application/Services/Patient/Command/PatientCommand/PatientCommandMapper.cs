
using Application.Services.Authentication.Command.PatientCommand;
using AutoMapper;

namespace Application.Services.Patient.Command.PatientCommand
{
    public class PatientCommandMapper:Profile
    {
        public PatientCommandMapper()
        {
            CreateMap<PatientCommandRequest, Domain.Entities.Patient>();
        }
    }
}
