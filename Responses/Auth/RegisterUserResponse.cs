using System;

namespace Requests.Auth
{
    public class RegisterUserResponse
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}