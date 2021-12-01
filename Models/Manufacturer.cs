using System.Collections.Generic;

namespace Models
{
    public class Manufacturer : BaseEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Robot> Robots { get; set; }
    }
}