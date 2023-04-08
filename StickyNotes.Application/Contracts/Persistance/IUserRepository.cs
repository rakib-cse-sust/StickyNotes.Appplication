using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<User>
    {
    }
}
