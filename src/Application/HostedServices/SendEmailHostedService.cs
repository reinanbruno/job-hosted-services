using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.HostedServices
{
    public class SendEmailHostedService : IHostedService, IDisposable
    {
        private readonly IEmailStudentRepository _emailStudentRepository;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;
        private Timer _timer;

        public SendEmailHostedService(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                _emailStudentRepository = scope.ServiceProvider.GetRequiredService<IEmailStudentRepository>();
                _emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                _logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processo iniciado às: {DateTime.Now}");
            _timer = new Timer(SendEmail, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Processo parado às: {DateTime.Now}");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void SendEmail(object state)
        {
            List<EmailStudent> emails = _emailStudentRepository.GetAllPendingEmail();

            foreach(EmailStudent email in emails)
            {
                try
                {
                    _emailService.SendEmail(email);
                    email.MarkEmailSent();
                    _emailStudentRepository.Save();

                }
                catch (Exception)
                {
                    continue;
                }
            }

        }

    }
}
