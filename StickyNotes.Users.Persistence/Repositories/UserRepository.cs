using StickyNotes.Users.Application.Contracts.Persistance;

namespace StickyNotes.Users.Persistence.Repositories
{
    public class UserRepository : BaseRepository<Domain.Entities.User>, IUserRepository
    {
        public UserRepository(StickyNotesUsersDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsUserNameOrEmailUnique(string userName, string email)
        {
            var matches = _dbContext.Users.Any(e => e.UserName.Equals(userName) || e.Email.Equals(email));
            return Task.FromResult(matches);
        }
    }
}
