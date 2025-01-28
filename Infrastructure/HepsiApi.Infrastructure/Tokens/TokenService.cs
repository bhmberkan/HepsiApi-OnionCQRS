using Hepsiapi.Application.Interfaces.Tokens;
using Hepsiapi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HepsiApi.Infrastructure.Tokens
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> userManager;
        private readonly TokenSettings tokenSettings;

        public TokenService(IOptions<TokenSettings> options,UserManager<User> userManager)
        {
            tokenSettings = options.Value;
            this.userManager = userManager;
        }

        public async Task<JwtSecurityToken> CreateToken(User user, IList<string> roles)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // jwt Id mızı temsil eder
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)

              
            };

            foreach (var role in roles) // role'leri ekledik
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)); // key belirledik.

            // bu işlemlerden sonra tokenimizi oluşturuyoruz.
            var token = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(tokenSettings.TokenValidityInMunitues),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

                );


            foreach(var claim in claims)
            {

                await userManager.AddClaimAsync(user, claim); // veri tabanındaki claims tablosuna erişiyoruz
                                                               // giriş yapan kullanıcının bilgilerine erişip tek tek claimse ekliyoruz.
            }


            return token;
        }

        public string GenerateRefleshToken()
        {
            var rondomNumber = new byte[64];
            using var rgn = RandomNumberGenerator.Create();
            rgn.GetBytes(rondomNumber);
            return Convert.ToBase64String(rondomNumber);

            // appsetting.Developmentte oluşturuduğumuz gibi
            //  "Secret": "_<_8VB30Tnr9F+G1D`vg)u){Q4l2&kB}", bir key oluşturacak
        }

        public ClaimsPrincipal? GetPrincipalFromEcpiredToken(string? token)
        {
            // son tokene erişebilmemiz lazım. sistemin kontrol edip devam edebilmesi için
            // son tokenin süresi geçti mi kontrol etmemiz lazım. reflesh token verebilmek için
            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret)),
                ValidateLifetime = false,
                // default oalrak false verdim ayak bağı olmasın diye sonra düzeltiriz
            };

            JwtSecurityTokenHandler tokenHandler = new();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if(securityToken is not JwtSecurityToken jwtSecuritytoken
                || !jwtSecuritytoken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token Bulunamadı.");
            }
            
            return principal;

        }
    }
}
