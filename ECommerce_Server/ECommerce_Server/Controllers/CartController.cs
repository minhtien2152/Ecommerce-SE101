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
    public class CartController : ControllerBase
    {
        [HttpGet("CheckCartQuantity/UserId={userId}/ProductId={productId}/Quantity={quantity}")]
        public async Task<IActionResult> GetCheckCartResult(string userId, string productId, int quantity)
        {
            int result = BUS_Controls.Controls.checkCart(new Cart()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = quantity
            });
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetCart/UserId={userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            List<Cart> result = BUS_Controls.Controls.getCart(userId);
            return new JsonResult(new ApiResponse<object>(result)); 
        }

        [HttpPost("InsertCart")]
        public async Task<IActionResult> PostInsertCart([FromBody] Cart value)
        {
            if (BUS_Controls.Controls.insertCart(value))
            {
                return new JsonResult(new ApiResponse<object>("insert cart ok")); 
            }
            return new JsonResult(new ApiResponse<object>(200, "insert cart failed")); 
        }

        [HttpPost("DeleteCart")]
        public async Task<IActionResult> PostDeleteCart([FromBody] Cart value)
        {
            if (BUS_Controls.Controls.deleteCart(value))
            {
                return new JsonResult(new ApiResponse<object>("delete cart ok"));
            }
            return new JsonResult(new ApiResponse<object>(200, "delete cart failed"));
        }

        [HttpPost("ClearCart")]
        public async Task<IActionResult> PostClearCart([FromBody] Cart value)
        {
            if (BUS_Controls.Controls.clearCart(value))
            {
                return new JsonResult(new ApiResponse<object>("clear cart ok"));
            }
            return new JsonResult(new ApiResponse<object>(200, "clear cart failed"));
        }
    }
}
