using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookStore.App.Security;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.App.Services
{
 public class TokenService
 {
  public static string GenerateJwtToken(string userId)
  {

   byte[] key = Encoding.ASCII.GetBytes(Key.SecretKey);
   SecurityTokenDescriptor tokenConfig = new()
   {
    Subject = new ClaimsIdentity([
     new Claim("userId", userId),
    ]),
    Expires = DateTime.UtcNow.AddHours(1),
    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
   };

   JwtSecurityTokenHandler tokenHanlder = new();
   SecurityToken token = tokenHanlder.CreateToken(tokenConfig);
   string tokenString = tokenHanlder.WriteToken(token);

   return tokenString;
  }
 }
}
