using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using E_COMMERCE_MANAGEMENT.DTOs.User;
using E_COMMERCE_MANAGEMENT.Model;
using E_COMMERCE_MANAGEMENT.UnitOfWorkkk;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace E_COMMERCE_MANAGEMENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOWork _repo;
        private readonly IConfiguration _config;
        public AuthController(IUnitOWork unitOWork,IConfiguration configuration)
        {
            _repo= unitOWork;
            _config= configuration;
        }

        [HttpPost("Registration")]

        public async Task<IActionResult> Rigistration(RegistrationDTO dto)
        {
            var user = await _repo.user.GetByEmail(dto.Email);
            if (user != null)
            {
                return BadRequest("Email olredy Exist");
            }

            if (dto.Role != "Customer" && dto.Role != "Admin")
            {
                return BadRequest("The Role Mast Be Admin  Or Customer");
            }

            var use = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,

            };
            await _repo.user.Create(use);
            await _repo.SaveChangeAsync();
            return Ok();
        }


        [HttpPost("Login")]

        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _repo.user.GetByEmail(dto.Email);
            if (user.Email != dto.Email || user.Password!=dto.Password)
            {
                return BadRequest("Invalid  Email Or Password");
            }

            var token = GenerateToken(user);
            return Ok(new { token });
        }

        private  string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var crad=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var clain = new List<Claim> {
               new  Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Role,user.Role)


            };

            var token = new JwtSecurityToken
                (
                issuer: _config["jwt:issuer"],
                audience: _config["jwt:audience"],
                signingCredentials: crad,
                claims: clain,
                expires:DateTime.Now.AddHours(1)




                );
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }

    }
}
