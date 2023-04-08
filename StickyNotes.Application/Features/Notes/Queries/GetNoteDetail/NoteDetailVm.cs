namespace StickyNotes.Application.Features.Notes.Queries.GetNoteDetail
{
    public class NoteDetailVm
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public UserDto User { get; set; }
    }
}