using AutoMapper;
using Hepsiapi.Application.Bases;
using Hepsiapi.Application.Features.Auth.Rules;
using Hepsiapi.Application.Interfaces.Tokens;
using Hepsiapi.Application.UnitOfWorks;
using Hepsiapi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : BaseHandler, IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> userManager;
        
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly AuthRules authRules;

        public LoginCommandHandler(UserManager<User> userManager,IConfiguration configuration,ITokenService tokenService,AuthRules authRules,AutoMapper.IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper,unitOfWork,httpContextAccessor)
        {
            this.userManager = userManager;
            
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.authRules = authRules;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
           User user = await userManager.FindByEmailAsync(request.Email);

            bool checkPassword = await userManager.CheckPasswordAsync(user, request.Password);

            await authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles = await userManager.GetRolesAsync(user);

            JwtSecurityToken token = await tokenService.CreateToken(user, roles);
            string refleshToken = tokenService.GenerateRefleshToken();

           _= int.TryParse(configuration["JWT:RefreshTokenCalidityInDays"], out int RefreshTokenCalidityInDays);

            user.RefreshToken = refleshToken; 
            user.RefresTokenExpiryTime=DateTime.Now.AddDays(RefreshTokenCalidityInDays);

            await userManager.UpdateAsync(user);
            await userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await userManager.SetAuthenticationTokenAsync(user, "Default" , "AccessToken", _token);

            return new()
            {
                Token = _token,
                RefleshToken = refleshToken,
                Expiration = token.ValidTo
            };
        } 
    }
}
