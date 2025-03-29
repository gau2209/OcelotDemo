using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly ILogger<AuthenController> _logger;

        public AuthenController(ILogger<AuthenController> logger)
        {
            _logger = logger;
        }

        // GET: api/<AuthenController>
        [HttpGet]
        public IActionResult Get(string name,string pwd)
        {
            if (name != "anhtuan" && pwd != "2209")
            {
                return BadRequest("");//Json("");
            }
            DateTime now = DateTime.Now;
            var claim = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,name),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,now.ToUniversalTime().ToString(),ClaimValueTypes.Integer64)
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("This is my test for private key for authentication"));
            var tokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = key,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
            };
            var jwt = new JwtSecurityToken(
                claims: claim,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt= new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new { 
            acces_token = encodedJwt,
                expires_in=(int)TimeSpan.FromMinutes(2).TotalSeconds
            };

            return Ok(response);

        }

      
    }
}
