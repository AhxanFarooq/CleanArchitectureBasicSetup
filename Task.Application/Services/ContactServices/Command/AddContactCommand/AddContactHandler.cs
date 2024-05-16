using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.AddAreaCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AreaServices.Command.AddContactCommand
{
    public class AddContactHandler : IRequestHandler<AddContactRequest, AddContactResponse>
    {
        protected readonly IContactRepository _contactRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public AddContactHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddContactResponse> Handle(AddContactRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var contact = _mapper.Map<Contact>(request);

                Guid newId = Guid.NewGuid();
                //Validate Area already exist
                var isAlreadyExist = await _contactRepository.VerifyAlreadyExist(contact.CompanyTitle, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistException(" Company title is already exist.");
                contact.Id = newId;
                contact.ContactDetails = request.ContactDetailModels.Select(d => new ContactDetail
                {
                    Name = d.Name,
                    Email = d.Email,
                    Secondary_Email = d.Secondary_Email,
                    Phone = d.Phone,
                    Secondary_Phone = d.Secondary_Phone,
                    Designation = d.Designation,
                    ContactId = newId
                }).ToList();
                contact.ContactCoversations = request.ContactCoversationModels.Select(d => new ContactCoversation
                {
                    Note = d.Note,
                    ContactId = newId
                }).ToList();
                _contactRepository.Create(contact);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new AddContactResponse()
                {
                    Id = contact.Id,
                    Message = "Contact has been created"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
