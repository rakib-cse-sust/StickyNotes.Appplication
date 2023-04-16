using FluentValidation;
using StickyNotes.Users.Application.Contracts.Persistance;
using StickyNotes.Users.Application.Features.User.Commands.RegisterUser;

namespace StickyNotes.Users.Application.Features.Notes.Commands.RegisterUser
{
    public class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;

        public RegisterUserCommandValidation(IUserRepository repository)
        {
            _repository = repository;

            RuleFor(p => p.UserName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(UserNameOrEmailUnique)
                .WithMessage("A user with the same name or email already exists.");
        }

        private async Task<bool> UserNameOrEmailUnique(RegisterUserCommand e, CancellationToken token)
        {
            return !(await _repository.IsUserNameOrEmailUnique(e.UserName, e.Email));
        }
    }
}
