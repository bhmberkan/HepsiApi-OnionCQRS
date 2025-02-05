using AutoMapper;
using Hepsiapi.Application.Bases;
using Hepsiapi.Application.Features.Auth.Rules;
using Hepsiapi.Application.Interfaces.Tokens;
using Hepsiapi.Application.UnitOfWorks;
using Hepsiapi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommadHandler : BaseHandler, IRequestHandler<RefreshTokenCommadRequest, RefreshTokenCommadResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        public RefreshTokenCommadHandler(IMapper mapper, IUnitOfWork unitOfWork,AuthRules authRules, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, ITokenService tokenService) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
        }

        public async Task<RefreshTokenCommadResponse> Handle(RefreshTokenCommadRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromEcpiredToken(request.AcessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByNameAsync(email);
            IList<string> roles= await userManager.GetRolesAsync(user);

            //if (user.RefresTokenExpiryTime <= DateTime.Now)
            //    throw new Exception("Oturum suresi sona ermiştir. Lütfen tekrar giriş yapınız");

            await authRules.RefreshTokenShouldNotBeExpired(user.RefresTokenExpiryTime);

            JwtSecurityToken newAccessToken = await tokenService.CreateToken(user, roles);
            string newRefreshToken = tokenService.GenerateRefleshToken();
            
            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                AcessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken,
            };

        }
    }
}
