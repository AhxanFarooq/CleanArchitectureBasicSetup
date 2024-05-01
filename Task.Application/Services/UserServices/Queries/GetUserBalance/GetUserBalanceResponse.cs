using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserServices.Queries.GetUserBalance
{
    public record GetUserBalanceResponse
    {
        public decimal? Balance { get; set; }
    }
}
