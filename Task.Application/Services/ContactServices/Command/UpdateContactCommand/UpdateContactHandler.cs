using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.UpdateContactCommand;
using Application.Services.ContactServices.Command.UpdateContactCommand;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ContactServices.Command.UpdateContactCommand
{
    public class UpdateContactHandler : IRequestHandler<UpdateContactRequest, UpdateContactResponse>
    {
        protected readonly IContactRepository _contactRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public UpdateContactHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateContactResponse> Handle(UpdateContactRequest request, CancellationToken cancellationToken)
        {
            try
            {

                var contact = await _contactRepository.GetContactByIdWithDetail(request.Id, cancellationToken);
                if (contact is null)
                    throw new NotFoundException("Record not found");

                //Validate Contact already exist
                if (contact.CompanyTitle != request.CompanyTitle)
                {
                    var isAlreadyExist = await _contactRepository.VerifyAlreadyExist(request.CompanyTitle, cancellationToken);
                    if (isAlreadyExist)
                        throw new AlreadyExistException(" Contact is already exist.");
                }
                contact.CompanyTitle = request.CompanyTitle;
                contact.AreaId = request.AreaId;
                contact.IndustryId = request.IndustryId;
                contact.City = request.City;
                contact.Address = request.Address;
                contact.GoogleMapLink = request.GoogleMapLink;
                contact.Source = request.Source;

                // Update existing contact details
                foreach (var updatedDetailCommand in request.ContactDetailModels)
                {
                    var existingDetail = contact.ContactDetails.FirstOrDefault(d => d.Id == updatedDetailCommand.Id);
                    if (existingDetail != null)
                    {
                        existingDetail.Name = updatedDetailCommand.Name;
                        existingDetail.Email = updatedDetailCommand.Email;
                        existingDetail.Secondary_Email = updatedDetailCommand.Secondary_Email;
                        existingDetail.Phone = updatedDetailCommand.Phone;
                        existingDetail.Secondary_Phone = updatedDetailCommand.Secondary_Phone;
                        existingDetail.Designation = updatedDetailCommand.Designation;
                    }
                }

                // Add new contact details
                var existingDetailIds = contact.ContactDetails.Select(d => d.Id).ToList();
                foreach (var updatedDetailCommand in request.ContactDetailModels.Where(d => d.Id == Guid.Empty))
                {
                    contact.ContactDetails.Add(new ContactDetail {
                        Name = updatedDetailCommand.Name,
                        Email = updatedDetailCommand.Email,
                        Secondary_Email = updatedDetailCommand.Secondary_Email,
                        Phone = updatedDetailCommand.Phone,
                        Secondary_Phone = updatedDetailCommand.Secondary_Phone,
                        Designation = updatedDetailCommand.Designation,
                        ContactId = contact.Id
                    });
                }

                // Optionally, remove contact details that are missing from the updated details
                var removedDetails = contact.ContactDetails.Where(d => !request.ContactDetailModels.Any(ud => ud.Id == d.Id)).ToList();
                foreach (var detail in removedDetails)
                {
                    contact.ContactDetails.Remove(detail);
                }

                // Update existing contact Conversation
                foreach (var updatedConversationCommand in request.ContactCoversationModels)
                {
                    var existingConversation = contact.ContactCoversations.FirstOrDefault(d => d.Id == updatedConversationCommand.Id);
                    if (existingConversation != null)
                    {
                        existingConversation.Note = updatedConversationCommand.Note;
                    }
                }

                // Add new contact existing Conversation
                var existingConversationIds = contact.ContactCoversations.Select(d => d.Id).ToList();
                foreach (var updatedDetailCommand in request.ContactCoversationModels.Where(d => d.Id == Guid.Empty))
                {
                    contact.ContactCoversations.Add(new ContactCoversation
                    {
                        Note = updatedDetailCommand.Note,
                        ContactId = contact.Id
                    });
                }

                // Optionally, remove contact existing Conversation that are missing from the updated existing Conversation
                var removedConversations = contact.ContactCoversations.Where(d => !request.ContactCoversationModels.Any(ud => ud.Id == d.Id)).ToList();
                foreach (var detail in removedConversations)
                {
                    contact.ContactCoversations.Remove(detail);
                }

                _contactRepository.Update(contact);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new UpdateContactResponse()
                {
                    Message = "Contact has been update"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
