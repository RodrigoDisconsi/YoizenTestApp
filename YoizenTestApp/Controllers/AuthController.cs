using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using YoizenTestApp.Dto;
using YoizenTestApp.Models;
using YoizenTestApp.Repo;

namespace YoizenTestApp.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private IRepo<Client> _repositoryClient;
        private IConfiguration _configuration;
        public AuthController(IConfiguration configuration, IRepo<Client> repositoryClient)
        {
            _repositoryClient = repositoryClient;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserDto userBody)
        {
            var user = ((InMemClientRepo)_repositoryClient).ValidateUser(userBody.Email, userBody.Password);
            if(user == null)
            {
                return BadRequest("Verify your credentials.");
            }
            return Ok(CreateToken(user.Email, user.Role.ToString()));
        }

        private string CreateToken(string email, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
