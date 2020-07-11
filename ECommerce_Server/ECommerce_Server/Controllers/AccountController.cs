using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

    public class AccountController : ControllerBase
    {
        private IConfiguration _config;

        public AccountController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> PostSignUp([FromBody] Account profile)
        {
            if (BUS_Controls.Controls.signup(profile))
            {
                return new JsonResult(new ApiResponse<object>("signup ok"));
            }
            return new JsonResult(new ApiResponse<object>(200, "signup failed"));
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> PostSignIn([FromBody] Account profile)
        {
            Account result = BUS_Controls.Controls.signin(profile);
            if (result != null)
            {
                result.token = GenerateJSONWebToken(result);
                return new JsonResult(new ApiResponse<object>(result));
            }
            return new JsonResult(new ApiResponse<object>(200, "signin failed"));
        }

        private string GenerateJSONWebToken(Account profile)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, profile.userName),
                new Claim(JwtRegisteredClaimNames.Jti, profile.UserId)
            };

            var token = new JwtSecurityToken(null, null, claims,
                                expires: DateTime.Now.AddMinutes(10080),
                                signingCredentials: credentials);
            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
    }
}
