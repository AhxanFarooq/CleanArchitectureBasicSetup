using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.AreaServices.Command.GetQuotationQuery;
using Application.Services.QuotationServices.Command.GetQuotationQuery;
using Application.Services.QuotationServices.Queries.GetQuotationReportQuery;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.QuotationServices.Command.GetQuotationReportQuery
{
    public class GetQuotationReportHandler : IRequestHandler<GetQuotationReportRequest, GetQuotationReportResponse>
    {
        protected readonly IQuotationRepository _quotationRepository;
        protected readonly IMapper _mapper;
        public GetQuotationReportHandler(IQuotationRepository quotationRepository, IMapper mapper)
        {
            _quotationRepository = quotationRepository;
            _mapper = mapper;
        }
        public async Task<GetQuotationReportResponse> Handle(GetQuotationReportRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var record = await _quotationRepository.GetQuotationByIdWithDetails(request.Id, cancellationToken);
                var data = new GetQuotationReportResponse();
                string attention = string.Empty;

                if(record.Contact.ContactDetails.Count > 0)
                {
                    var contact = record.Contact.ContactDetails.FirstOrDefault();
                    if(contact != null)
                    {
                        attention = contact.Name + "(" + contact.Designation + ")";
                    }
                }
                data.TodayDate = DateTime.Now.ToString("d");
                data.CompanyTitle = record.Contact.CompanyTitle;
                data.Address = string.IsNullOrEmpty(record.Contact.Address)?string.Empty: record.Contact.Address;
                data.City = record.Contact.City;
                data.Attention = attention;
                data.Subject = record.Subject;
                data.Greeting = string.IsNullOrEmpty(record.Greeting)?"Dear Sir/Madam":record.Greeting;
                data.Addressing = record.Addressing;
                data.Price = record.TotalAmount.ToString();
                
                data.TermAndCondition = record.TermAndCondition;
                if (record.QuotationItems.Count == 1)
                {
                    var item = record.QuotationItems.FirstOrDefault();
                    if(item != null)
                    {
                        data.ProductName = item.Product.Name;
                        data.ProductDescription = item.Product.Description;
                        data.ProductImage = string.IsNullOrEmpty(item.Product.ImagePath) ?"":GetBase64ImagePath(request.ParentPath,item.Product.ImagePath);
                    }
                }
                else
                {
                    data.QuotationReportItemModels = new List<QuotationReportItemModel>();
                    data.IsMultipleItem = true;
                    foreach (var item in record.QuotationItems)
                    {
                        data.QuotationReportItemModels.Add(new QuotationReportItemModel()
                        {
                            Name = item.Product.Name,
                            LineTotal = item.LineTotal.ToString(),
                            ImagePath = string.IsNullOrEmpty(item.Product.ImagePath) ? "" : GetBase64ImagePath(request.ParentPath, item.Product.ImagePath),
                        });
                    }
                }
                
                return data;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        private string GetBase64ImagePath(string parentPath, string path)
        {
            var logoBase64 = "";
            var imagePath = Path.Combine(parentPath, path.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            if (System.IO.File.Exists(imagePath))
            {
                var bytes = System.IO.File.ReadAllBytesAsync(imagePath);
                logoBase64 = Convert.ToBase64String(bytes.Result);
            }
            return logoBase64;
        }
    }
}
