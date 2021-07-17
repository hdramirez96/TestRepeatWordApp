using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.API.Security;

namespace TestApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IOptions<JwtConfig> _jwtConfig;
        public SecurityController(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        [HttpPost("Access")]
        public ActionResult Access()
        {
            string tocken = GenerateToken();
            return Ok(tocken);
        }

        public string GenerateToken()
        {
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Value.SecretKey);
            var cred = new SymmetricSecurityKey(key);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(cred, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var CreatedTocken = tokenHandler.CreateToken(TokenDescriptor);

            return tokenHandler.WriteToken(CreatedTocken);
        }
    }
}
