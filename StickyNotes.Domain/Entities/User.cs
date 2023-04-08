using StickyNotes.Domain.Common;

namespace StickyNotes.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
    }
}
