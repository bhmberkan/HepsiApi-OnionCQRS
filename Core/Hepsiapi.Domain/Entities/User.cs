using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Domain.Entities
{
    public class User :  IdentityUser<Guid>
    {
        public string FullName { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefresTokenExpiryTime { get; set; }


    }
}
