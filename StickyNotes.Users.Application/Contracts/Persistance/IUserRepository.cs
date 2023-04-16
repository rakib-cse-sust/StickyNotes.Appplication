using StickyNotes.Users.Application.Features.User.Queries.GetUserDetail;

namespace StickyNotes.Users.Application.Contracts.Persistance
{
    public interface IUserRepository : IAsyncRepository<Domain.Entities.User>
    {
        Task<bool> IsUserNameOrEmailUnique(string userName, string email);
        Task<UserDetailVm> GetUserByUserNamePassword(string email, string password);
    }
}
