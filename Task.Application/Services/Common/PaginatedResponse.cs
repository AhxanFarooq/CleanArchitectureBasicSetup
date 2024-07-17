using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Common
{
    public class PaginatedResponse<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecord { get; set; }
        public bool HasPrevPage
        {
            get
            {
                return PageIndex > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return PageIndex * TotalPages < TotalRecord;
            }
        }

        public PaginatedResponse(List<T> items, int pageIndex, int totalPages, int totalRecord)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
            TotalRecord = totalRecord;
        }
    }
}
