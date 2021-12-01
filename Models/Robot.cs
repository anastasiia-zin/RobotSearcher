using System;
using System.Collections.Generic;

namespace Models
{
    public class Robot : BaseEntity
    {
        public string Model { get; set; }
        public string Description { get; set; }
        public long Code { get; set; }
        
        public ICollection<Category> Categories { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public AppUser Client { get; set; }
    }
}