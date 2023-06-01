using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RJ_NOC_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public IActionResult UserLogin(int uid, string uname)
        {
            try
            {
                if (uid != 1 || uname != "admin")
                {
                    return NotFound(new
                    {
                        StatusCode = 401,
                        Message = "Invalid uaer is and password"
                    });
                }
                return Ok(GenrateJwtToken(uid, uname));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something wen wrong inside UserLogin action: {ex.GetBaseException().Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        private string GenrateJwtToken(int uid, string uname)
        {
            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,uid.ToString()),
                new Claim(ClaimTypes.Sid,uname),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS-IS-MY-RJNOC-WEB-API-DEVITPL"));

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5118",
                audience: "http://localhost:5118",
                expires: DateTime.Now.AddMinutes(10),
                claims: authClaim,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}