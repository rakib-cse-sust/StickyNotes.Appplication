using Microsoft.EntityFrameworkCore;
using StickyNotes.Domain.Common;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Persistence
{
    public class StickyNotesDbContext : DbContext
    {
        public StickyNotesDbContext(DbContextOptions<StickyNotesDbContext> options)
            : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StickyNotesDbContext).Assembly);

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                UserName = "rakib.cse.sust@gmail.com",
                UserFullName = "Rakib Khan",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 2,
                UserName = "rakib.jahan.khan@gmail.com",
                UserFullName = "Jahan Khan",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            modelBuilder.Entity<Note>().HasData(new Note
            {
                NoteId = 1,
                NoteName = "Test note 1",
                NoteDescription = "Test note description 1",
                UserId = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });

            modelBuilder.Entity<Note>().HasData(new Note
            {
                NoteId = 2,
                NoteName = "Test note 2",
                NoteDescription = "Test note description 2",
                UserId = 1,
                IsActive = true,
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
