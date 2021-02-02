using Core.Entities;

namespace Core.Interfaces.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailStudent email);
    }
}
