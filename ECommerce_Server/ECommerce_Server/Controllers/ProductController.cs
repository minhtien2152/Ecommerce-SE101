using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Shared.APIResponse;
using ECommerce_Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFTM.BUS;

namespace ECommerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductInfo productInfo)
        {
            if (BUS_Controls.Controls.AddProduct(productInfo))
            {
                return new JsonResult(new ApiResponse<bool>(true));
            }
            else
            {
                return new JsonResult(new ApiResponse<bool>(true));
            }
        }
    }
}
