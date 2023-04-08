namespace StickyNotes.Application.Features.Notes.Queries.GetNotesListQuery
{
    public class NoteListVm
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; } = string.Empty;
        public string NoteDescription { get; set; } = string.Empty;
    }
}