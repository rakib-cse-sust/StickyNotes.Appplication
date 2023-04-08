using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Contracts.Persistance
{
    public interface INoteRepository : IAsyncRepository<Note>
    {
        Task<bool> IsNoteNameUnique(string noteName);
    }
}
