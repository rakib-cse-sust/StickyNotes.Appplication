using AutoMapper;
using MediatR;
using StickyNotes.Application.Contracts.Infrastucture;
using StickyNotes.Application.Contracts.Persistance;
using StickyNotes.Application.Models.Mail;
using StickyNotes.Domain.Entities;

namespace StickyNotes.Application.Features.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, CreateNoteCommandResponse>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _emailService = emailService;
        }

        public async Task<CreateNoteCommandResponse> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var createNoteCommandResponse = new CreateNoteCommandResponse();

            var validator = new CreateNoteCommandValidation(_noteRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createNoteCommandResponse.Success = false;
                createNoteCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createNoteCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createNoteCommandResponse.Success)
            {
                var @note = _mapper.Map<Note>(request);
                @note = await _noteRepository.AddAsync(@note);
                createNoteCommandResponse.Note = _mapper.Map<CreateNoteDto>(@note);
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

            return createNoteCommandResponse;
        }
    }
}
