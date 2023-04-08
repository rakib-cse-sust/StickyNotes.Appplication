using AutoMapper;
using MediatR;
using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Features.Notes.Queries.GetNotesListQuery
{
    public class GetNotesListQueryHandler : IRequestHandler<GetNotesListQuery, List<NoteListVm>>
    {
        private readonly IAsyncRepository<Note> _noteRepository;
        private readonly IMapper _mapper;

        public GetNotesListQueryHandler(IMapper mapper, IAsyncRepository<Note> noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<List<NoteListVm>> Handle(GetNotesListQuery request, CancellationToken cancellationToken)
        {
            var allNotes = (await _noteRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<NoteListVm>>(allNotes);
        }
    }
}
