using AutoMapper;
using MediatR;
using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Application.Exceptions;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Features.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public UpdateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
        }

        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
           var noteToUpdate = await _noteRepository.GetByIdAsync(request.NoteId);

            if (noteToUpdate == null)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            _mapper.Map(request, noteToUpdate, typeof(UpdateNoteCommand), typeof(Note));

            await _noteRepository.UpdateAsync(noteToUpdate);

            return Unit.Value;
        }
    }
}
