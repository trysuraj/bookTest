﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApplication.Core.Response
{
    public class GlobalRequestResponse<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<ErrorItem> Errors { get; set; }
        public T Data { get; set; }
        public GlobalRequestResponse()
        {
            Errors = new List<ErrorItem>();
        }
    }
    public class ErrorItem
    {
        public string Key { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}

