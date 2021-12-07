using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<CategoryRobot> CategoryRobots { get; set; }
    }
}