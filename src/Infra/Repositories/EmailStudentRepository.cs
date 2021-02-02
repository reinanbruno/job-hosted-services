using Core.Entities;
using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repositories
{
    public class EmailStudentRepository : IEmailStudentRepository
    {
        private List<EmailStudent> students;
        public EmailStudentRepository()
        {
            students = new List<EmailStudent>();

            for (int i = 0; i < 10; i++)
            {
                students.Add(new EmailStudent
                {
                    Name = $"Teste{i}",
                    AdressEmail = $"teste{i}@hotmail.com",
                    Subject = $"Olá Teste{i}!",
                    BodyMessage = $"Olá Teste{i}, job está executando..."
                });
            }
        }

        public List<EmailStudent> GetAllPendingEmail()
        {
            return students.Where(x => x.EmailHasBeenSent == false).ToList();
        }

        public void Save()
        {
            return;
        }
    }
}
