using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models
{
    public class ImageModel
    {
        public string name { get; set; }
        public IFormFile data { get; set; }
    }
}
