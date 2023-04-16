using StickyNotes.Users.Application.Responses;

namespace StickyNotes.Users.Application.Features.User.Commands.RegisterUser
{
    public class RegisterUserCommandResponse : BaseResponse
    {
        public RegisterUserCommandResponse() : base()
        {

        }

        public RegisterUserDto User { get; set; } = default!;
    }
}