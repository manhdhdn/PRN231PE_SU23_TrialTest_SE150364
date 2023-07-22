using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetStore2023API.Utils
{
    public class AccountRepo : IAccountRepo
    {
        public string? GenerateJwtToken(string email, string roleName)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, roleName)
            };

            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes("PetSecretKey"));

            var token = new JwtSecurityToken(
                issuer: "PetIssuer",
                audience: "PetAudience",
                expires: DateTime.Now.AddDays(7),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
