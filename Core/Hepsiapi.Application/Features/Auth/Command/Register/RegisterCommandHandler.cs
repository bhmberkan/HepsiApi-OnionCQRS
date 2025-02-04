
using AutoMapper;
using Hepsiapi.Application.Bases;
using Hepsiapi.Application.Features.Auth.Rules;
using Hepsiapi.Application.Interfaces.AutoMapper;
using Hepsiapi.Application.UnitOfWorks;
using Hepsiapi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly AutoMapper.IMapper mapper;

        public RegisterCommandHandler(AuthRules authRules,UserManager<User> userManager,RoleManager<Role> roleManager, AutoMapper.IMapper mapper,IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper,unitOfWork,httpContextAccessor) 
        {
            this.mapper= mapper;
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

           User user = mapper.Map<User>(request);
           // User user = mapper.Map<User, RegisterCommandRequest>(request); // hata
            user.UserName = request.Email;
            user.SecurityStamp=Guid.NewGuid().ToString();

            IdentityResult result = await userManager.CreateAsync(user, request.Password);
            if (result.Succeeded) 
            {
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name="user",
                        NormalizedName="USER",
                        ConcurrencyStamp=Guid.NewGuid().ToString(),

                    });

                await userManager.AddToRoleAsync(user, "user");
            }

            return Unit.Value;
        }
    }
}
