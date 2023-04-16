using StickyNotes.Users.Application.Models.Mail;

namespace StickyNotes.Users.Application.Contracts.Infrastucture
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
