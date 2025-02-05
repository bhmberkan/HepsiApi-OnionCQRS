using Hepsiapi.Application.Bases;

namespace Hepsiapi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalid : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalid() : base("Kullanıcı adı veya şifre yamlıştır") { }
       
    }

     
    }
