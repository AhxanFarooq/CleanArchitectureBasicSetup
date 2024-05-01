using System;
using System.Collections.Generic;
using System.Linq;

using Domain.Common;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Device { get; set; }
        public string? IpAddress { get; set; }
        public string? Browser { get; set; }
        public decimal? Balance { get; set; }
        public bool IsOldUser { get; set; }
    }
}
