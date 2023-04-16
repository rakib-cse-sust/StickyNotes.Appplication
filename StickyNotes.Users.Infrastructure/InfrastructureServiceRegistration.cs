using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StickyNotes.Users.Application.Contracts.Infrastucture;
using StickyNotes.Users.Application.Models.Mail;
using StickyNotes.Users.Infrastructure.Mail;

namespace StickyNotes.Users.Infrastructure
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
