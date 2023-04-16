using AutoMapper;
using MediatR;
using StickyNotes.Users.Application.Contracts.Infrastucture;
using StickyNotes.Users.Application.Contracts.Persistance;
using StickyNotes.Users.Application.Features.Notes.Commands.RegisterUser;
using StickyNotes.Users.Application.Features.User.Commands.RegisterUser;
using StickyNotes.Users.Application.Models.Mail;

namespace StickyNotes.Application.Features.Notes.Commands.CreateNote
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public RegisterUserCommandHandler(IMapper mapper, IUserRepository userRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerUserCommandResponse = new RegisterUserCommandResponse();
            var validator = new RegisterUserCommandValidation(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                registerUserCommandResponse.Success = false;
                registerUserCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    registerUserCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (registerUserCommandResponse.Success)
            {
                var @note = _mapper.Map<Users.Domain.Entities.User>(request);
                @note = await _userRepository.AddAsync(@note);
                registerUserCommandResponse.User = _mapper.Map<RegisterUserDto>(@note);
            }

            // Need to replace with email microservice + rabbitMq
            //Sending email notification to admin address
            var email = new Email() { To = "gill@snowball.be", Body = $"A new event was created: {request}", Subject = "A new event was created" };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
            }

            return registerUserCommandResponse;
        }
    }
}
