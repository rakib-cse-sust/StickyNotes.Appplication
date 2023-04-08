using StickyNotes.Domain.Common;

namespace StickyNotes.Domain.Entities
{
    public class Note : AuditableEntity
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteDescription { get; set;} = string.Empty;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
