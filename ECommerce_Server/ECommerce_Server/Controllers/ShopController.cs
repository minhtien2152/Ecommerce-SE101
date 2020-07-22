using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Security.Claims;
using System.Text;
using Library.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using ServerFTM.BUS;
using API.Shared.APIResponse;

namespace ECommerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        [HttpGet("GetShop/Id={id}")]
        public async Task<IActionResult> getShop(string id)
        {
            List<Shop> result = BUS_Controls.Controls.getShop(id);

            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpPost("CreateShop")]
        public async Task<IActionResult> postCreateShop([FromBody] Shop value)
        {
            if (BUS_Controls.Controls.createShop(value))
            {
                return new JsonResult(new ApiResponse<object>("create shop ok"));
            }
            return new JsonResult(new ApiResponse<object>(200, "create shop failed"));
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> postCreateProduct([FromBody] ProductCreate value)
        {
            string result = BUS_Controls.Controls.createShopProduct(value); 
            if (result != "")
            {
                return new JsonResult(new ApiResponse<object>(result));
            }
            return new JsonResult(new ApiResponse<object>(200, "create shop failed"));
        }

        [HttpGet("GetShopProductId/Id={id}")]
        public async Task<IActionResult> getShopProductId(string id)
        {
            List<string> result = BUS_Controls.Controls.getAllShopProductId_Seller(id);

            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpPost("UpdateProductInfo")]
        public async Task<IActionResult> postUpdateProductInfo([FromBody] ProductUpdate value)
        {
            if (BUS_Controls.Controls.updateProductInfo(value))
            {
                return new JsonResult(new ApiResponse<object>("update product ok"));
            }
            return new JsonResult(new ApiResponse<object>(200, "update product failed"));
        }
    }
}
