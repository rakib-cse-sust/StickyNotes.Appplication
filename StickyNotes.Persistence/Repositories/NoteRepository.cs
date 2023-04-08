using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Persistence.Repositories
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(StickyNotesDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsNoteNameUnique(string noteName)
        {
            var matches = _dbContext.Notes.Any(e => e.NoteName.Equals(noteName));
            return Task.FromResult(matches);
        }
    }
}
