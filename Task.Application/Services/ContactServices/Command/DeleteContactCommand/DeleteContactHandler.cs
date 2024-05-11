using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.DeleteContactCommand;
using MediatR;

namespace Application.Services.ContactServices.Command.DeleteContactCommand
{
    public class DeleteContactHandler : IRequestHandler<DeleteContactRequest, DeleteContactResponse>
    {
        protected readonly IContactRepository _contactRepository;
        protected readonly IUnitOfWork _unitOfWork;
        public DeleteContactHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteContactResponse> Handle(DeleteContactRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var contact = await _contactRepository.GetContactByIdWithDetail(request.Id, cancellationToken);
                if (contact is null)
                    throw new NotFoundException("Record not found");
                foreach (var detail in contact.ContactDetails)
                {
                    contact.ContactDetails.Remove(detail);
                }
                foreach (var detail in contact.ContactCoversations)
                {
                    contact.ContactCoversations.Remove(detail);
                }
                _contactRepository.Delete(contact);
                await _unitOfWork.SaveChanges(cancellationToken);
                return new DeleteContactResponse()
                {
                    Message = "Contact has been deleted"
                };

            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
