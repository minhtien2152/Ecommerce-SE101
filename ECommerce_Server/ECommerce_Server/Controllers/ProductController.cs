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
    
    public class ProductController : ControllerBase
    {
        [HttpGet("GetTopSellingProductId")]
        public async Task<IActionResult> GetTopSellingProduct()
        {
            List<string> result = BUS_Controls.Controls.getTopSellingProductId();
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetAllProductId")]
        public async Task<IActionResult> GetAllProductId()
        {
            List<string> result = BUS_Controls.Controls.getAllProductId();
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetProductDisplay/ID={id}")]
        public async Task<IActionResult> GetProductDisplay(string id)
        {
            ProductDisplay result = BUS_Controls.Controls.getProductDisplay(id);
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetProductDetail/ID={id}")]
        public async Task<IActionResult> GetProductDetail(string id)
        {
            ProductDetail result = BUS_Controls.Controls.getProductDetail(id);
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetProductImg/ID={id}")]
        public async Task<IActionResult> GetProductImg(string id)
        {
            List<string> result = BUS_Controls.Controls.getProductImg(id);
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetProductReview/ID={id}")]
        public async Task<IActionResult> GetProductReview(string id)
        {
            List<ProductReview> result = BUS_Controls.Controls.getProductReview(id);
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetProductSearchList/Search={search}")]
        public async Task<IActionResult> GetProductSearchList(string search)
        {
            List<ProductSearch> result = BUS_Controls.Controls.getProductSearchList(search);
            return new JsonResult(new ApiResponse<object>(result));
        }
    }
}
