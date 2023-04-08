using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Persistence.Repositories;

namespace StickyNotes.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StickyNotesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StickyNotesConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }
    }
}
