using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStore.App.Modules.Auth;
using BookStore.Security;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.Services
{
 public class TokenService
 {
  public string GenerateJwtToken(AuthEntity authEntity)
  {

   byte[] key = Encoding.ASCII.GetBytes(Key.SecretKey);
   var tokenConfig = new SecurityTokenDescriptor
   {
    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
     new Claim("userId", authEntity.UserId),
    }),
    Expires = DateTime.UtcNow.AddHours(1),
    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
   };

   var tokenHanlder = new JwtSecurityTokenHandler();
   var token = tokenHanlder.CreateToken(tokenConfig);
   var tokenString = tokenHanlder.WriteToken(token);

   return tokenString;
  }
 }
}
