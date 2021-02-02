using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces.Repositories
{
    public interface IEmailStudentRepository
    {
        List<EmailStudent> GetAllPendingEmail();
        void Save();
    }
}
