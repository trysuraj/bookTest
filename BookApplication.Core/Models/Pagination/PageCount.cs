using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Core.Models.Pagination
{
    public class PageCount
    {
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 1;
    }
}
