using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.GetAllContactQuery;
using Application.Services.ContactServices.Command.GetAllContactQuery;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices.Command.GetAllContactQuery
{
    public class GetAllContactHandler : IRequestHandler<GetAllContactRequest, List<GetAllContactResponse>>
    {
        protected readonly IContactRepository _contactRepository;
        protected readonly IMapper _mapper;
        public GetAllContactHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllContactResponse>> Handle(GetAllContactRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Contact> list;
                if (string.IsNullOrEmpty(request.Search))
                {
                    list = await _contactRepository.GetAllContactWithDetail(cancellationToken);
                }
                else
                {
                    list = await _contactRepository.Search(request.Search, cancellationToken);
                }
                return list.Select(x=>new GetAllContactResponse()
                {
                    Id = x.Id,
                    CompanyTitle = x.CompanyTitle,
                    AreaName = x.Area?.Name,
                    IndustryName = x.Industry?.Name,
                    City = x.City,
                    Address = x.Address,
                    GoogleMapLink = x.GoogleMapLink,
                    Source = x.Source,
                    AreaId = x.AreaId,
                    IndustryId = x.IndustryId,

                }).ToList();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
