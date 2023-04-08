namespace StickyNotes.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteDto
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set; } = string.Empty;
    }
}
