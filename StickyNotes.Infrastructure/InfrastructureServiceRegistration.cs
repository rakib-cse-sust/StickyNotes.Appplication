using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StickyNotes.Application.Contracts.Infrastucture;
using StickyNotes.Application.Models.Mail;
using StickyNotes.Infrastructure.Mail;

namespace StickyNotes.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
