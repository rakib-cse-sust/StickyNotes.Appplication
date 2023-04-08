using MediatR;

namespace StickyNotes.Application.Features.Notes.Queries.GetNotesListQuery
{
    public class GetNotesListQuery : IRequest<List<NoteListVm>>
    {
    }
}
