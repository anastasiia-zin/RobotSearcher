using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Robot> Robots { get; set; }
        public ICollection<IdentityUser> Users { get; set; }
    }
}