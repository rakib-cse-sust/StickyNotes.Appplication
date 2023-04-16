using MediatR;
using StickyNotes.Users.Application.Features.Notes.Queries.GetNoteDetail;

namespace StickyNotes.Application.Features.Notes.Queries.GetNoteDetail
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int Id { get; set; }
    }
}
