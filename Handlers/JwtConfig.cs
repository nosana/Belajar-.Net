using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Handlers
{
    public class JwtConfig
    {
        public IConfiguration congiguration;

        public JwtConfig(IConfiguration configuration)
        {
            this.congiguration = configuration;    
        }

        public string Token(string Email, string Role)
        {


            List<Claim> claims = new List<Claim>()
           {
               new Claim(ClaimTypes.Email, Email),
               new Claim(ClaimTypes.Role, Role)
           };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(congiguration["Jwt:key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               congiguration["Jwt:Issuer"],
               congiguration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return (new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
