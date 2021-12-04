using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class AppUser : IdentityUser
    {
        public ICollection<AppUserNotification> AppUserNotifications { get; set; }
        public ICollection<Reserve> Reserves { get; set; }
    }
}