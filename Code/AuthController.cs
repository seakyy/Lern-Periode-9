using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAPI_295.Models;

namespace WebAPI_295.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly WarehouseContext _context;
        private readonly IConfiguration _config;

        public AuthController(WarehouseContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        
        /// <summary>
        /// Benutzer-Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            if (dbUser == null) return Unauthorized("Ungültige Anmeldedaten.");

            var accessToken = GenerateAccessToken(dbUser);
            var refreshToken = GenerateRefreshToken();

            dbUser.RefreshToken = refreshToken;
            dbUser.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Refresh Token ist 7 Tage gültig
            _context.SaveChanges();

            return Ok(new { accessToken, refreshToken });
        }

       
        /// <summary>
        /// Refresh Token Endpunkt
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] string refreshToken)
        {
            var user = _context.Users.FirstOrDefault(u => u.RefreshToken == refreshToken);

            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
                return Unauthorized("Ungültiger oder abgelaufener Refresh Token.");

            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            _context.SaveChanges();

            return Ok(new { accessToken = newAccessToken, refreshToken = newRefreshToken });
        }

        
        /// <summary>
        /// Generiert ein JWT Access Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),  //Access Token läuft nach 1 Stunde ab
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        
        /// <summary>
        /// Generiert ein zufälliges Refresh Token
        /// </summary>
        /// <returns></returns>
        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
