using Core.Entities;
using Core.Interfaces.Services;

namespace Infra.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(EmailStudent email)
        {
            return true;
        }
    }
}
