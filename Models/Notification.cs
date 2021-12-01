using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Notification : BaseEntity
    {
        public string Topic { get; set; }
        public string Message { get; set; }
        public DateTime Added { get; set; }
        public bool IsRead { get; set; }
        public bool IsDeleted { get; set; }
        
        public ICollection<AppUser> Users { get; set; }
    }
}