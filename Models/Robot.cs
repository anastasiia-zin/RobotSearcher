using System;
using System.Collections.Generic;

namespace Models
{
    public class Robot : BaseEntity
    {
        public string Model { get; set; }
        public string Description { get; set; }
        public long Code { get; set; }
        public DateTime BuyDate { get; set; }
        public int YearOfCreation { get; set; }
        public double Height { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public string Country { get; set; }
        public int Voltage { get; set; }
        public int Resistance { get; set; }
        public int FullBatteryAmperPerHour { get; set; }
        public int ChargePercent { get; set; }
        
        public virtual ICollection<CategoryRobot> CategoryRobots { get; set; }
        public virtual ICollection<RobotIssue> RobotIssues { get; set; }
        public ICollection<Reserve> Reserves { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string ManufacturerId { get; set; }
    }
}