using Hepsiapi.Application.Bases;

namespace Hepsiapi.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum suresi sona ermiştir. Lütfen tekrar giriş yapınız") { }

    }

     
    }
