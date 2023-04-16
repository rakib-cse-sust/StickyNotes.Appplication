using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StickyNotes.Users.Application.Contracts.Persistance;
using StickyNotes.Users.Persistence.Repositories;

namespace StickyNotes.Users.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StickyNotesUsersDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StickyNotesUserConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
