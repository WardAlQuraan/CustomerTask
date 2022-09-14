using CUSTOMER.DTO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CUSTOMER.SERVICES.Services
{
    public static class JwtHelper
    {
        private static readonly byte[] _signKey = Encoding.UTF8.GetBytes("This is secret key for Customer System");
        public static string CreateJwtToken(UserDTO user)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.FirstName + " "+user.LastName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            claims.Add(new Claim(ClaimTypes.Role, user.Role));
            claims.Add(new Claim("ID", user.UserId.ToString()));


            var id = new ClaimsIdentity(claims);
            var h = new JwtSecurityTokenHandler();
            var token =h.CreateToken(new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = id,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_signKey),SecurityAlgorithms.HmacSha256)
            });
            return h.WriteToken(token);
        }

        public static IPrincipal ValidateJwtToken(string token)
        {
            var h = new JwtSecurityTokenHandler();
            h.ValidateToken(token, new TokenValidationParameters()
            {
                ValidAlgorithms = new[] {SecurityAlgorithms.HmacSha256},
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(_signKey),
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true
            },out var securityToken);
            var jwt = securityToken as JwtSecurityToken;
            var id = new ClaimsIdentity(jwt.Claims, "jwt", "name", "role");
            return new ClaimsPrincipal(id);
        }

        public static void AuthinticateRequest()
        {
            try
            {
                var token = HttpContext.Current.Request.Headers.Get("Authorization");
                var principal = ValidateJwtToken(token);
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch 
            {
                
            }
        }
    }
}
