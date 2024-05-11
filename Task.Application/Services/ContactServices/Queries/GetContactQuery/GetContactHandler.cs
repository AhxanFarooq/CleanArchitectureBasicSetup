using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.GetContactQuery;
using Application.Services.ContactServices.Command.GetContactQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices.Command.GetContactQuery
{
    public class GetContactHandler : IRequestHandler<GetContactRequest, GetContactResponse>
    {
        protected readonly IContactRepository _contactRepository;
        protected readonly IMapper _mapper;
        public GetContactHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        public async Task<GetContactResponse> Handle(GetContactRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _contactRepository.GetContactByIdWithDetail(request.Id, cancellationToken);
                return _mapper.Map<GetContactResponse>(record);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
