using System;
using System.Collections.Generic;
using System.Linq;
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
    public class TransportController : ControllerBase
    {
        [HttpGet("GetShippingLog/OrderId={id}")]
        public async Task<IActionResult> GetShippingLog(string id)
        {
            List<ShippingLog> result = BUS_Controls.Controls.GetShippingLogs(id);
            return new JsonResult(new ApiResponse<object>(result)); 
        }
    }
}
