using MediatR;

namespace StickyNotes.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Unit>
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
