using MediatR;

namespace StickyNotes.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<Unit>
    {
        public int NoteId { get; set; }
    }
}
