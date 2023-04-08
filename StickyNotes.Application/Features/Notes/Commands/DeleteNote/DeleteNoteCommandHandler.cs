using AutoMapper;
using MediatR;
using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Application.Exceptions;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Features.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Unit>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public DeleteNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var noteToDelete = await _noteRepository.GetByIdAsync(request.NoteId);

            if (noteToDelete == null)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            await _noteRepository.DeleteAsync(noteToDelete);

            return Unit.Value;
        }
    }
}
