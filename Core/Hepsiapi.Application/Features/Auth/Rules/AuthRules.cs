﻿using Hepsiapi.Application.Bases;
using Hepsiapi.Application.Features.Auth.Exceptions;
using Hepsiapi.Application.Features.Products.Exceptions;
using Hepsiapi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Rules
{
    public class AuthRules :BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask; 
        }

        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalid();
            return Task.CompletedTask;
        }
        
        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now) throw new RefreshTokenShouldNotBeExpiredException();
            return Task.CompletedTask;
        }

        public  Task EmailShouldNotBeInvalid(User? user)
        {
           if(user is null) throw new EmailShouldNotBeInvalidException();
            return Task.CompletedTask;
        }
    }
}
