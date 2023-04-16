using MediatR;

namespace StickyNotes.Users.Application.Features.User.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int Id { get; set; }
    }
}
