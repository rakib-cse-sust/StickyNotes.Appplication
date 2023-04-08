using MediatR;

namespace StickyNotes.Application.Features.Notes.Queries.GetNoteDetail
{
    public class GetNoteDetailQuery : IRequest<NoteDetailVm>
    {
        public int NoteId { get; set; }
    }
}
