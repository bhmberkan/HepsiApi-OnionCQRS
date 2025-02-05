using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Command.RefreshToken
{
    public class RefreshTokenCommadResponse
    {
        public string AcessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
