using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommadValidator : AbstractValidator<RefreshTokenCommadRequest>
    {
        public RefreshTokenCommadValidator()
        {
            RuleFor(x => x.AcessToken).NotEmpty();
            RuleFor(x => x.RefreshToken).NotEmpty();
        }
    }
}
