using StickyNotes.Application.Models.Mail;

namespace StickyNotes.Application.Contracts.Infrastucture
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
