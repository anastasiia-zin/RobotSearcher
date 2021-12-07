using System;

namespace Requests.Auth
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}