using System;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Reserve : BaseEntity
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public Robot Robot { get; set; }
        public string RobotId { get; set; }
    }
}