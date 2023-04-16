namespace StickyNotes.Users.Application.Features.User.Queries.GetUserDetail
{
    public class UserDetailVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}