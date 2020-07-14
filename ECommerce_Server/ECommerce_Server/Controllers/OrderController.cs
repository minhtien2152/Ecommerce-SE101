using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using API.Shared.APIResponse;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerFTM.BUS;

namespace ECommerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> PostCreateOrder([FromBody] Order value)
        {
            string result = BUS_Controls.Controls.createOrder(value); 
            if (result != "")
            {
                return new JsonResult(new ApiResponse<object>(result));
            }
            return new JsonResult(new ApiResponse<object>(200, "create order failed")); 
        }

        [HttpPost("CreateOrderDetail")]
        public async Task<IActionResult> PostCreateOrderDetail([FromBody] OrderDetail value)
        {
            if (BUS_Controls.Controls.createOrderDetail(value))
            {
                return new JsonResult(new ApiResponse<object>("create order detail ok")); 
            }
            return new JsonResult(new ApiResponse<object>(200, "create order detail failed")); 
        }

        [HttpGet("GetOrder/UserId={id}")]
        public async Task<IActionResult> GetOrder(string id)
        {
            List<Order> result = BUS_Controls.Controls.getOrder(id);
            return new JsonResult(new ApiResponse<object>(result));
        }

        [HttpGet("GetOrderDetail/OrderId={id}")]
        public async Task<IActionResult> GetOrderDetail(string id)
        {
            List<OrderDetail> result = BUS_Controls.Controls.getOrderDetail(id);
            return new JsonResult(new ApiResponse<object>(result)); 
        }
    }
}
