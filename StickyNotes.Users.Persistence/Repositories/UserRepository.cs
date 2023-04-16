using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StickyNotes.Users.Application.Contracts.Persistance;
using StickyNotes.Users.Application.Exceptions;
using StickyNotes.Users.Application.Features.User.Queries.GetUserDetail;

namespace StickyNotes.Users.Persistence.Repositories
{
    public class UserRepository : BaseRepository<Domain.Entities.User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(StickyNotesUsersDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<UserDetailVm> GetUserByUserNamePassword(string userName, string password)
        {
            var user = await _dbContext.Users.Where(e => e.UserName == userName && e.Password == password)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.User), userName);
            }

            var userDetailDto = _mapper.Map<UserDetailVm>(user);

            return userDetailDto;
        }

        public Task<bool> IsUserNameOrEmailUnique(string userName, string email)
        {
            var matches = _dbContext.Users.Any(e => e.UserName.Equals(userName) || e.Email.Equals(email));
            return Task.FromResult(matches);
        }
    }
}
