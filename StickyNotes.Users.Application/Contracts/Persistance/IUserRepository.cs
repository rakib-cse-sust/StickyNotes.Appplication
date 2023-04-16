using StickyNotes.Users.Application.Contracts.Persistance;

namespace StickyNotes.Users.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<Domain.Entities.User>
    {
        Task<bool> IsUserNameOrEmailUnique(string userName, string email);
    }
}
