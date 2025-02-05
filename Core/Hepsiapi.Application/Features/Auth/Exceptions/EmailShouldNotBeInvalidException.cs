using Hepsiapi.Application.Bases;

namespace Hepsiapi.Application.Features.Auth.Exceptions
{
    public class EmailShouldNotBeInvalidException : BaseException
    {
        public EmailShouldNotBeInvalidException() : base("Böyle bir Email Adresi bulunmamaktadır.") { }

    }

    


}
