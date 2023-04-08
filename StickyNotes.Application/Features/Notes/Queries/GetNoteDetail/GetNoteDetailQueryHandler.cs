using AutoMapper;
using MediatR;
using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Application.Exceptions;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Features.Notes.Queries.GetNoteDetail
{
    internal class GetNoteDetailQueryHandler : IRequestHandler<GetNoteDetailQuery, NoteDetailVm>
    {
        private readonly IAsyncRepository<Note> _noteRepository;
        private readonly IAsyncRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetNoteDetailQueryHandler(IMapper mapper, IAsyncRepository<Note> noteRepository, IAsyncRepository<User> userRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public async Task<NoteDetailVm> Handle(GetNoteDetailQuery request, CancellationToken cancellationToken)
        {
            var @note = await _noteRepository.GetByIdAsync(request.NoteId);

            if (@note == null)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            var noteDetailDto = _mapper.Map<NoteDetailVm>(@note);

            var user = await _userRepository.GetByIdAsync(@note.NoteId);
            noteDetailDto.User = _mapper.Map<UserDto>(user);

            return noteDetailDto;
        }
    }
}