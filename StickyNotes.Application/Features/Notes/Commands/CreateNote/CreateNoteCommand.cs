using MediatR;

namespace StickyNotes.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<CreateNoteCommandResponse>
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
