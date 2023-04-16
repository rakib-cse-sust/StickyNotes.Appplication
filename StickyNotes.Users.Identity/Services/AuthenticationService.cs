using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using StickyNotes.Users.Application.Contracts.Identity;
using StickyNotes.Users.Application.Contracts.Persistance;
using StickyNotes.Users.Application.Models.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StickyNotes.Users.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(
            IUserRepository userRepository,
            IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userRepository.GetUserByUserNamePassword(request.Email, request.Password);

            if (user == null)
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            JwtSecurityToken jwtSecurityToken = GenerateToken(user.Id, user.Email);

            AuthenticationResponse response = new AuthenticationResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email
            };

            return response;
        }

        private JwtSecurityToken GenerateToken(int userId, string userEmail)
        {
            var claims = new[] {
                new Claim("id", userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, "atul"),
                    new Claim(JwtRegisteredClaimNames.Email, ""),
                    new Claim("Role", "Admin"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
