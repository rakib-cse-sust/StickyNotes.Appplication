using FluentValidation;
using StickyNotes.Application.Contracts.Persistance;

namespace StickyNotes.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandValidation : AbstractValidator<CreateNoteCommand>
    {
        private readonly INoteRepository _repository;

        public CreateNoteCommandValidation(INoteRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.NoteName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
                .MustAsync(NoteNameUnique)
                .WithMessage("A note with the same name already exists.");
        }

        private async Task<bool> NoteNameUnique(CreateNoteCommand e, CancellationToken token)
        {
            return !(await _repository.IsNoteNameUnique(e.NoteName));
        }
    }
}
