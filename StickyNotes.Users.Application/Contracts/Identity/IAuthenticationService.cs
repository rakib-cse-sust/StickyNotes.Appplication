using StickyNotes.Users.Application.Models.Authentication;

namespace StickyNotes.Users.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        //Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
