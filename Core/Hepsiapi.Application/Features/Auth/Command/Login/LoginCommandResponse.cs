using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Auth.Command.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; }
        public string RefleshToken { get; set; }

        public DateTime Expiration { get; set; }
    }
}
