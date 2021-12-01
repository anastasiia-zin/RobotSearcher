using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<Notification> Notifications { get; set; }
    }
}