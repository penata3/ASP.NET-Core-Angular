using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
namespace MyApplication.Server.Features.Identity
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class IdentityService : IIdentityService
    {
        private readonly IOptions<ApplicationSettings> appSettings;

        public IdentityService(IOptions<ApplicationSettings> appSettings)
        {
            this.appSettings = appSettings;
        }

        public string GenerateJwtToken(string userId, string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Value.Secret);


            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, userId)
            }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
