using Microsoft.EntityFrameworkCore;
using StickyNotes.Users.Domain.Common;

namespace StickyNotes.Users.Persistence
{
    public class StickyNotesUsersDbContext : DbContext
    {
        public StickyNotesUsersDbContext(DbContextOptions<StickyNotesUsersDbContext> options)
            : base(options)
        {

        }

        public DbSet<Domain.Entities.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StickyNotesUsersDbContext).Assembly);

            modelBuilder.Entity<Domain.Entities.User>().HasData(new Domain.Entities.User
            {
                Id = 1,
                FirstName = "Rakib",
                LastName = "Khan",
                UserName = "rakib.cse.sust@gmail.com",
                Email = "rakib.cse.sust@gmail.com",
                Password = "1234",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        //entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        //entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}