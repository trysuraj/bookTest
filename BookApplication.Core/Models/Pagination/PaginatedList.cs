﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Core.Models.Pagination
{
    public class PaginatedList<T>
    {
        public PageData MetaData { get; set; }
        public IEnumerable<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }

        public PaginatedList()
        {
            Data = new List<T>();
        }
    }
}
