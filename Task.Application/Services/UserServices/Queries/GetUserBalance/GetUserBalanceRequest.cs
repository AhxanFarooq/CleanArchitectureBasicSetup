using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Queries.GetUserBalance
{
    public record GetUserBalanceRequest(string token):IRequest<GetUserBalanceResponse>;
}
