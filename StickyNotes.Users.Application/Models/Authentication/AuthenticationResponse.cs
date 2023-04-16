﻿namespace StickyNotes.Users.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
