using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Library.Models
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public long ErrorCode { get; set; }
        public string ErrorMessenge { get; set; }
        public T Result { get; set; }
        public Response()
        {
            this.IsSuccess = true;
        }
    }
}
