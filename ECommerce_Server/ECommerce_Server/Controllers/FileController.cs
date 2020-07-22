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
using System.Net.Http;
using Microsoft.Extensions.Hosting.Internal;
using ServerFTM;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace ECommerce_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("UploadClientImage")]
        public async Task<IActionResult> PostUploadImage([FromForm] ImageModel image) {
            if (image.data.Length > 0) {
                var filePath = Startup.ContentRootPath + $"\\Images\\{image.name}.jpg";

                using (var stream = System.IO.File.Create(filePath)) {
                    await image.data.CopyToAsync(stream);
                }
            }
            return new JsonResult(new ApiResponse<object>("files uploaded"));
        }

        [HttpGet("ClientImage/Name={name}")]
        public IActionResult GetImage(string name) {
            Byte[] dataByte = null;
            try {
                dataByte = System.IO.File.ReadAllBytes(Startup.ContentRootPath + $"\\Images\\{name}.jpg");
            }
            catch (Exception e) {
                return new JsonResult(new ApiResponse<object>("no file found!"));
            }
            return File(dataByte, "image/jpg");
        }
    }
}
