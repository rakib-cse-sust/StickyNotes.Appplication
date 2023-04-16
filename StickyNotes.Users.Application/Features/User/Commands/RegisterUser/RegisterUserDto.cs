namespace StickyNotes.Users.Application.Features.User.Commands.RegisterUser
{
    public class RegisterUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}