using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Server.Models
{
    public class ProductInfo
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Inventorynumber")]
        public int Inventorynumber { get; set; }

        [JsonProperty("Price")]
        public int Price { get; set; }

        [JsonProperty("IDCategory")]
        public string IDCategory { get; set; }

        [JsonProperty("ImageList")]
        public List<IFormFile> ImageList { get; set; }

        [JsonProperty("IDShop")]
        public string IDShop { get; set; }
    }
}
